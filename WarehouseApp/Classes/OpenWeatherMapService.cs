using System.Configuration;
using NLog;

namespace WarehouseApp.Classes
{
    /// <summary>
    /// Получает прогноз погоды через OpenWeatherMap.
    /// </summary>
    public class OpenWeatherMapService : IWeatherService
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private const string ForecastUrl = "https://api.openweathermap.org/data/2.5/forecast";

        /// <summary>
        /// Возвращает рекомендацию по температуре через два дня.
        /// </summary>
        public async Task<string> GetRecommendationAsync(string region)
        {
            var token = ConfigurationManager.AppSettings["OpenWeatherApiToken"];
            if (string.IsNullOrWhiteSpace(token))
            {
                logger.Warn("WEATHER_TOKEN_MISSING. Category: {Category}", "Api");
                return "Прогноз погоды временно недоступен";
            }

            try
            {
                var city = Uri.EscapeDataString(GetCityForApi(region));
                var url = $"{ForecastUrl}?q={city}&appid={token}&units=metric&lang=ru";

                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        logger.Warn("WEATHER_REGION_NOT_FOUND. Category: {Category}. Region: {Region}", "Api", region);
                        return "Указанный регион не найден. Проверьте правильность названия";
                    }

                    if (!response.IsSuccessStatusCode)
                    {
                        logger.Warn("WEATHER_REQUEST_FAILED. Category: {Category}. StatusCode: {StatusCode}", "Api", response.StatusCode);
                        return "Прогноз погоды временно недоступен";
                    }

                    var json = await response.Content.ReadAsStringAsync();
                    var recommendation = GetRecommendationFromJson(json);
                    logger.Info("WEATHER_RECOMMENDATION_RECEIVED. Category: {Category}. Region: {Region}. Recommendation: {Recommendation}", "Api", region, recommendation);
                    return recommendation;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "WEATHER_REQUEST_ERROR. Category: {Category}. Region: {Region}", "Api", region);
                return "Прогноз погоды временно недоступен";
            }
        }

        private string GetCityForApi(string region)
        {
            switch (region)
            {
                case "Москва":
                    return "Moscow,RU";
                case "Санкт-Петербург":
                    return "Saint Petersburg,RU";
                case "Казань":
                    return "Kazan,RU";
                case "Нижний Новгород":
                    return "Nizhny Novgorod,RU";
                case "Самара":
                    return "Samara,RU";
                default:
                    return region + ",RU";
            }
        }

        private string GetRecommendationFromJson(string json)
        {
            using (var document = JsonDocument.Parse(json))
            {
                var targetDate = DateTime.Today.AddDays(2).Date;
                var minTemp = decimal.MaxValue;
                var maxTemp = decimal.MinValue;

                foreach (var item in document.RootElement.GetProperty("list").EnumerateArray())
                {
                    var forecastDate = DateTime.Parse(item.GetProperty("dt_txt").GetString()).Date;
                    if (forecastDate != targetDate)
                        continue;

                    var main = item.GetProperty("main");
                    var tempMin = main.GetProperty("temp_min").GetDecimal();
                    var tempMax = main.GetProperty("temp_max").GetDecimal();

                    if (tempMin < minTemp)
                        minTemp = tempMin;

                    if (tempMax > maxTemp)
                        maxTemp = tempMax;
                }

                if (minTemp == decimal.MaxValue || maxTemp == decimal.MinValue)
                    return "Прогноз погоды временно недоступен";

                if (minTemp < -20)
                    return "Рекомендуется термоконтейнер";

                if (maxTemp > 30)
                    return "Рекомендуется страховка груза";

                return "Погодные условия в норме";
            }
        }
    }
}
