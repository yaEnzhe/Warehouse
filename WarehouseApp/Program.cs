
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
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<WarehouseContext, Configuration>());

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
                ConfigureServices();
                LoadCurrencySettings();
                Application.Run(AppServices.Get<LoginForm>());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Properties.Resources.StartupError}\n\n{ex.Message}");
            }
        }
        /// <summary>
        /// Первые данные
        /// </summary>
        static void InitializeDatabase()
        {
            using (var db = new WarehouseContext())
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
                    var adminPassword = "admin666";
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
        /// Регистрирует зависимости приложения.
        /// </summary>
        static void ConfigureServices()
        {
            var container = new SimpleContainer();

            container.AddSingleton<IContractorCheckService>(() => new DadataContractorCheckService());
            container.AddSingleton<ICurrencyRateService>(() => new CurrencyRateService());
            container.AddSingleton<IWeatherService>(() => new OpenWeatherMapService());

            container.AddTransient(() => new LoginForm());
            container.AddTransient(() => new RegistrationForm());
            container.AddTransient(() => new MainMenuAdminForm());
            container.AddTransient(() => new MainMenuStorekeeperForm());
            container.AddTransient(() => new CatalogAdminForm());
            container.AddTransient<Func<bool, CatalogAdminForm>>(() => readOnly => new CatalogAdminForm(readOnly));
            container.AddTransient(() => new ShipmentFormAdmin(AppServices.Get<IWeatherService>()));
            container.AddTransient(() => new ShipmentFormStorekeeper(AppServices.Get<IWeatherService>()));
            container.AddTransient(() => new ChangesAdmin());
            container.AddTransient(() => new Options(AppServices.Get<ICurrencyRateService>()));
            container.AddTransient(() => new Supplies());
            container.AddTransient(() => new DeliveryHistory());
            container.AddTransient<Func<Guid, ContentsOfSupplies>>(() => supplyId => new ContentsOfSupplies(supplyId));
            container.AddTransient(() => new WarehouseMapForm());
            container.AddTransient(() => new ContractorCheckForm(AppServices.Get<IContractorCheckService>()));

            AppServices.Configure(container);
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

                    var currency = currencySetting?.Value ?? "RUB";
                    Options.CurrentCurrency = currency;

                    if (currency != "RUB")
                    {
                        if (exchangeRateSetting != null && decimal.TryParse(exchangeRateSetting.Value, out decimal savedRate))
                        {
                            Options.CurrentExchangeRate = savedRate;
                        }
                        else
                        {
                            var url = "https://www.cbr-xml-daily.ru/daily_json.js";
                            using (var client = new WebClient())
                            {
                                var json = client.DownloadString(url);
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
