namespace WarehouseApp.Classes
{
    /// <summary>
    /// Даёт доступ к зарегистрированным зависимостям приложения.
    /// </summary>
    public static class AppServices
    {
        private static SimpleContainer container;

        /// <summary>
        /// Сохраняет контейнер зависимостей для приложения.
        /// </summary>
        public static void Configure(SimpleContainer appContainer)
        {
            container = appContainer;
        }

        /// <summary>
        /// Возвращает зарегистрированную зависимость нужного типа.
        /// </summary>
        public static T Get<T>()
        {
            if (container == null)
            {
                var defaultContainer = new SimpleContainer();
                defaultContainer.AddSingleton<IContractorCheckService>(() => new DadataContractorCheckService());
                defaultContainer.AddSingleton<ICurrencyRateService>(() => new CurrencyRateService());
                defaultContainer.AddSingleton<IWeatherService>(() => new OpenWeatherMapService());
                container = defaultContainer;
            }

            return container.Get<T>();
        }
    }
}
