using WarehouseApp.Enums;
using System;

namespace WarehouseApp.Classes
{
    /// <summary>
    /// Класс пользователя системы
    /// </summary>
    public class User
    {
        /// <summary>
        /// Уникальный идентификатор пользователя
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Отчество пользователя (при наличии)
        /// </summary>
        public string Patronymic { get; set; }
        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Статическое свойство для хранения текущего авторизованного пользователя
        /// </summary>
        public static User CurrentUser { get; set; }
        /// <summary>
        /// Хэшированный пароль пользователя
        /// </summary>
        public string HashPassword { get; private set; }
        /// <summary>
        /// Роль пользователя в системе (администратор либо кладовщик)
        /// </summary>
        public Roles Role { get; set; }
        /// <summary>
        /// Дата регистрации пользователя
        /// </summary>
        public DateTime DateOfRegistration { get; set; }

        /// <summary>
        /// Метод для хэширования и установки паролей
        /// </summary>
        /// <param name="user"> пользователь </param> 
        /// <param name="text"> пароль заданный пользователем </param>
        public void HashPasswordBCrypt(User user, string text)
        {
            user.HashPassword = BCrypt.Net.BCrypt.HashPassword(text);
        }

        /// <summary>
        /// Метод для проверки пароля
        /// </summary>
        /// <param name="user"> пользователь </param>
        /// <param name="text"> пароль указанный пользователем </param>
        /// <returns></returns>
        public bool CheckPassword(User user, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, user.HashPassword);
        }
    }
}
