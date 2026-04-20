namespace WarehouseApp.Enums
{
    /// <summary>
    /// Уровни важности логов
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// Максимально детальная информация
        /// </summary>
        Trace,
        /// <summary>
        /// Debug - диагностические сообщения
        Debug,
        /// <summary>
        /// Info -  сообщения о штатной работе приложения
        /// </summary>
        Info,
        /// <summary>
        /// Warning - потенциальные проблемы, которые не блокируют работу,но требуют внимания
        /// </summary>
        Warning,
        /// <summary>
        /// Error - критические сбои
        /// </summary>
        Error
    }
}
