namespace WarehouseApp.Classes
{
    /// <summary>
    /// Сервис получения погодной рекомендации для отгрузки.
    /// </summary>
    public interface IWeatherService
    {
        /// <summary>
        /// Возвращает рекомендацию по погоде для региона получателя.
        /// </summary>
        Task<string> GetRecommendationAsync(string region);
    }
}
