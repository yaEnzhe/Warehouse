using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseApp.Classes
{
    /// <summary>
    /// Позиции товара из поставки
    /// </summary>
    [Table("SupplyItems")]
    public class SupplyItem
    {
        /// <summary>
        /// Уникальный идентификатор позиции
        /// </summary>
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// Идентификатор поставки
        /// </summary>
        public Guid SupplyId { get; set; }
        /// <summary>
        /// Идентификатор товара
        /// </summary>
        public Guid ProductId { get; set; }
        /// <summary>
        /// Количество единиц товара в позиции
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Цена закупки
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Дата окончания срока годности товара
        /// </summary>
        public DateTime ExpirationDate { get; set; }
        /// <summary>
        /// Ссылка на поставку
        /// </summary>
        [ForeignKey("SupplyId")]
        public virtual Supply Supply { get; set; }
        /// <summary>
        /// Ссылка на товар.
        /// </summary>

        [ForeignKey("ProductId")]
        public virtual Products Product { get; set; }
    }
}
