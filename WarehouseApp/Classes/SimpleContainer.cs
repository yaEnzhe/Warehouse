
namespace WarehouseApp.Classes
{
    /// <summary>
    /// Простой IoC-контейнер для регистрации и получения зависимостей.
    /// </summary>
    public class SimpleContainer
    {
        private readonly Dictionary<Type, Func<object>> registrations = new Dictionary<Type, Func<object>>();
        private readonly Dictionary<Type, object> singletons = new Dictionary<Type, object>();

        /// <summary>
        /// Регистрирует зависимость, которая создаётся при каждом запросе.
        /// </summary>
        public void AddTransient<T>(Func<T> factory)
        {
            registrations[typeof(T)] = () => factory();
        }

        /// <summary>
        /// Регистрирует зависимость, которая создаётся один раз.
        /// </summary>
        public void AddSingleton<T>(Func<T> factory)
        {
            registrations[typeof(T)] = () =>
            {
                var type = typeof(T);
                if (!singletons.ContainsKey(type))
                    singletons[type] = factory();

                return singletons[type];
            };
        }

        /// <summary>
        /// Возвращает зарегистрированную зависимость.
        /// </summary>
        public T Get<T>()
        {
            var type = typeof(T);
            if (!registrations.ContainsKey(type))
                throw new InvalidOperationException("Зависимость не зарегистрирована: " + type.Name);

            return (T)registrations[type]();
        }
    }
}
