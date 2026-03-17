using System;
using System.Windows.Forms;
using WarehouseApp.Classes;
using WarehouseApp.Enums;
using System.Linq;
using System.Data.Entity.Infrastructure.Interception;

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
                var thisUser = db.Users.FirstOrDefault(user => user.Role == Roles.Administrator);
                if (thisUser == null)
                {
                    var administrator = new User
                    {
                        Id = Guid.NewGuid(),
                        Name = "Иван",
                        Surname = "Иванов",
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
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        MessageBox.Show(Properties.Resources.DatabaseSavingException);
                    }
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
