using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Windows.Forms;
using WarehouseApp.Classes;
using WarehouseApp.ClassesContext;
using WarehouseApp.Enums;

namespace WarehouseApp
{
    /// <summary>
    /// Класс формы регистрации
    /// </summary>
    public partial class RegistrationForm : Form
    {
        /// <summary>
        /// конструктор класса формы регистрации
        /// </summary>
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
                using (var db = new WarehouseContext())
                {
                    var thisUser = db.Users.FirstOrDefault(user => user.Login == txtLogin.Text);
                    if (thisUser != null)
                    {
                        MessageBox.Show(Properties.Resources.UserAlreadyExists);
                    }
                    else
                    {
                        var user1 = new User
                        {
                            Id = Guid.NewGuid(),
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
                            Close();
                        }
                        catch (DbUpdateException ex)
                        {
                            Console.WriteLine(ex.Message);
                            MessageBox.Show(Properties.Resources.DatabaseSavingException);
                        }
                    }
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == ' ')        //запрет на пробелы
            {
                e.Handled = true;
            }
        }

        private void txtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }

        private void txtPatronymic_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }

            if (!char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSurname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }

            if (!char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }

            if (!char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
