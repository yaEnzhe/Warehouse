using System;
using System.ComponentModel.DataAnnotations;

namespace WarehouseApp.Classes
{
    /// <summary>
    /// Класс клиентов
    /// </summary>
    public class Clients
    {
        /// <summary>
        /// Уникальный идентификатор клиента
        /// </summary>
        [Key]
        public Guid IdClients { get; set; }
        /// <summary>
        /// Имя(название) клиента
        /// </summary>
        public string NameClients { get; set; }
    }
}
