using NLog;
using System;
using System.Windows.Forms;
using WarehouseApp.Classes;
using WarehouseApp.ClassesContext;
using System.Linq;

namespace WarehouseApp.Forms
{
    /// <summary>
    /// класс главной формы кладовщика
    /// </summary>
    public partial class MainMenuStorekeeperForm : Form
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
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

            if (UserContext.Current != null)
            {
                txtDate.Text = "Дата: " + DateTime.Now.ToString("dd.MM.yyyy");
                txtWelcome.Text = $"{Properties.Resources.Welcome} {UserContext.Current.Login}";
            }
            InitializeCurrency();
        }
        private void InitializeCurrency()
        {
            cmbCurrency.Items.Clear();
            cmbCurrency.Items.AddRange(new string[] { "RUB", "USD", "EUR", "KZT" });
            cmbCurrency.SelectedItem = Options.CurrentCurrency;
        }
        private void cmbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCurrency.SelectedItem == null) return;

            string newCurrency = cmbCurrency.SelectedItem.ToString();
            Options.CurrentCurrency = newCurrency;
            if (newCurrency != "RUB")
            {
                using (var db = new WarehouseContext())
                {
                    var rateSetting = db.AppSettings.FirstOrDefault(s => s.Key == "ExchangeRate");
                    if (rateSetting != null)
                    {
                        db.AppSettings.Remove(rateSetting);
                        db.SaveChanges();
                    }
                }
                Program.LoadCurrencySettings();
            }
            else
            {
                Options.CurrentExchangeRate = 1.0m;
            }
            RefreshPriceForms();
            logger.Info("CURRENCY_CHANGED. Category: {Category}", "System", $"Кладовщик сменил валюту на: {newCurrency}");
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
            LoginForm loginForm = new LoginForm();
            loginForm.FormClosed += (s, args) => Application.Exit();
            loginForm.ShowDialog();
            Close();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            var catalogForm = new CatalogAdminForm(readOnly: true);
            catalogForm.ShowDialog();
        }

        private void btnShipment_Click(object sender, EventArgs e)
        {
            var shipmentForm = new ShipmentFormStorekeeper();
            shipmentForm.ShowDialog();
        }
        private void btnPostavki_Click(object sender, EventArgs e)
        {
            Supplies supplies = new Supplies();
            supplies.ShowDialog();
        }
    }
}
