using NLog;

namespace WarehouseApp.Forms
{
    /// <summary>
    /// класс главной формы кладовщика
    /// </summary>
    public partial class MainMenuStorekeeperForm : Form, ILocalizableForm
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private bool updatingLanguage;
        /// <summary>
        /// ФИО либо ФИ пользователя
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// конструктор класса главной формы кладовщика
        /// </summary>
        /// <param name="userName">ФИО либо ФИ пользователя</param>
        public MainMenuStorekeeperForm()
        {
            InitializeComponent();
            WarehouseApp.ResponsiveFormHelper.Enable(this);

            if (UserContext.Current != null)
            {
                txtDate.Text = "Дата: " + DateTime.Now.ToString("dd.MM.yyyy");
                txtWelcome.Text = $"{Properties.Resources.Welcome}{UserDisplayHelper.GetShortName(UserContext.Current)}";
                labelStorekeeper.Text = UserDisplayHelper.GetRoleName(UserContext.Current.Role);
            }
            InitializeCurrency();
            InitializeLanguage();
            ApplyLocalization();
        }
        private void InitializeCurrency()
        {
            cmbCurrency.Items.Clear();
            cmbCurrency.Items.AddRange(new string[] { "RUB", "USD", "EUR", "KZT" });
            cmbCurrency.SelectedItem = Options.CurrentCurrency;
        }

        private void InitializeLanguage()
        {
            updatingLanguage = true;
            cmbLanguage.Items.Clear();
            cmbLanguage.Items.AddRange(new string[] { "RUS", "ENG" });
            cmbLanguage.SelectedItem = LanguageManager.CurrentLanguage;
            updatingLanguage = false;
        }
        private async void cmbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCurrency.SelectedItem == null) return;

            var newCurrency = cmbCurrency.SelectedItem.ToString();
            Options.CurrentCurrency = newCurrency;

            using (var db = new WarehouseContext())
            {
                SaveSetting(db, "Currency", newCurrency);

                if (newCurrency == "RUB")
                {
                    Options.CurrentExchangeRate = 1.0m;
                    SaveSetting(db, "ExchangeRate", Options.CurrentExchangeRate.ToString());
                    SaveSetting(db, "ExchangeRateCurrency", newCurrency);
                }
                else
                {
                    var savedRate = GetSavedExchangeRate(db, newCurrency);
                    var newRate = await AppServices.Get<ICurrencyRateService>().GetRateAsync(newCurrency);
                    Options.CurrentExchangeRate = newRate > 0 ? newRate : savedRate;
                    SaveSetting(db, "ExchangeRate", Options.CurrentExchangeRate.ToString());
                    SaveSetting(db, "ExchangeRateCurrency", newCurrency);
                }

                db.SaveChanges();
            }

            RefreshPriceForms();
            logger.Info("CURRENCY_CHANGED. Category: {Category}", "System", $"Кладовщик сменил валюту на: {newCurrency}");
        }

        private decimal GetSavedExchangeRate(WarehouseContext db, string currencyCode)
        {
            var setting = db.AppSettings.FirstOrDefault(s => s.Key == "ExchangeRate");
            var currencySetting = db.AppSettings.FirstOrDefault(s => s.Key == "ExchangeRateCurrency");
            if (setting != null &&
                currencySetting?.Value == currencyCode &&
                decimal.TryParse(setting.Value, out var savedRate) &&
                savedRate > 0)
            {
                return savedRate;
            }

            return 1.0m;
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

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingLanguage || cmbLanguage.SelectedItem == null)
                return;

            LanguageManager.SaveLanguage(cmbLanguage.SelectedItem.ToString());
            LanguageManager.ApplyToOpenForms();
        }
        private void RefreshPriceForms()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is CatalogAdminForm catalog)
                {
                    catalog.ReloadData();
                }
                if (form is Supplies supplies)
                {
                    supplies.ReloadData();
                }
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            UserContext.Current = null;
            Hide();
            var loginForm = AppServices.Get<LoginForm>();
            FormNavigationHelper.ApplyWindowState(this, loginForm);
            loginForm.FormClosed += (s, args) => Application.Exit();
            loginForm.ShowDialog();
            Close();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            var catalogForm = AppServices.Get<Func<bool, CatalogAdminForm>>()(true);
            FormNavigationHelper.ShowDialog(this, catalogForm);
        }

        private void btnShipment_Click(object sender, EventArgs e)
        {
            var shipmentForm = AppServices.Get<ShipmentFormStorekeeper>();
            FormNavigationHelper.ShowDialog(this, shipmentForm);
        }
        private void btnPostavki_Click(object sender, EventArgs e)
        {
            var supplies = AppServices.Get<Supplies>();
            FormNavigationHelper.ShowDialog(this, supplies);
        }

        private void btnWarehouseMap_Click(object sender, EventArgs e)
        {
            using (var warehouseMap = AppServices.Get<WarehouseMapForm>())
            {
                FormNavigationHelper.ShowDialog(this, warehouseMap);
            }
        }

        /// <summary>
        /// Обновляет тексты формы под текущий язык.
        /// </summary>
        public void ApplyLocalization()
        {
            LanguageManager.ApplyControls(this);

            if (UserContext.Current != null)
            {
                txtDate.Text = LanguageManager.Text("DatePrefix") + DateTime.Now.ToString("dd.MM.yyyy");
                txtWelcome.Text = $"{LanguageManager.Text("Welcome")}{UserDisplayHelper.GetShortName(UserContext.Current)}";
                labelStorekeeper.Text = UserDisplayHelper.GetRoleName(UserContext.Current.Role);
            }

            if (cmbLanguage.SelectedItem?.ToString() != LanguageManager.CurrentLanguage)
            {
                updatingLanguage = true;
                cmbLanguage.SelectedItem = LanguageManager.CurrentLanguage;
                updatingLanguage = false;
            }
        }
    }
}
