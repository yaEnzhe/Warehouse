using NLog;
using System;
using System.Linq;
using System.Windows.Forms;
using WarehouseApp.Classes;
using WarehouseApp.ClassesContext;
using WarehouseApp.Forms;

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
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            var registration = new RegistrationForm();
            registration.ShowDialog();
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
                        var mainMenuAdminForm = new MainMenuAdminForm();
                        Hide();
                        mainMenuAdminForm.ShowDialog();
                        Close();
                    }
                    else if (thisUser.Role == Enums.Roles.Storekeeper)
                    {
                        var mainMenuStorekeeperForm = new MainMenuStorekeeperForm();
                        Hide();
                        mainMenuStorekeeperForm.ShowDialog();
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
