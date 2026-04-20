using System;
using WarehouseApp.Enums;

namespace WarehouseApp.Classes
{
    /// <summary>
    /// Запись всех событий 
    /// </summary>
    public class SystemLog
    {
        /// <summary>
        /// Уникальный идентификатор лога
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();
        /// <summary>
        /// Когда произошло событие
        /// </summary>
        public DateTime Timestamp { get; set; } = DateTime.Now;
        /// <summary>
        /// Имя пользователя, который совершил действие
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Важности события
        /// </summary>
        public LogLevel Level { get; set; }
        /// <summary>
        /// Название действия
        /// </summary>
        public string Action { get; set; }
        /// <summary>
        /// Описание деталий
        /// </summary>
        public string Details { get; set; } 
    }
}
