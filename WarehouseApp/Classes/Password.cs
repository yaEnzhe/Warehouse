namespace WarehouseApp.Classes
{
    /// <summary>
    /// Класс для хэширования и проверки паролей
    /// </summary>
    public static class Password
    {
        /// <summary>
        /// Метод для хэширования и установки паролей
        /// </summary>
        /// <param name="user"> пользователь </param> 
        /// <param name="text"> пароль заданный пользователем </param>
        public static void HashPasswordBCrypt(User user, string text)
        {
            user.HashPassword = BCrypt.Net.BCrypt.HashPassword(text);
        }

        /// <summary>
        /// Метод для проверки пароля
        /// </summary>
        /// <param name="user"> пользователь </param>
        /// <param name="text"> пароль указанный пользователем </param>
        /// <returns></returns>
        public static bool CheckPassword(User user, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, user.HashPassword);
        }
    }
}
        
