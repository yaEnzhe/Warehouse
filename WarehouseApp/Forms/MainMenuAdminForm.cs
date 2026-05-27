using NLog;

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
            var loginForm = AppServices.Get<LoginForm>();
            FormNavigationHelper.ApplyWindowState(this, loginForm);
            loginForm.FormClosed += (s, args) => Application.Exit();
            loginForm.ShowDialog();
            Close();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            var catalog = AppServices.Get<CatalogAdminForm>();
            FormNavigationHelper.ShowDialog(this, catalog);
        }

        private void btnShipment_Click(object sender, EventArgs e)
        {
            var shipmentForm = AppServices.Get<ShipmentFormAdmin>();
            FormNavigationHelper.ShowDialog(this, shipmentForm);
        }

        private void btnActionHistory_Click(object sender, EventArgs e)
        {
            var changesForm = AppServices.Get<ChangesAdmin>();
            FormNavigationHelper.ShowDialog(this, changesForm);
        }
        private void btnParametr_Click(object sender, EventArgs e)
        {
            var options = AppServices.Get<Options>();
            FormNavigationHelper.Show(this, options);
        }

        private void btnPostavki_Click(object sender, EventArgs e)
        {
            var supplies = AppServices.Get<Supplies>();
            FormNavigationHelper.Show(this, supplies);
        }

        private void btnWarehouseMap_Click(object sender, EventArgs e)
        {
            using (var warehouseMap = AppServices.Get<WarehouseMapForm>())
            {
                FormNavigationHelper.ShowDialog(this, warehouseMap);
            }
        }

    }
}

