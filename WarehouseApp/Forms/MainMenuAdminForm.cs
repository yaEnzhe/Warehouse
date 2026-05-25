using NLog;
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
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
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
            WarehouseApp.ResponsiveFormHelper.Enable(this);
            if (UserContext.Current == null)
            {
                logger.Warn("SESSION_EXPIRED. Category: {Category}", "System", "Ошибка авторизации");
                MessageBox.Show(Properties.Resources.UserNotAuthorized);
                Close();
                return;
            }
            txtDate.Text = "Дата: " + DateTime.Now.ToString("dd.MM.yyyy");
            txtWelcome.Text = $"{Properties.Resources.Welcome}{UserDisplayHelper.GetShortName(UserContext.Current)}";
            labelAdmin.Text = UserDisplayHelper.GetRoleName(UserContext.Current.Role);
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

        private void btnWarehouseMap_Click(object sender, EventArgs e)
        {
            using (var warehouseMap = new WarehouseMapForm())
            {
                warehouseMap.ShowDialog();
            }
        }

    }
}

