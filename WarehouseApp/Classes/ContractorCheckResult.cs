namespace WarehouseApp.Classes
{
    /// <summary>
    /// Результат проверки контрагента.
    /// </summary>
    public class ContractorCheckResult
    {
        /// <summary>
        /// Признак успешной проверки.
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Текст результата для пользователя.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Нужно ли запрещать поставку или отгрузку после проверки.
        /// </summary>
        public bool ShouldBlockOperation { get; set; }

        /// <summary>
        /// Создаёт успешный результат проверки.
        /// </summary>
        public static ContractorCheckResult Success(string message)
        {
            return new ContractorCheckResult
            {
                IsSuccess = true,
                Message = message,
                ShouldBlockOperation = false
            };
        }

        /// <summary>
        /// Создаёт результат с ошибкой проверки.
        /// </summary>
        public static ContractorCheckResult Error(string message, bool shouldBlockOperation = false)
        {
            return new ContractorCheckResult
            {
                IsSuccess = false,
                Message = message,
                ShouldBlockOperation = shouldBlockOperation
            };
        }
    }
}
