using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using WarehouseApp.Classes;
using WarehouseApp.ClassesContext;
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
            using (WarehouseContext db = new WarehouseContext())
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
            Database.SetInitializer(new CreateDatabaseIfNotExists<WarehouseContext>());
            using (var context = new WarehouseContext())
            {
                context.Database.Initialize(true);
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartForm());
        }
    }
}
