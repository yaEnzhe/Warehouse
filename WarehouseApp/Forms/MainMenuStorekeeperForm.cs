using System;
using System.Windows.Forms;

namespace WarehouseApp.Forms
{
    /// <summary>
    /// класс главной формы кладовщика
    /// </summary>
    public partial class MainMenuStorekeeperForm : Form
    {
        /// <summary>
        /// ФИО либо ФИ пользователя
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// конструктор класса главной формы кладовщика
        /// </summary>
        /// <param name="userName">ФИО либо ФИ пользователя</param>
        public MainMenuStorekeeperForm(string userName)
        {
            InitializeComponent();
            UserName = userName;
            txtDate.Text = "Дата: " + DateTime.Now.ToString("dd.MM.yyyy");
            txtWelcome.Text = $"{Properties.Resources.Welcome}{UserName}";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            var catalog = new CatalogStorekeeperForm();
            catalog.ShowDialog();
        }

        private void btnShipment_Click(object sender, EventArgs e)
        {
            var shipmentForm = new ShipmentFormStorekeeper();
            shipmentForm.ShowDialog();
        }
    }
}
