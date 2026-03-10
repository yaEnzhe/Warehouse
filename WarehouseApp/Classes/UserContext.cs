using System.Data.Entity;

namespace WarehouseApp.Classes
{
    public class UserContext: DbContext
    {
        public UserContext()
            : base("DbConnection")      //имя будущей строки подключения к базе данных
        {

        }

        public DbSet<User> Users { get; set; }  //набор сущностей, хранящихся в базе данных
    }
}
