using System;
using System.Linq;
using System.Windows.Forms;
using WarehouseApp.Classes;
using WarehouseApp.ClassesContext;
using WarehouseApp.Enums;

namespace WarehouseApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            try
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

                        db.Users.Add(administrator);
                        db.SaveChanges();
                    }
                    var thisClient = db.Clients.FirstOrDefault(client => client.NameClients == "Канцелярики");
                    if (thisClient == null)
                    {
                        thisClient = new Clients
                        {
                            IdClients = Guid.NewGuid(),
                            NameClients = "Канцелярики",
                        };
                        db.Clients.Add(thisClient);
                        db.SaveChanges();
                    }
                    var thisShipment = db.Shipments.FirstOrDefault(shipment => shipment.IdClients == thisClient.IdClients);
                    if (thisShipment == null)
                    {
                        DateTime.TryParse("20.03.2026", out DateTime date);
                        thisShipment = new Shipment
                        {
                            IdShipment = Guid.NewGuid(),
                            DateOfShipment = date,
                            PriceShipment = 50000,
                            Status = ShipmentStatus.Shipped,
                            IdClients = thisClient.IdClients
                        };
                        db.Shipments.Add(thisShipment);
                        db.SaveChanges();
                    }
                    if (!db.Categories.Any())
                    {
                        var cats = new[] {
                            "Письменные принадлежности", "Офисные принадлежности", "Рисование и лепка",
                            "Счетный материал", "Торговые принадлежности", "Чертежные принадлежности",
                            "Бумажная продукция", "Карты и глобусы"
                        };
                        foreach (var name in cats)
                        {
                            db.Categories.Add(new Categories { IdCategories = Guid.NewGuid(), NameCategory = name });
                        }
                        db.SaveChanges();
                    }

                    if (!db.UnitOfMeasure.Any())
                    {
                        var units = new[] {
                            "Штук", "Упаковка", "Коробка", "Лист", "Кг", "Рулон", "Комплект", "Миллилитр"
                        };
                        foreach (var name in units)
                        {
                            db.UnitOfMeasure.Add(new UnitOfMeasure { IdUnit = Guid.NewGuid(), NameUnit = name });
                        }
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                string fullError = $"Ошибка: {ex.Message}";
                if (ex.InnerException != null)
                    fullError += $"\nВнутренняя ошибка: {ex.InnerException.Message}";
                System.Diagnostics.Debug.WriteLine(fullError);

                MessageBox.Show(fullError, "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Application.Run(new StartForm());
        }
    }
}