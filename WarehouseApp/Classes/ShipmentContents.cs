using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseApp.Classes
{
    /// <summary>
    /// класс состава поставки
    /// </summary>
    public class ShipmentContents
    {
        [Key]
        /// <summary>
        /// уникальный идентификатор состава поставки
        /// </summary>
        public Guid IdShipmentContents { get; set; }
        /// <summary>
        /// Колмчество товара в поставке
        /// </summary>
        public int QuantityShipmentContents { get; set; }
        /// <summary>
        /// Цена * кол-во товара
        /// </summary>
        public decimal PriceShipmentContents { get; set; }
        /// <summary>
        /// уникальный идентификатор поставки
        /// </summary>
        public Guid IdShipment { get; set; }
        /// <summary>
        /// ссылка на поставку
        /// </summary>
        [ForeignKey("IdShipment")]
        public Shipment Shipment { get; set; }
        /// <summary>
        /// уникальный идентификатор продукта
        /// </summary>
        public Guid IdProducts { get; set; }
        /// <summary>
        /// ссылка на продукт
        /// </summary>
        [ForeignKey("IdProducts")]
        public Products Product { get; set; }
    }
}

