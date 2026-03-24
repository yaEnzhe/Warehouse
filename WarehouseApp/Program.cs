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

                var thisClient = db.Clients.FirstOrDefault(client => client.NameClients == "Канцелярики");
                if (thisClient == null)
                {
                    thisClient = new Clients
                    {
                        IdClients = Guid.NewGuid(),
                        NameClients = "Канцелярики",
                    };

                    try
                    {
                        db.Clients.Add(thisClient);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        MessageBox.Show(Properties.Resources.DatabaseSavingException);
                    }
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

                    try
                    {
                        db.Shipments.Add(thisShipment);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        MessageBox.Show(Properties.Resources.DatabaseSavingException);
                    }

                }

                if (!db.Categories.Any())
                {
                    var category1 = new Categories { IdCategories = Guid.NewGuid(), NameCategory = "Письменные принадлежности" };
                    var category2 = new Categories { IdCategories = Guid.NewGuid(), NameCategory = "Офисные принадлежности" };
                    var category3 = new Categories { IdCategories = Guid.NewGuid(), NameCategory = "Рисование и лепка" };
                    var category4 = new Categories { IdCategories = Guid.NewGuid(), NameCategory = "Счетный материал" };
                    var category5 = new Categories { IdCategories = Guid.NewGuid(), NameCategory = "Торговые принадлежности" };
                    var category6 = new Categories { IdCategories = Guid.NewGuid(), NameCategory = "Чертежные принадлежности" };
                    var category7 = new Categories { IdCategories = Guid.NewGuid(), NameCategory = "Бумажная продукция" };
                    var category8 = new Categories { IdCategories = Guid.NewGuid(), NameCategory = "Карты и глобусы" };

                    try
                    {
                        db.Categories.Add(category1);
                        db.Categories.Add(category2);
                        db.Categories.Add(category3);
                        db.Categories.Add(category4);
                        db.Categories.Add(category5);
                        db.Categories.Add(category6);
                        db.Categories.Add(category7);
                        db.Categories.Add(category8);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        MessageBox.Show(Properties.Resources.DatabaseSavingException);
                    }
                }

                if (!db.UnitOfMeasure.Any())
                {
                    var unitOfMeasure1 = new UnitOfMeasure { IdUnit = Guid.NewGuid(), NameUnit = "Штук" };
                    var unitOfMeasure2 = new UnitOfMeasure { IdUnit = Guid.NewGuid(), NameUnit = "Упаковка" };
                    var unitOfMeasure3 = new UnitOfMeasure { IdUnit = Guid.NewGuid(), NameUnit = "Коробка" };
                    var unitOfMeasure4 = new UnitOfMeasure { IdUnit = Guid.NewGuid(), NameUnit = "Лист" };
                    var unitOfMeasure5 = new UnitOfMeasure { IdUnit = Guid.NewGuid(), NameUnit = "Кг" };
                    var unitOfMeasure6 = new UnitOfMeasure { IdUnit = Guid.NewGuid(), NameUnit = "Рулон" };
                    var unitOfMeasure7 = new UnitOfMeasure { IdUnit = Guid.NewGuid(), NameUnit = "Комплект" };
                    var unitOfMeasure8 = new UnitOfMeasure { IdUnit = Guid.NewGuid(), NameUnit = "Миллилитр" };

                    try
                    {
                        db.UnitOfMeasure.Add(unitOfMeasure1);
                        db.UnitOfMeasure.Add(unitOfMeasure2);
                        db.UnitOfMeasure.Add(unitOfMeasure3);
                        db.UnitOfMeasure.Add(unitOfMeasure4);
                        db.UnitOfMeasure.Add(unitOfMeasure5);
                        db.UnitOfMeasure.Add(unitOfMeasure6);
                        db.UnitOfMeasure.Add(unitOfMeasure7);
                        db.UnitOfMeasure.Add(unitOfMeasure8);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        MessageBox.Show(Properties.Resources.DatabaseSavingException);
                    }
                }

                if (!db.Products.Any())
                {
                    var product1 = new Products
                    {
                        IdProducts = Guid.NewGuid(),
                        Article = Guid.NewGuid(),
                        NameProduct = "Линейка",
                        Price = 100,
                        Stock = 300,
                        IdCategories = db.Categories.FirstOrDefault(category => category.NameCategory == "Чертежные принадлежности").IdCategories,
                        IdUnitOfMeasure = db.UnitOfMeasure.FirstOrDefault(unit => unit.NameUnit == "Штук").IdUnit
                    };

                    try
                    {
                        db.Products.Add(product1);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        MessageBox.Show(Properties.Resources.DatabaseSavingException);
                    }
                }

                if (!db.ShipmentContents.Any())
                {
                    var shipmentContent1 = new ShipmentContents { IdShipmentContents = Guid.NewGuid(), QuantityShipmentContents = 250, PriceShipmentContents = 25000, IdShipment = thisShipment.IdShipment, IdProducts = db.Products.FirstOrDefault(product => product.NameProduct == "Линейка").IdProducts };

                    try
                    {
                        db.ShipmentContents.Add(shipmentContent1);
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
            Application.Run(new StartForm());
        }
    }
}
