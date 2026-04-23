using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Windows.Forms;
using WarehouseApp.Classes;
using WarehouseApp.ClassesContext;

namespace WarehouseApp.Forms
{
    /// <summary>
    /// Форма для валют и сроков годности
    /// </summary>
    public partial class Options : Form
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Курс выбранной валюты
        /// </summary>
        public static decimal CurrentExchangeRate = 1.0m;
        /// <summary>
        /// Текущая выбранная валюта
        /// </summary>
        public static string CurrentCurrency = "RUB";
        /// <summary>
        /// Конструктор для формы валют
        /// </summary>
        public Options()
        {
            InitializeComponent();
            cmbValute.Items.AddRange(new string[] { "RUB", "USD", "EUR", "KZT" });
        }
        private void Options_Load(object sender, EventArgs e)
        {
            using (var db = new WarehouseContext())
            {
                var currencySetting = db.AppSettings.FirstOrDefault(s => s.Key == "Currency");
                var discountSetting = db.AppSettings.FirstOrDefault(s => s.Key == "DiscountPercent");
                if (currencySetting != null)
                {
                    cmbValute.SelectedItem = currencySetting.Value;
                    CurrentCurrency = currencySetting.Value;
                }
                else
                {
                    cmbValute.SelectedItem = "RUB";
                }
                if (discountSetting != null)
                {
                    txtDiscount.Text = discountSetting.Value;
                }
                else
                {
                    txtDiscount.Text = "30";
                }
            }
            if (cmbValute.SelectedItem.ToString() != "RUB")
            {
                LoadCurrencyRate(cmbValute.SelectedItem.ToString());
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string selectedCurrency = cmbValute.SelectedItem.ToString();
            string discountVal = txtDiscount.Text;
            if (!decimal.TryParse(discountVal, out decimal discount) || discount < 0 || discount > 100)
            {
                logger.Warn("DISCOUNT_VALIDATION_ERROR. Category: {Category}", "System", "Введено некорректное значение скидки");
                MessageBox.Show(Properties.Resources.InvalidDiscountRange);
                return;
            }
            using (var db = new WarehouseContext())
            {
                SaveSetting(db, "Currency", selectedCurrency);
                SaveSetting(db, "DiscountPercent", discountVal);
                SaveSetting(db, "ExchangeRate", CurrentExchangeRate.ToString());
                db.SaveChanges();
            }
            CurrentCurrency = selectedCurrency;

            logger.Info("SETTINGS_SAVED. Category: {Category}", "System", "Параметры обновлены");
            MessageBox.Show(Properties.Resources.SettingsSaved);
            Close();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void LoadCurrencyRate(string currencyCode)
        {
            if (currencyCode == "RUB")
            {
                CurrentExchangeRate = 1.0m;
                return;
            }
            try
            {
                string url = "https://www.cbr-xml-daily.ru/daily_json.js";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.UserAgent = "WarehouseApp";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (System.IO.StreamReader reader = new System.IO.StreamReader(response.GetResponseStream()))
                {
                    string json = reader.ReadToEnd();
                    using (var doc = JsonDocument.Parse(json))
                    {
                        if (doc.RootElement.TryGetProperty("Valute", out var valute) &&
                            valute.TryGetProperty(currencyCode, out var currency) &&
                            currency.TryGetProperty("Value", out var valueElement))
                        {
                            CurrentExchangeRate = valueElement.GetDecimal();
                        }
                    }
                }
            }
            catch (JsonException)
            {
                logger.Warn("INVALID_JSON. Category: {Category}", "System", "Не корректный JSON");
                CurrentExchangeRate = 1.0m;
            }
            catch (Exception ex)
            {
                logger.Warn(ex,"CURRENCY_API_ERROR. Category: {Category}", "System");
                CurrentExchangeRate = 1.0m;
            }
        }
        private void SaveSetting(WarehouseContext db, string key, string value)
        {
            var setting = db.AppSettings.FirstOrDefault(s => s.Key == key);
            if (setting == null)
            {
                db.AppSettings.Add(new AppSetting { Id = Guid.NewGuid(), Key = key, Value = value });
            }
            else
            {
                setting.Value = value;
            }
        }
        /// <summary>
        /// Конвертирует цену из рублей в выббраную валюту
        /// </summary>
        public static decimal ConvertFromBase(decimal priceInRub)
        {
            if (CurrentCurrency == "RUB")
                return priceInRub;
            return Math.Round(priceInRub / CurrentExchangeRate, 2);
        }
        /// <summary>
        /// Конвертирует из другой валюты в рубль
        /// </summary>
        public static decimal ConvertToBase(decimal priceInCurrentCurrency)
        {
            if (CurrentCurrency == "RUB")
                return priceInCurrentCurrency;
            return Math.Round(priceInCurrentCurrency * CurrentExchangeRate, 2);
        }
        /// <summary>
        /// Возвращает символ валюты
        /// </summary>
        public static string GetCurrencySymbol(string currencyCode)
        {
            var symbols = new Dictionary<string, string>
            {
                { "RUB", "₽" },
                { "USD", "$" },
                { "EUR", "€" },
                { "KZT", "₸" }
            };
            return symbols.TryGetValue(currencyCode, out var s) ? s : currencyCode;
        }
    }
}
