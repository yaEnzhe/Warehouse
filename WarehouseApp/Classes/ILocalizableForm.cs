namespace WarehouseApp.Classes
{
    /// <summary>
    /// Форма, которая умеет обновлять тексты при смене языка.
    /// </summary>
    public interface ILocalizableForm
    {
        /// <summary>
        /// Обновляет текстовые элементы формы.
        /// </summary>
        void ApplyLocalization();
    }
}
