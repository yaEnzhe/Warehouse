using System;
using System.Windows.Forms;
using WarehouseApp.Classes;
using WarehouseApp.Enums;
using System.Linq;

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
                    var query = from user in db.Users where user.Login == txtLogin.Text select user;
                    var thisUser = query.FirstOrDefault();
                    if (thisUser != null)
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
                        user1.HashPasswordBCrypt(user1, txtPassword.Text);
                        try
                        {
                            db.Users.Add(user1);
                            db.SaveChanges();
                            MessageBox.Show(Properties.Resources.UserRegistered); 
                        }
                        catch
                        {
                            MessageBox.Show(Properties.Resources.DatabaseSavingException);
                        }
                    }
                }
            }
        }
    }
}
