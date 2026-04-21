using System.Data.Entity;
using WarehouseApp.Classes;
using System.Linq;

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
        public DbSet<SystemLog> Logs { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<SupplyItem> SupplyItems { get; set; }
        public DbSet<AppSetting> AppSettings { get; set; }

        /// <summary>
        /// Генерирует следующий артикул
        /// </summary>
        public string GenerateNextArticle()
        {
            var articlesFromDb = this.Products
                .Where(p => p.Article != null && p.Article.StartsWith("ART"))
                .Select(p => p.Article)
                .ToList();

            int maxNumber = 0;
            foreach (var article in articlesFromDb)
            {
                if (article.Length > 3)
                {
                    var numberPart = article.Substring(3);
                    if (int.TryParse(numberPart, out int currentNum))
                    {
                        if (currentNum > maxNumber)
                        {
                            maxNumber = currentNum;
                        }
                    }
                }
            }
            return $"ART{maxNumber + 1}";
        }
    }
}

    
