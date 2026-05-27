
namespace WarehouseApp.Classes
{
    /// <summary>
    /// Сервис получения курса валюты.
    /// </summary>
    public interface ICurrencyRateService
    {
        /// <summary>
        /// Получает курс выбранной валюты к рублю.
        /// </summary>
        Task<decimal> GetRateAsync(string currencyCode);
    }
}
