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
    }
}
