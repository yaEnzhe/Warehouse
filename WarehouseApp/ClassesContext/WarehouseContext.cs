using System.Data.Entity;
using WarehouseApp.Classes;

namespace WarehouseApp.ClassesContext
{
    /// <summary>
    /// Класс контекста данных склада
    /// </summary>
    public class WarehouseContext : DbContext
    {
        /// <summary>
        /// конструктор класса контекста данных склада
        /// </summary>
        public WarehouseContext()
            : base("DbConnection")      //имя будущей строки подключения к базе данных
        {

        }

        /// <summary>
        /// Набор сущностей, хранящихся в базе данных
        /// </summary>
        public DbSet<User> Users { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<ShipmentContents> ShipmentContents { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<UnitOfMeasure> UnitOfMeasure { get; set; }
        public DbSet<ActionHistory> ActionHistory { get; set; }
    }
}
