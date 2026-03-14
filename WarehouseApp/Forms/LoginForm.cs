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

        private void LoginForm_Load(object sender, EventArgs e)
        {
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (var db = new UserContext())
            {
                var thisUser = db.Users.FirstOrDefault(user => user.Login == txtLogin.Text);
                if (thisUser != null && thisUser.CheckPassword(thisUser, txtPassword.Text))
                {
                    if (thisUser.Role == Enums.Roles.Administrator)
                    {
                        var mainMenuAdminForm = new MainMenuAdminForm();
                        mainMenuAdminForm.ShowDialog();
                    }
                    else if (thisUser.Role == Enums.Roles.Storekeeper)
                    {
                        var mainMenuStorekeeperForm = new MainMenuStorekeeperForm();
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
