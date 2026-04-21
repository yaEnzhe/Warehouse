using System;

namespace WarehouseApp.Classes
{
    /// <summary>
    /// Класс для хранения настроек в базе данных
    /// </summary>
    public class AppSetting
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Ключ настройки
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Значение настройки
        /// </summary>
        public string Value { get; set; }
    }
}
