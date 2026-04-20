using WarehouseApp.ClassesContext;
using WarehouseApp.Enums;

namespace WarehouseApp.Classes
{
    /// <summary>
    /// статический класс для записи событий в логи
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// Записывает событие в логи
        /// </summary>
        public static void Write(string userName, string action, LogLevel level, string details)
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    db.Logs.Add(new SystemLog
                    {
                        UserName = userName,
                        Action = action,
                        Level = level,
                        Details = details
                    });
                    db.SaveChanges();
                }
            }
            catch { }
        }
        /// <summary>
        /// Записывает лог Trace
        /// </summary>
        public static void Trace(string user, string action, string msg)
        {
            Write(user, action, LogLevel.Trace, msg);
        }

        /// <summary>
        /// Записывает лог Debug 
        /// </summary>
        public static void Debug(string user, string action, string msg)
        {
            Write(user, action, LogLevel.Debug, msg);
        }
        /// <summary>
        /// Записывает лог  Info 
        /// </summary>
        public static void Info(string user, string action, string msg)
        {
            Write(user, action, LogLevel.Info, msg);
        }
        /// <summary>
        /// Записывает лог Warning
        /// </summary>
        public static void Warning(string user, string action, string msg)
        {
            Write(user, action, LogLevel.Warning, msg);
        }

        /// <summary>
        /// Записывает лог Error
        /// </summary>
        public static void Error(string user, string action, string msg)
        {
            Write(user, action, LogLevel.Error, msg);
        }
    }
}
