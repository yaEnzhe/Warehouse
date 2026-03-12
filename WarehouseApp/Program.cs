using System;
using System.Windows.Forms;
using WarehouseApp.Classes;
using WarehouseApp.Enums;
using System.Linq;

namespace WarehouseApp
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (UserContext db = new UserContext())
            {
                var query = from user in db.Users where user.Role == Roles.Administrator select user;
                var thisUser = query.FirstOrDefault();
                if (thisUser == null)
                {
                    var administrator = new User
                    {
                        Name = "Иванов",
                        Surname = "Иван",
                        Patronymic = "Иванович",
                        Login = "admin",
                        Role = Roles.Administrator,
                        DateOfRegistration = DateTime.Now
                    };
                    string adminPassword = "admin666";
                    administrator.HashPasswordBCrypt(administrator, adminPassword);
                    try
                    {
                        db.Users.Add(administrator);
                        db.SaveChanges(); 
                    }
                    catch(Exception ex) 
                    {
                        MessageBox.Show(Properties.Resources.DatabaseSavingException +ex.Message);
                    }
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
