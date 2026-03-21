using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseApp.Classes
{
    /// <summary>
    /// класс продуктов
    /// </summary>
    public class Products
    {
        [Key]
        /// <summary>
        /// уникальный идентификатор продукта
        /// </summary>
        public Guid IdProducts { get; set; }
        /// <summary>
        /// артикул продукта
        /// </summary>
        public Guid Article { get; set; }
        /// <summary>
        /// название продукта
        /// </summary>
        public string NameProduct { get; set; }
        /// <summary>
        /// цена за единицу продукта
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Сколько товара осталось на складе
        /// </summary>
        public decimal Stock { get; set; }
        /// <summary>
        /// уникальный идентификатор категории продукта
        /// </summary>
        public Guid IdCategories { get; set; }
        /// <summary>
        /// Ссылка на категорию
        /// </summary>
        [ForeignKey("IdCategories")]
        public Categories Category { get; set; }
        /// <summary>
        /// уникальный идентификатор единицы измерения продукта
        /// </summary>
        public Guid IdUnitOfMeasure { get; set; }
        /// <summary>
        /// ссылка на единицу измерения
        /// </summary>
        [ForeignKey("IdUnitOfMeasure")]
        public UnitOfMeasure UnitOfMeasure { get; set; }
    }
}
