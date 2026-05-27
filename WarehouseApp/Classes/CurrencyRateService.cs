
namespace WarehouseApp.Classes
{
    /// <summary>
    /// Получает курс валюты через внешний API.
    /// </summary>
    public class CurrencyRateService : ICurrencyRateService
    {
        private const string CurrencyUrl = "https://www.cbr-xml-daily.ru/daily_json.js";

        /// <summary>
        /// Получает курс выбранной валюты через внешний сервис.
        /// </summary>
        public async Task<decimal> GetRateAsync(string currencyCode)
        {
            if (currencyCode == "RUB")
                return 1.0m;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd("WarehouseApp");
                var json = await client.GetStringAsync(CurrencyUrl);

                using (var doc = JsonDocument.Parse(json))
                {
                    if (doc.RootElement.TryGetProperty("Valute", out var valute) &&
                        valute.TryGetProperty(currencyCode, out var currency) &&
                        currency.TryGetProperty("Value", out var valueElement))
                    {
                        return valueElement.GetDecimal();
                    }
                }
            }

            return 1.0m;
        }
    }
}
