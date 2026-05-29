
using NLog;

namespace WarehouseApp.Classes
{
    /// <summary>
    /// Получает курс валюты через внешний API.
    /// </summary>
    public class CurrencyRateService : ICurrencyRateService
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private const string CurrencyUrl = "https://www.cbr-xml-daily.ru/daily_json.js";

        /// <summary>
        /// Получает курс выбранной валюты через внешний сервис.
        /// </summary>
        public async Task<decimal> GetRateAsync(string currencyCode)
        {
            if (currencyCode == "RUB")
                return 1.0m;

            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.UserAgent.ParseAdd("WarehouseApp");
                    var json = await client.GetStringAsync(CurrencyUrl);

                    using (var doc = JsonDocument.Parse(json))
                    {
                        if (doc.RootElement.TryGetProperty("Valute", out var valute) &&
                            valute.TryGetProperty(currencyCode, out var currency) &&
                            currency.TryGetProperty("Nominal", out var nominalElement) &&
                            currency.TryGetProperty("Value", out var valueElement))
                        {
                            var nominal = nominalElement.GetDecimal();
                            var rate = valueElement.GetDecimal() / nominal;
                            logger.Info("CURRENCY_RATE_RECEIVED. Category: {Category}. Currency: {Currency}", "Api", currencyCode);
                            return rate;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "CURRENCY_RATE_ERROR. Category: {Category}. Currency: {Currency}", "Api", currencyCode);
            }

            logger.Warn("CURRENCY_RATE_DEFAULT_USED. Category: {Category}. Currency: {Currency}", "Api", currencyCode);
            return 0m;
        }
    }
}
