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
                    Logger.Info(thisUser.Login, "LOGIN_SUCCESS", $"Успешный вход. Роль: {thisUser.Role}");

                    if (thisUser.Role == Enums.Roles.Administrator)
                    {
                        var mainMenuAdminForm = new MainMenuAdminForm();
                        Close();
                        mainMenuAdminForm.ShowDialog();
                    }
                    else if (thisUser.Role == Enums.Roles.Storekeeper)
                    {
                        var mainMenuStorekeeperForm = new MainMenuStorekeeperForm();
                        Close();
                        mainMenuStorekeeperForm.ShowDialog();
                    }
                }
                else
                {
                    Logger.Warning("System", "LOGIN_FAILED", "Попытка входа с неверными учетными данными");
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
