using System;
using System.Windows.Forms;
using WarehouseApp.Classes;
using WarehouseApp.Enums;

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
                bool admin = false;
                foreach (User user in db.Users)
                {
                    if (user.Role == Roles.Administrator)
                    {
                        admin = true;
                        break;
                    }
                }
                if (!admin)
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
                    administrator.SetPassword(administrator, adminPassword);
                    db.Users.Add(administrator);
                    db.SaveChanges();
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
