using System;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Windows.Forms;
using WarehouseApp.Classes;
using WarehouseApp.ClassesContext;
using WarehouseApp.Enums;
using WarehouseApp.Forms;

namespace WarehouseApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                using (var db = new WarehouseContext())
                {
                    var badRate = db.AppSettings.FirstOrDefault(s => s.Key == "ExchangeRate");
                    if (badRate != null)
                    {
                        db.AppSettings.Remove(badRate);
                        db.SaveChanges();
                        System.Diagnostics.Debug.WriteLine("Старый курс удален");
                    }
                }
                InitializeDatabase();
                LoadCurrencySettings();
                Application.Run(new LoginForm());
            }
            catch
            {
                MessageBox.Show(Properties.Resources.StartupError);
            }
        }
        /// <summary>
        /// Первые данные
        /// </summary>
        static void InitializeDatabase()
        {
            using (WarehouseContext db = new WarehouseContext())
            {
                var thisUser = db.Users.FirstOrDefault(user => user.Role == Roles.Administrator);
                if (thisUser == null)
                {
                    var administrator = new User
                    {
                        Id = Guid.NewGuid(),
                        Name = "Иван",
                        Surname = "Иванов",
                        Patronymic = "Иванович",
                        Login = "admin",
                        Role = Roles.Administrator,
                        DateOfRegistration = DateTime.Now
                    };
                    string adminPassword = "admin666";
                    Password.HashPasswordBCrypt(administrator, adminPassword);
                    db.Users.Add(administrator);
                    db.SaveChanges();
                }

                // Клиент
                var thisClient = db.Clients.FirstOrDefault(client => client.NameClients == "Канцелярики");
                if (thisClient == null)
                {
                    thisClient = new Clients
                    {
                        IdClients = Guid.NewGuid(),
                        NameClients = "Канцелярики",
                    };
                    db.Clients.Add(thisClient);
                    db.SaveChanges();
                }

                // Категории
                if (!db.Categories.Any())
                {
                    var cats = new[] {
                        "Письменные принадлежности", "Офисные принадлежности", "Рисование и лепка",
                        "Счетный материал", "Торговые принадлежности", "Чертежные принадлежности",
                        "Бумажная продукция", "Карты и глобусы"
                    };
                    foreach (var name in cats)
                    {
                        db.Categories.Add(new Categories { IdCategories = Guid.NewGuid(), NameCategory = name });
                    }
                    db.SaveChanges();
                }

                // Единицы измерения
                if (!db.UnitOfMeasure.Any())
                {
                    var units = new[] {
                        "Штук", "Упаковка", "Коробка", "Лист", "Кг", "Рулон", "Комплект", "Миллилитр"
                    };
                    foreach (var name in units)
                    {
                        db.UnitOfMeasure.Add(new UnitOfMeasure { IdUnit = Guid.NewGuid(), NameUnit = name });
                    }
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Загружает валюту и курс
        /// </summary>
        public static void LoadCurrencySettings()
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    var currencySetting = db.AppSettings.FirstOrDefault(s => s.Key == "Currency");
                    var exchangeRateSetting = db.AppSettings.FirstOrDefault(s => s.Key == "ExchangeRate");

                    string currency = currencySetting?.Value ?? "RUB";
                    Options.CurrentCurrency = currency;

                    if (currency != "RUB")
                    {
                        if (exchangeRateSetting != null && decimal.TryParse(exchangeRateSetting.Value, out decimal savedRate))
                        {
                            Options.CurrentExchangeRate = savedRate;
                        }
                        else
                        {
                            string url = "https://www.cbr-xml-daily.ru/daily_json.js";
                            using (var client = new WebClient())
                            {
                                string json = client.DownloadString(url);
                                using (var doc = JsonDocument.Parse(json))
                                {
                                    if (doc.RootElement.TryGetProperty("Valute", out var valute) &&
                                        valute.TryGetProperty(currency, out var currencyData) &&
                                        currencyData.TryGetProperty("Value", out var valueElement))
                                    {
                                        Options.CurrentExchangeRate = valueElement.GetDecimal();

                                        if (exchangeRateSetting == null)
                                        {
                                            db.AppSettings.Add(new AppSetting
                                            {
                                                Id = Guid.NewGuid(),
                                                Key = "ExchangeRate",
                                                Value = Options.CurrentExchangeRate.ToString()
                                            });
                                        }
                                        else
                                        {
                                            exchangeRateSetting.Value = Options.CurrentExchangeRate.ToString();
                                        }
                                        db.SaveChanges();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Options.CurrentExchangeRate = 1.0m;
                    }
                }
            }
            catch
            {
                Options.CurrentExchangeRate = 1.0m;
                Options.CurrentCurrency = "RUB";
            }
        }
    }
}
