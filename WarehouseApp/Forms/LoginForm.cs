using System;
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
                foreach(var user in db.Users)
                {
                    if (txtLogin.Text == user.Login && txtPassword.Text==user.Password)
                    {
                        var mainMenuForm = new MainMenuForm();

                        mainMenuForm.ShowDialog();
                        break;
                    }
                    else
                    {
                        MessageBox.Show(Properties.Resources.IncorrectLoginOrPassword);
                        break;
                    }
                }
            }
        }
    }
}
