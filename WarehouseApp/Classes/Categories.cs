using System;
using System.ComponentModel.DataAnnotations;

namespace WarehouseApp.Classes
{
    /// <summary>
    /// Класс категорий продуктов
    /// </summary>
    public class Categories
    {
        [Key]
        /// <summary>
        /// Уникальный идентификатор категории продукта
        /// </summary>
        public Guid IdCategories { get; set; }
        /// <summary>
        /// Название категории продукта
        /// </summary>
        public string NameCategory { get; set; }
    }
}
