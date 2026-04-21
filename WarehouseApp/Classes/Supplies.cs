using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseApp.Classes
{
    /// <summary>
    /// Поставки
    /// </summary>
    [Table("Supplies")]
    public class Supply
    {
        /// <summary>
        /// Уникальный идентификатор поставки
        /// </summary>
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// Дата проведения поставки
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Идентификатор, оформившего поставку.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Список товаров в данной поставке
        /// </summary>
        public virtual ICollection<SupplyItem> SupplyItems { get; set; }
    }
}
