using System;
using System.Linq;
using System.Windows.Forms;
using WarehouseApp.Classes;
using WarehouseApp.Forms;

namespace WarehouseApp
{
    public partial class LoginForm : Form
    {
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
            using (var db = new UserContext())
            {
                var thisUser = db.Users.FirstOrDefault(user => user.Login == txtLogin.Text);
                if (thisUser != null && thisUser.CheckPassword(thisUser, txtPassword.Text))
                {
                    string userName = "";
                    if (thisUser.Patronymic == null)
                    {
                        userName += thisUser.Name[0] + ". ";
                        userName += thisUser.Surname;
                    }
                    else
                    {
                        userName += thisUser.Name[0] + ". ";
                        userName += thisUser.Patronymic[0] + ". ";
                        userName += thisUser.Surname;
                    }

                    if (thisUser.Role == Enums.Roles.Administrator)
                    {
                        var mainMenuAdminForm = new MainMenuAdminForm(userName);
                        mainMenuAdminForm.ShowDialog();
                    }
                    else if (thisUser.Role == Enums.Roles.Storekeeper)
                    {
                        var mainMenuStorekeeperForm = new MainMenuStorekeeperForm(userName);
                        mainMenuStorekeeperForm.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show(Properties.Resources.IncorrectLoginOrPassword);
                }
            }
        }
    }
}
