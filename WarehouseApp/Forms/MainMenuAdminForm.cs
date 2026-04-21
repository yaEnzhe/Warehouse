using System;
using System.Windows.Forms;
using WarehouseApp.Classes;

namespace WarehouseApp.Forms
{
    /// <summary>
    /// класс главной формы администратора
    /// </summary>
    public partial class MainMenuAdminForm : Form
    {
        /// <summary>
        /// ФИО либо ФИ пользователя
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// конструктор класса главной формы кладовщика
        /// </summary>
        /// <param name="userName"> ФИО либо ФИ пользователя</param>
        public MainMenuAdminForm()
        {
            InitializeComponent();
            var currentUserLogin = UserContext.Current.Login;
            var currentRole = UserContext.Current.Role.ToString();
            txtDate.Text = "Дата: " + DateTime.Now.ToString("dd.MM.yyyy");
            txtWelcome.Text = $"{Properties.Resources.Welcome}{UserName}";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            var catalog = new CatalogAdminForm();
            catalog.ShowDialog();
        }

        private void btnShipment_Click(object sender, EventArgs e)
        {
            var shipmentForm = new ShipmentFormAdmin();
            shipmentForm.ShowDialog();
        }

        private void btnActionHistory_Click(object sender, EventArgs e)
        {
            var changesForm = new ChangesAdmin();
            changesForm.ShowDialog();
        }
        private void btnParametr_Click(object sender, EventArgs e)
        {
            Options options = new Options();
            options.Show();
        }

        private void btnPostavki_Click(object sender, EventArgs e)
        {
            Supplies supplies = new Supplies();
            supplies.Show();
        }
    }
}

