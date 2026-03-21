using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseApp.Classes
{
    /// <summary>
    /// Класс истории действий
    /// </summary>
    public class ActionHistory
    {
        /// <summary>
        /// Уникальный идентификатор действия
        /// </summary>
        [Key]
        public Guid IdAction { get; set; }
        /// <summary>
        /// Дата действия
        /// </summary>
        public DateTime EventData { get; set; }
        /// <summary>
        /// Действие
        /// </summary>
        public string Action { get; set; }
        /// <summary>
        /// Подробнее о действии
        /// </summary>
        public string Details { get; set; }
        /// <summary>
        /// Уникальный идентификатор пользователя
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Ссылка на пользователя, совершившего действие
        /// </summary>
        [ForeignKey("Id")]
        public User User { get; set; }
    }
}

