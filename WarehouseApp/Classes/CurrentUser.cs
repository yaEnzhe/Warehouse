namespace WarehouseApp.Classes
{
    /// <summary>
    /// Роль пользователя текущая
    /// </summary>
    public class UserContext
    {
        /// <summary>
        /// Текущий авторизованный пользователь
        /// </summary>
        public static User Current { get; set; }

        /// <summary>
        /// Очистка данных, когда выходит из системы
        /// </summary>
        public static void Logout()
        {
            Current = null;
        }
    }
}