using System.Data.Entity;

namespace WarehouseApp.Classes
{
    /// <summary>
    /// Класс контекста данных для пользователей
    /// </summary>
    public class UserContext: DbContext
    {
        /// <summary>
        /// конструктор класса контекста данных для пользователей
        /// </summary>
        public UserContext()
            : base("DbConnection")      //имя будущей строки подключения к базе данных
        {

        }
        /// <summary>
        /// Набор сущностей(пользователей), хранящихся в базе данных
        /// </summary>
        public DbSet<User> Users { get; set; } 
    }
}
