
using NLog;

namespace WarehouseApp
{
    internal static class Program
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        [STAThread]
        static void Main()
        {
            try
            {
                logger.Info("APPLICATION_START. Category: {Category}", "System");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<WarehouseContext, Configuration>());

                InitializeDatabase();
                ConfigureServices();
                LoadLanguageSettings();
                LoadCurrencySettings();
                Application.Run(AppServices.Get<LoginForm>());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "APPLICATION_START_ERROR. Category: {Category}", "System");
                MessageBox.Show($"{Properties.Resources.StartupError}\n\n{ex.Message}");
            }
        }
        /// <summary>
        /// Первые данные
        /// </summary>
        static void InitializeDatabase()
        {
            using (var db = new WarehouseContext())
            {
                var thisUser = db.Users.FirstOrDefault(user => user.Role == Roles.Administrator);
                if (thisUser == null)
                {
                    var administrator = new User
                    {
                        Id = Guid.NewGuid(),
                        Name = "Иван",
                        Surname = "Иванов",
                        Patronymic = "Иванович",
                        Login = "admin",
                        Role = Roles.Administrator,
                        DateOfRegistration = DateTime.Now
                    };
                    var adminPassword = "admin666";
                    Password.HashPasswordBCrypt(administrator, adminPassword);
                    db.Users.Add(administrator);
                    db.SaveChanges();
                    logger.Info("DEFAULT_ADMIN_CREATED. Category: {Category}", "System");
                }

                // Клиент
                var thisClient = db.Clients.FirstOrDefault(client => client.NameClients == "Канцелярики");
                if (thisClient == null)
                {
                    thisClient = new Clients
                    {
                        IdClients = Guid.NewGuid(),
                        NameClients = "Канцелярики",
                    };
                    db.Clients.Add(thisClient);
                    db.SaveChanges();
                    logger.Info("DEFAULT_CLIENT_CREATED. Category: {Category}", "System");
                }

                // Категории
                if (!db.Categories.Any())
                {
                    var cats = new[] {
                        "Письменные принадлежности", "Офисные принадлежности", "Рисование и лепка",
                        "Счетный материал", "Торговые принадлежности", "Чертежные принадлежности",
                        "Бумажная продукция", "Карты и глобусы"
                    };
                    foreach (var name in cats)
                    {
                        db.Categories.Add(new Categories { IdCategories = Guid.NewGuid(), NameCategory = name });
                    }
                    db.SaveChanges();
                    logger.Info("DEFAULT_CATEGORIES_CREATED. Category: {Category}", "System");
                }

                // Единицы измерения
                if (!db.UnitOfMeasure.Any())
                {
                    var units = new[] {
                        "Штук", "Упаковка", "Коробка", "Лист", "Кг", "Рулон", "Комплект", "Миллилитр"
                    };
                    foreach (var name in units)
                    {
                        db.UnitOfMeasure.Add(new UnitOfMeasure { IdUnit = Guid.NewGuid(), NameUnit = name });
                    }
                    db.SaveChanges();
                    logger.Info("DEFAULT_UNITS_CREATED. Category: {Category}", "System");
                }
            }
        }

        /// <summary>
        /// Регистрирует зависимости приложения.
        /// </summary>
        static void ConfigureServices()
        {
            var container = new SimpleContainer();

            container.AddSingleton<IContractorCheckService>(() => new DadataContractorCheckService());
            container.AddSingleton<ICurrencyRateService>(() => new CurrencyRateService());
            container.AddSingleton<IWeatherService>(() => new OpenWeatherMapService());

            container.AddTransient(() => new LoginForm());
            container.AddTransient(() => new RegistrationForm());
            container.AddTransient(() => new MainMenuAdminForm());
            container.AddTransient(() => new MainMenuStorekeeperForm());
            container.AddTransient(() => new CatalogAdminForm());
            container.AddTransient<Func<bool, CatalogAdminForm>>(() => readOnly => new CatalogAdminForm(readOnly));
            container.AddTransient(() => new ShipmentFormAdmin(AppServices.Get<IWeatherService>()));
            container.AddTransient(() => new ShipmentFormStorekeeper(AppServices.Get<IWeatherService>()));
            container.AddTransient(() => new ChangesAdmin());
            container.AddTransient(() => new Options(AppServices.Get<ICurrencyRateService>()));
            container.AddTransient(() => new Supplies());
            container.AddTransient(() => new DeliveryHistory());
            container.AddTransient<Func<Guid, ContentsOfSupplies>>(() => supplyId => new ContentsOfSupplies(supplyId));
            container.AddTransient(() => new WarehouseMapForm());
            container.AddTransient(() => new ContractorCheckForm(AppServices.Get<IContractorCheckService>()));

            AppServices.Configure(container);
        }

        /// <summary>
        /// Загружает сохраненный язык интерфейса.
        /// </summary>
        public static void LoadLanguageSettings()
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    var languageSetting = db.AppSettings.FirstOrDefault(s => s.Key == "Language");
                    LanguageManager.SetLanguage(languageSetting?.Value ?? "RUS");
                    logger.Info("LANGUAGE_LOADED. Category: {Category}. Language: {Language}", "System", LanguageManager.CurrentLanguage);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "LANGUAGE_LOAD_ERROR. Category: {Category}", "System");
                LanguageManager.SetLanguage("RUS");
            }
        }

        /// <summary>
        /// Загружает валюту и курс
        /// </summary>
        public static void LoadCurrencySettings()
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    var currencySetting = db.AppSettings.FirstOrDefault(s => s.Key == "Currency");
                    var exchangeRateSetting = db.AppSettings.FirstOrDefault(s => s.Key == "ExchangeRate");
                    var exchangeRateCurrencySetting = db.AppSettings.FirstOrDefault(s => s.Key == "ExchangeRateCurrency");

                    var currency = currencySetting?.Value ?? "RUB";
                    Options.CurrentCurrency = currency;

                    if (currency != "RUB")
                    {
                        if (exchangeRateSetting != null &&
                            exchangeRateCurrencySetting?.Value == currency &&
                            decimal.TryParse(exchangeRateSetting.Value, out decimal savedRate))
                        {
                            Options.CurrentExchangeRate = savedRate;
                        }
                        else
                        {
                            Options.CurrentExchangeRate = new CurrencyRateService()
                                .GetRateAsync(currency)
                                .GetAwaiter()
                                .GetResult();

                            if (Options.CurrentExchangeRate <= 0)
                                Options.CurrentExchangeRate = 1.0m;

                            if (exchangeRateSetting == null)
                            {
                                db.AppSettings.Add(new AppSetting
                                {
                                    Id = Guid.NewGuid(),
                                    Key = "ExchangeRate",
                                    Value = Options.CurrentExchangeRate.ToString()
                                });
                            }
                            else
                            {
                                exchangeRateSetting.Value = Options.CurrentExchangeRate.ToString();
                            }

                            if (exchangeRateCurrencySetting == null)
                            {
                                db.AppSettings.Add(new AppSetting
                                {
                                    Id = Guid.NewGuid(),
                                    Key = "ExchangeRateCurrency",
                                    Value = currency
                                });
                            }
                            else
                            {
                                exchangeRateCurrencySetting.Value = currency;
                            }

                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        Options.CurrentExchangeRate = 1.0m;
                    }

                    logger.Info("CURRENCY_SETTINGS_LOADED. Category: {Category}. Currency: {Currency}", "System", Options.CurrentCurrency);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "CURRENCY_SETTINGS_LOAD_ERROR. Category: {Category}", "System");
                Options.CurrentExchangeRate = 1.0m;
                Options.CurrentCurrency = "RUB";
            }
        }
    }
}
