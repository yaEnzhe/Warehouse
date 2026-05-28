using System.Configuration;
using NLog;

namespace WarehouseApp.Classes
{
    /// <summary>
    /// Проверяет контрагента через DaData.
    /// </summary>
    public class DadataContractorCheckService : IContractorCheckService
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private const string DadataUrl = "https://suggestions.dadata.ru/suggestions/api/4_1/rs/findById/party";

        /// <summary>
        /// Проверяет контрагента через DaData.
        /// </summary>
        public async Task<ContractorCheckResult> CheckAsync(string inn, string legalStatus)
        {
            var token = ConfigurationManager.AppSettings["DadataApiToken"];
            if (string.IsNullOrWhiteSpace(token))
            {
                logger.Warn("DADATA_TOKEN_MISSING. Category: {Category}", "Api");
                return ContractorCheckResult.Error("Не указан API-ключ DaData.");
            }

            try
            {
                var type = legalStatus == "ИП" ? "INDIVIDUAL" : "LEGAL";
                var requestBody = JsonSerializer.Serialize(new
                {
                    query = inn,
                    type = type
                });

                using (var client = new HttpClient())
                using (var request = new HttpRequestMessage(HttpMethod.Post, DadataUrl))
                {
                    request.Headers.Add("Authorization", "Token " + token);
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");

                    var response = await client.SendAsync(request);
                    var json = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        logger.Warn("DADATA_REQUEST_FAILED. Category: {Category}. StatusCode: {StatusCode}", "Api", response.StatusCode);
                        return ContractorCheckResult.Error("Не удалось проверить контрагента.");
                    }

                    return ParseResult(json);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "DADATA_REQUEST_ERROR. Category: {Category}", "Api");
                return ContractorCheckResult.Error("Сервис проверки недоступен.");
            }
        }

        private ContractorCheckResult ParseResult(string json)
        {
            using (var document = JsonDocument.Parse(json))
            {
                var suggestions = document.RootElement.GetProperty("suggestions");
                if (suggestions.GetArrayLength() == 0)
                {
                    logger.Warn("DADATA_CONTRACTOR_NOT_FOUND. Category: {Category}", "Api");
                    return ContractorCheckResult.Error("Контрагент не найден.");
                }

                var item = suggestions[0];
                var name = GetString(item, "value");
                var data = item.GetProperty("data");
                var state = data.GetProperty("state");
                var status = GetString(state, "status");

                if (status == "ACTIVE")
                {
                    logger.Info("DADATA_CONTRACTOR_ACTIVE. Category: {Category}. Name: {Name}", "Api", name);
                    return ContractorCheckResult.Success($"Контрагент найден: {name}\nСтатус: действующий");
                }

                logger.Warn("DADATA_CONTRACTOR_NOT_ACTIVE. Category: {Category}. Name: {Name}. Status: {Status}", "Api", name, status);
                return ContractorCheckResult.Error($"Контрагент найден: {name}\nСтатус: {GetStatusText(status)}", true);
            }
        }

        private string GetString(JsonElement element, string propertyName)
        {
            if (!element.TryGetProperty(propertyName, out var property))
                return "";

            return property.ValueKind == JsonValueKind.String ? property.GetString() : "";
        }

        private string GetStatusText(string status)
        {
            switch (status)
            {
                case "LIQUIDATING":
                    return "ликвидируется";
                case "LIQUIDATED":
                    return "ликвидирован";
                case "REORGANIZING":
                    return "реорганизуется";
                case "BANKRUPT":
                    return "банкрот";
                default:
                    return string.IsNullOrWhiteSpace(status) ? "неизвестен" : status;
            }
        }
    }
}
