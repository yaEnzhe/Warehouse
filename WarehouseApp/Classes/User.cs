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
        /// Хэшированный пароль пользователя
        /// </summary>
        public string HashPassword { get; set; }
        /// <summary>
        /// Роль пользователя в системе (администратор либо кладовщик)
        /// </summary>
        public Roles Role { get; set; }
        /// <summary>
        /// Дата регистрации пользователя
        /// </summary>
        public DateTime DateOfRegistration { get; set; }
    }
}
