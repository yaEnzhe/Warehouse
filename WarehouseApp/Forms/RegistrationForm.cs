using System;
using System.Windows.Forms;
using WarehouseApp.Classes;
using WarehouseApp.Enums;

namespace WarehouseApp
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtSurname.Text) || string.IsNullOrWhiteSpace(txtLogin.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show(Properties.Resources.FillTheFIelds);
            }
            else
            {
                using (var db = new UserContext())
                {
                    var loginExists = false;
                    foreach(var user in db.Users)
                    {
                        if(user.Login == txtLogin.Text)
                        {
                            loginExists = true; 
                            break;
                        }
                    }
                    if(loginExists)
                    {
                        MessageBox.Show(Properties.Resources.UserAlreadyExists);
                    }
                    else
                    {
                        var user1 = new User
                        {
                            Name = txtName.Text,
                            Surname = txtSurname.Text,
                            Patronymic = txtPatronymic.Text,
                            Login = txtLogin.Text,
                            Role = Roles.Storekeeper,
                            DateOfRegistration = DateTime.Now
                        };
                        user1.SetPassword(user1, txtPassword.Text);
                        db.Users.Add(user1);
                        db.SaveChanges();
                        MessageBox.Show(Properties.Resources.UserRegistered);
                    }
                }
            }
        }
    }
}
