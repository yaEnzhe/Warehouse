using NLog;

namespace WarehouseApp.Forms
{
    /// <summary>
    /// Форма для валют и сроков годности
    /// </summary>
    public partial class Options : Form
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly ICurrencyRateService currencyRateService;
        private readonly BindingSource settingsBindingSource = new BindingSource();
        private readonly OptionsSettingsModel settings = new OptionsSettingsModel();
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
        public Options(ICurrencyRateService currencyRateService = null)
        {
            InitializeComponent();
            WarehouseApp.ResponsiveFormHelper.Enable(this);
            cmbValute.Items.AddRange(new string[] { "RUB", "USD", "EUR", "KZT" });
            this.currencyRateService = currencyRateService ?? AppServices.Get<ICurrencyRateService>();
            BindSettings();
            Load += Options_Load;
        }

        private void BindSettings()
        {
            settingsBindingSource.DataSource = settings;
            cmbValute.DataBindings.Add("SelectedItem", settingsBindingSource, nameof(OptionsSettingsModel.Currency), false, DataSourceUpdateMode.OnPropertyChanged);
            txtDiscount.DataBindings.Add("Text", settingsBindingSource, nameof(OptionsSettingsModel.DiscountPercent), false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private async void Options_Load(object sender, EventArgs e)
        {
            using (var db = new WarehouseContext())
            {
                var currencySetting = db.AppSettings.FirstOrDefault(s => s.Key == "Currency");
                var discountSetting = db.AppSettings.FirstOrDefault(s => s.Key == "DiscountPercent");
                if (currencySetting != null)
                {
                    settings.Currency = currencySetting.Value;
                }
                else
                {
                    settings.Currency = "RUB";
                }
                if (discountSetting != null)
                {
                    settings.DiscountPercent = discountSetting.Value;
                }
                else
                {
                    settings.DiscountPercent = "30";
                }
            }
            settingsBindingSource.ResetBindings(false);
            CurrentCurrency = settings.Currency;

            if (settings.Currency != "RUB")
            {
                await LoadCurrencyRateAsync(settings.Currency);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            settingsBindingSource.EndEdit();

            if (string.IsNullOrWhiteSpace(settings.Currency))
            {
                logger.Warn("CURRENCY_NOT_SELECTED. Category: {Category}", "System", "Валюта не выбрана");
                MessageBox.Show("Выберите валюту", Properties.Resources.WarningTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbValute.Focus();
                return;
            }

            var selectedCurrency = settings.Currency;
            var discountVal = settings.DiscountPercent;
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
        private async Task LoadCurrencyRateAsync(string currencyCode)
        {
            if (currencyCode == "RUB")
            {
                CurrentExchangeRate = 1.0m;
                return;
            }
            try
            {
                CurrentExchangeRate = await currencyRateService.GetRateAsync(currencyCode);
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

        private void labelPar_Click(object sender, EventArgs e)
        {

        }

        private class OptionsSettingsModel
        {
            /// <summary>
            /// Выбранная валюта.
            /// </summary>
            public string Currency { get; set; }

            /// <summary>
            /// Процент скидки для товаров.
            /// </summary>
            public string DiscountPercent { get; set; }
        }
    }
}
