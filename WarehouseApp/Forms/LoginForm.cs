using NLog;

namespace WarehouseApp
{
    /// <summary>
    /// класс формы авторизации
    /// </summary>
    public partial class LoginForm : Form
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// конструктор класса формы авторизации
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
            ResponsiveFormHelper.Enable(this);
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            var registration = AppServices.Get<RegistrationForm>();
            FormNavigationHelper.ShowDialog(this, registration);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (var db = new WarehouseContext())
            {
                var thisUser = db.Users.FirstOrDefault(user => user.Login == txtLogin.Text);

                if (thisUser != null && Password.CheckPassword(thisUser, txtPassword.Text))
                {
                    UserContext.Current = thisUser;
                    logger.Info("LOGIN_SUCCESS. Category: {Category}", thisUser.Login, $"Успешный вход. Роль: {thisUser.Role}");
                    if (thisUser.Role == Enums.Roles.Administrator)
                    {
                        var mainMenuAdminForm = AppServices.Get<MainMenuAdminForm>();
                        Hide();
                        FormNavigationHelper.ShowDialog(this, mainMenuAdminForm);
                        Close();
                    }
                    else if (thisUser.Role == Enums.Roles.Storekeeper)
                    {
                        var mainMenuStorekeeperForm = AppServices.Get<MainMenuStorekeeperForm>();
                        Hide();
                        FormNavigationHelper.ShowDialog(this, mainMenuStorekeeperForm);
                        Close();
                    }
                }
                else
                {
                    logger.Warn("LOGIN_FAILED. Category: {Category}", "System", "Попытка входа с неверным паролем/логином");
                    MessageBox.Show(Properties.Resources.IncorrectLoginOrPassword);
                }
            }
        }

        private void txtLoginHeadline_Enter(object sender, EventArgs e)
        {
            txtLogin.Focus();
        }

        private void txtPasswordHeadline_Enter(object sender, EventArgs e)
        {
            txtPassword.Focus();
        }

        private void txtWarehouseHeadline_Enter(object sender, EventArgs e)
        {
            txtLogin.Focus();
        }
    }
}
