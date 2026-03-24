using System;
using System.ComponentModel.DataAnnotations;

namespace WarehouseApp.Classes
{
    /// <summary>
    /// Класс единиц измерения
    /// </summary>
    public class UnitOfMeasure
    {
        [Key]
        /// <summary>
        /// Уникальный идентификатор единицы измерения
        /// </summary>
        public Guid IdUnit { get; set; }
        /// <summary>
        /// Название единицы измерения
        /// </summary>
        public string NameUnit { get; set; }
    }
}

