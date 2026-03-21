using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseApp.Enums;

namespace WarehouseApp.Classes
{
    /// <summary>
    /// Класс поставки
    /// </summary>
    public class Shipment
    {
        /// <summary>
        /// Уникальный идентификатор поставки
        /// </summary>
        [Key]
        public Guid IdShipment { get; set; }
        /// <summary>
        /// Дата поставки
        /// </summary>
        public DateTime DateOfShipment { get; set; }
        /// <summary>
        /// Стоимость поставки
        /// </summary>
        public Decimal PriceShipment { get; set; }
        /// <summary>
        /// статус поставки
        /// </summary>
        public ShipmentStatus Status { get; set; }
        /// <summary>
        /// Уникальный идентификатор клиента
        /// </summary>
        public Guid IdClients { get; set; }
        [ForeignKey("IdClients")]
        public Clients Clients { get; set; }
    }
}