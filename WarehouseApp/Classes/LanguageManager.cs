using NLog;

namespace WarehouseApp.Classes
{
    /// <summary>
    /// Управляет текущим языком интерфейса.
    /// </summary>
    public static class LanguageManager
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Текущий язык интерфейса.
        /// </summary>
        public static string CurrentLanguage { get; private set; } = "RUS";

        /// <summary>
        /// Устанавливает текущий язык.
        /// </summary>
        public static void SetLanguage(string language)
        {
            CurrentLanguage = language == "ENG" ? "ENG" : "RUS";
        }

        /// <summary>
        /// Сохраняет выбранный язык в базе данных.
        /// </summary>
        public static void SaveLanguage(string language)
        {
            SetLanguage(language);

            using (var db = new WarehouseContext())
            {
                var setting = db.AppSettings.FirstOrDefault(s => s.Key == "Language");
                if (setting == null)
                {
                    db.AppSettings.Add(new AppSetting
                    {
                        Id = Guid.NewGuid(),
                        Key = "Language",
                        Value = CurrentLanguage
                    });
                }
                else
                {
                    setting.Value = CurrentLanguage;
                }

                db.SaveChanges();
            }

            logger.Info("LANGUAGE_CHANGED. Category: {Category}. Language: {Language}", "System", CurrentLanguage);
        }

        /// <summary>
        /// Возвращает текст по ключу для текущего языка.
        /// </summary>
        public static string Text(string key)
        {
            if (CurrentLanguage == "ENG")
                return EnglishText(key);

            return RussianText(key);
        }

        /// <summary>
        /// Обновляет тексты всех открытых форм.
        /// </summary>
        public static void ApplyToOpenForms()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is ILocalizableForm localizableForm)
                    localizableForm.ApplyLocalization();
                else
                    ApplyControls(form);
            }
        }

        /// <summary>
        /// Обновляет тексты известных элементов формы.
        /// </summary>
        public static void ApplyControls(Form form)
        {
            ApplyControlText(form, form);
        }

        private static void ApplyControlText(Form form, Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                var text = GetDynamicText(control.Name) ?? GetControlText(form.GetType().Name, control.Name);
                if (text != null)
                    control.Text = text;

                if (control.Controls.Count > 0)
                    ApplyControlText(form, control);
            }
        }

        private static string GetDynamicText(string controlName)
        {
            if (controlName == "txtDate" || controlName == "lblDate")
                return Text("DatePrefix") + DateTime.Now.ToString("dd.MM.yyyy");

            if (UserContext.Current == null)
                return null;

            if (controlName == "txtWelcome")
                return Text("Welcome") + UserDisplayHelper.GetShortName(UserContext.Current);

            if (controlName == "labelAdmin" || controlName == "labelStorekeeper")
                return UserDisplayHelper.GetRoleName(UserContext.Current.Role);

            if (controlName == "lblUserRole")
                return Text("YourRole") + " " + UserDisplayHelper.GetRoleName(UserContext.Current.Role);

            return null;
        }

        private static string GetControlText(string formName, string controlName)
        {
            var key = formName + "." + controlName;
            switch (key)
            {
                case "MainMenuAdminForm.labelHeadline":
                case "MainMenuStorekeeperForm.labelHeadline":
                    return Text("AppTitle");
                case "MainMenuAdminForm.btnExit":
                case "MainMenuStorekeeperForm.btnExit":
                    return Text("Exit");
                case "MainMenuAdminForm.btnProducts":
                case "MainMenuStorekeeperForm.btnProducts":
                    return Text("Products");
                case "MainMenuAdminForm.btnPostavki":
                case "MainMenuStorekeeperForm.btnPostavki":
                    return Text("Supplies");
                case "MainMenuAdminForm.btnWarehouseMap":
                case "MainMenuStorekeeperForm.btnWarehouseMap":
                    return Text("WarehouseMap");
                case "MainMenuAdminForm.labelYourRole":
                case "MainMenuStorekeeperForm.labelYourRole":
                    return Text("YourRole");
                case "MainMenuAdminForm.btnActionHistory":
                    return Text("Reports");
                case "MainMenuAdminForm.btnParametr":
                case "Options.labelPar":
                    return Text("Settings");
                case "MainMenuStorekeeperForm.btnShipment":
                    return Text("Shipments");
                case "MainMenuStorekeeperForm.label1":
                case "Options.lblValuta":
                    return Text("Currency");
                case "MainMenuStorekeeperForm.lblLanguage":
                case "Options.lblLanguage":
                    return Text("Language");
                case "Options.lblSale":
                    return Text("Discount");
                case "Options.btnClose":
                    return Text("Close");
                case "Options.btnSave":
                    return Text("Save");
                case "StartForm.labelHeadline":
                case "LoginForm.txtWarehouseHeadline":
                    return Text("AppTitleUpper");
                case "StartForm.btnStart":
                    return Text("StartWork");
                case "LoginForm.txtLoginHeadline":
                case "RegistrationForm.txtLoginHeadline":
                    return Text("EnterLogin");
                case "LoginForm.txtPasswordHeadline":
                case "RegistrationForm.txtPasswordHeadline":
                    return Text("EnterPassword");
                case "LoginForm.btnLogin":
                    return Text("Login");
                case "LoginForm.btnRegistration":
                case "RegistrationForm.btnRegistration":
                    return Text("Registration");
                case "RegistrationForm.txtNameHeadline":
                    return Text("EnterName");
                case "RegistrationForm.txtSurnameHeadline":
                    return Text("EnterSurname");
                case "RegistrationForm.txtPatronymicHeadline":
                    return Text("EnterPatronymic");
                case "RegistrationForm.btnBack":
                case "CatalogAdminForm.buttonForBack":
                case "CatalogStorekeeperForm.buttonForBack":
                case "ChangesAdmin.buttonForBack":
                case "ContractorCheckForm.btnBack":
                case "ContentsOfSupplies.buttonToBack":
                case "InputCategoryForm.btnClose":
                case "WarehouseMapForm.btnBack":
                    return controlName == "btnClose" ? Text("Close") : Text("Back");
                case "CatalogAdminForm.labelTop":
                case "CatalogStorekeeperForm.labelTop":
                    return Text("ProductCatalog");
                case "CatalogAdminForm.buttonForDelete":
                    return Text("Delete");
                case "CatalogAdminForm.buttonForEdit":
                    return Text("Edit");
                case "CatalogAdminForm.labelSearch":
                case "CatalogStorekeeperForm.labelSearch":
                    return Text("Search");
                case "CatalogAdminForm.lblCategoria":
                case "CatalogStorekeeperForm.lblCategoria":
                case "ChangesAdmin.lblCategoria":
                    return Text("Category");
                case "CatalogAdminForm.lblStatus":
                case "CatalogStorekeeperForm.lblStatus":
                    return Text("Status");
                case "ChangesAdmin.label1":
                    return Text("Reports");
                case "ChangesAdmin.labelPeriod":
                    return Text("Period");
                case "ChangesAdmin.label2":
                    return Text("Customer");
                case "ChangesAdmin.label4":
                    return Text("From");
                case "ChangesAdmin.label5":
                    return Text("To");
                case "ChangesAdmin.btnPoisk":
                    return Text("Find");
                case "ChangesAdmin.button1":
                    return Text("Export");
                case "ContractorCheckForm.lblTitle":
                    return Text("ContractorCheck");
                case "ContractorCheckForm.lblLegalStatus":
                    return Text("LegalStatus");
                case "ContractorCheckForm.lblInn":
                    return Text("Inn");
                case "ContractorCheckForm.btnCheck":
                    return Text("Check");
                case "ContentsOfSupplies.lblTitle":
                case "ContentsOfSupplies.labelToShipment":
                    return Text("SupplyContents");
                case "ContentsOfSupplies.label1":
                    return Text("DateLabel");
                case "InputCategoryForm.label1":
                    return Text("CategoryName");
                case "InputCategoryForm.btnOk":
                    return "OK";
                case "WarehouseMapForm.lblTitle":
                    return Text("HeatMap");
                case "WarehouseMapForm.lblSort":
                    return Text("SortBy");
                case "WarehouseMapForm.lblLegendTitle":
                    return Text("Legend");
                case "Supplies.labelToShipment":
                case "DeliveryHistory.labelToShipment":
                    return Text("Supplies");
                case "Supplies.buttonToBack":
                case "DeliveryHistory.buttonToBack":
                case "ShipmentFormAdmin.buttonToBack":
                case "ShipmentFormStorekeeper.buttonToBack":
                    return Text("Back");
                case "Supplies.labelYourRole":
                case "DeliveryHistory.labelYourRole":
                    return Text("YourRole");
                case "Supplies.buttonToAddInTable":
                case "DeliveryHistory.buttonToAddInTable":
                    return Text("NewSupply");
                case "Supplies.button1":
                    return Text("ImportFromFile");
                case "Supplies.btnhistori":
                case "Supplies.btnHistory":
                case "DeliveryHistory.button2":
                    return Text("SupplyHistory");
                case "Supplies.label1":
                    return Text("Product");
                case "Supplies.label2":
                    return Text("Quantity");
                case "Supplies.label3":
                    return Text("ExpirationDate");
                case "Supplies.label4":
                    return Text("PurchasePrice");
                case "Supplies.btnAddToSupply":
                    return Text("AddToSupply");
                case "Supplies.button3":
                    return Text("ProcessSupply");
                case "Supplies.btnCheckContractor":
                case "ShipmentFormAdmin.btnCheckContractor":
                case "ShipmentFormStorekeeper.btnCheckContractor":
                    return Text("ContractorCheck");
                case "DeliveryHistory.label5":
                case "ShipmentFormAdmin.label5":
                case "ShipmentFormStorekeeper.label5":
                    return Text("Search");
                case "DeliveryHistory.labelPeriod":
                    return Text("Period");
                case "DeliveryHistory.label4":
                    return Text("From");
                case "DeliveryHistory.label1":
                    return Text("To");
                case "ShipmentFormAdmin.labelToShipment":
                case "ShipmentFormStorekeeper.labelToShipment":
                    return Text("Shipment");
                case "ShipmentFormAdmin.buttonToHold":
                case "ShipmentFormStorekeeper.buttonToHold":
                    return Text("Process");
                case "ShipmentFormAdmin.label3":
                case "ShipmentFormStorekeeper.label3":
                    return Text("Date");
                case "ShipmentFormAdmin.label2":
                case "ShipmentFormStorekeeper.label2":
                    return Text("Recipient");
                case "ShipmentFormAdmin.label4":
                case "ShipmentFormStorekeeper.label4":
                    return Text("AddProduct");
                case "ShipmentFormAdmin.label6":
                case "ShipmentFormStorekeeper.label6":
                    return Text("QuantityShort");
                case "ShipmentFormAdmin.buttonToAddInTable":
                case "ShipmentFormStorekeeper.buttonToAddInTable":
                    return Text("AddToList");
                case "ShipmentFormAdmin.buttonToDeleteShipment":
                case "ShipmentFormStorekeeper.buttonToDeleteShipment":
                    return Text("DeleteShipment");
                case "ShipmentFormAdmin.lblRegion":
                case "ShipmentFormStorekeeper.lblRegion":
                    return Text("RecipientRegion");
                default:
                    return null;
            }
        }

        private static string RussianText(string key)
        {
            switch (key)
            {
                case "AppTitle": return "Складской учет канцелярии";
                case "AppTitleUpper": return "СКЛАДСКОЙ УЧЕТ КАНЦЕЛЯРИИ";
                case "Exit": return "Выйти";
                case "StartWork": return "НАЧАТЬ РАБОТУ";
                case "EnterLogin": return "Введите логин";
                case "EnterPassword": return "Введите пароль";
                case "Login": return "ВОЙТИ";
                case "Registration": return "РЕГИСТРАЦИЯ";
                case "EnterName": return "Введите имя";
                case "EnterSurname": return "Введите фамилию";
                case "EnterPatronymic": return "Введите отчество";
                case "Products": return "ТОВАРЫ";
                case "Supplies": return "ПОСТАВКИ";
                case "Shipments": return "ОТГРУЗКИ";
                case "WarehouseMap": return "СХЕМА СКЛАДА";
                case "Reports": return "ОТЧЁТЫ";
                case "Settings": return "Параметры";
                case "YourRole": return "Ваша роль:";
                case "Currency": return "Валюта:";
                case "Language": return "Язык:";
                case "Discount": return "Скидка:";
                case "Close": return "Закрыть";
                case "Save": return "Сохранить";
                case "DatePrefix": return "Дата: ";
                case "Welcome": return "Добро пожаловать, ";
                case "Administrator": return "Администратор";
                case "Storekeeper": return "Кладовщик";
                case "Back": return "Назад";
                case "NewSupply": return "Новая поставка";
                case "ImportFromFile": return "Импорт из файла";
                case "SupplyHistory": return "История поставок";
                case "Product": return "Товар:";
                case "Quantity": return "Количество:";
                case "QuantityShort": return "Кол-во:";
                case "ExpirationDate": return "Срок годности:";
                case "PurchasePrice": return "Цена закупки:";
                case "AddToSupply": return "Добавить в поставку";
                case "ProcessSupply": return "Провести поставку";
                case "ContractorCheck": return "Проверка контрагента";
                case "Search": return "Поиск:";
                case "Period": return "Период:";
                case "From": return "с";
                case "To": return "по";
                case "Shipment": return "Отгрузка";
                case "Process": return "Провести";
                case "Date": return "Дата";
                case "Recipient": return "Кому";
                case "AddProduct": return "Добавить товар:";
                case "AddToList": return "Добавить в список";
                case "DeleteShipment": return "Удалить отгрузку";
                case "RecipientRegion": return "Регион получателя";
                case "ColumnArticle": return "Артикул";
                case "ColumnName": return "Наименование";
                case "ColumnQuantity": return "Количество";
                case "ColumnPrice": return "Цена";
                case "ColumnTerm": return "Срок";
                case "ColumnDate": return "Дата";
                case "ColumnDocumentNumber": return "Номер документа";
                case "ColumnAmount": return "Сумма";
                case "ColumnContents": return "Состав";
                case "Open": return "Открыть";
                case "ColumnPricePerUnit": return "Цена за шт.";
                case "ColumnTotalAmount": return "Итого";
                case "ColumnAvailability": return "Остаток";
                case "ColumnWeather": return "Метео-рекомендации";
                case "ProductCatalog": return "Каталог товаров";
                case "Delete": return "Удалить";
                case "Edit": return "Редактировать";
                case "Category": return "Категория";
                case "Status": return "Статус";
                case "Customer": return "Покупатель";
                case "Find": return "Найти";
                case "Export": return "Экспорт";
                case "LegalStatus": return "Юридический\nстатус:";
                case "Inn": return "ИНН:";
                case "Check": return "Проверить";
                case "SupplyContents": return "Состав поставки";
                case "DateLabel": return "Дата:";
                case "CategoryName": return "Название категории:";
                case "HeatMap": return "Тепловая карта склада";
                case "SortBy": return "Сортировать по:";
                case "Legend": return "Обозначения:";
                case "ColumnUnit": return "Ед. изм.";
                case "ColumnStock": return "Остаток";
                case "ColumnExpirationDate": return "Срок годности";
                case "ColumnProfit": return "Прибыль";
                case "ColumnCustomer": return "Покупатель";
                case "NoExpiration": return "нет срока";
                case "ProductDeleted": return "Товар удалён";
                case "SortExpiration": return "срокам годности";
                case "SortStock": return "остаткам";
                default: return key;
            }
        }

        private static string EnglishText(string key)
        {
            switch (key)
            {
                case "AppTitle": return "Stationery warehouse";
                case "AppTitleUpper": return "STATIONERY WAREHOUSE";
                case "Exit": return "Exit";
                case "StartWork": return "START";
                case "EnterLogin": return "Enter login";
                case "EnterPassword": return "Enter password";
                case "Login": return "LOGIN";
                case "Registration": return "REGISTRATION";
                case "EnterName": return "Enter name";
                case "EnterSurname": return "Enter surname";
                case "EnterPatronymic": return "Enter patronymic";
                case "Products": return "PRODUCTS";
                case "Supplies": return "SUPPLIES";
                case "Shipments": return "SHIPMENTS";
                case "WarehouseMap": return "WAREHOUSE MAP";
                case "Reports": return "REPORTS";
                case "Settings": return "Settings";
                case "YourRole": return "Your role:";
                case "Currency": return "Currency:";
                case "Language": return "Language:";
                case "Discount": return "Discount:";
                case "Close": return "Close";
                case "Save": return "Save";
                case "DatePrefix": return "Date: ";
                case "Welcome": return "Welcome, ";
                case "Administrator": return "Administrator";
                case "Storekeeper": return "Storekeeper";
                case "Back": return "Back";
                case "NewSupply": return "New supply";
                case "ImportFromFile": return "Import from file";
                case "SupplyHistory": return "Supply history";
                case "Product": return "Product:";
                case "Quantity": return "Quantity:";
                case "QuantityShort": return "Qty:";
                case "ExpirationDate": return "Expiration date:";
                case "PurchasePrice": return "Purchase price:";
                case "AddToSupply": return "Add to supply";
                case "ProcessSupply": return "Process supply";
                case "ContractorCheck": return "Contractor check";
                case "Search": return "Search:";
                case "Period": return "Period:";
                case "From": return "from";
                case "To": return "to";
                case "Shipment": return "Shipment";
                case "Process": return "Process";
                case "Date": return "Date";
                case "Recipient": return "Recipient";
                case "AddProduct": return "Add product:";
                case "AddToList": return "Add to list";
                case "DeleteShipment": return "Delete shipment";
                case "RecipientRegion": return "Recipient region";
                case "ColumnArticle": return "Article";
                case "ColumnName": return "Name";
                case "ColumnQuantity": return "Quantity";
                case "ColumnPrice": return "Price";
                case "ColumnTerm": return "Term";
                case "ColumnDate": return "Date";
                case "ColumnDocumentNumber": return "Document number";
                case "ColumnAmount": return "Amount";
                case "ColumnContents": return "Contents";
                case "Open": return "Open";
                case "ColumnPricePerUnit": return "Price per unit";
                case "ColumnTotalAmount": return "Total";
                case "ColumnAvailability": return "Stock";
                case "ColumnWeather": return "Weather recommendation";
                case "ProductCatalog": return "Product catalog";
                case "Delete": return "Delete";
                case "Edit": return "Edit";
                case "Category": return "Category";
                case "Status": return "Status";
                case "Customer": return "Customer";
                case "Find": return "Find";
                case "Export": return "Export";
                case "LegalStatus": return "Legal\nstatus:";
                case "Inn": return "INN:";
                case "Check": return "Check";
                case "SupplyContents": return "Supply contents";
                case "DateLabel": return "Date:";
                case "CategoryName": return "Category name:";
                case "HeatMap": return "Warehouse heat map";
                case "SortBy": return "Sort by:";
                case "Legend": return "Legend:";
                case "ColumnUnit": return "Unit";
                case "ColumnStock": return "Stock";
                case "ColumnExpirationDate": return "Expiration date";
                case "ColumnProfit": return "Profit";
                case "ColumnCustomer": return "Customer";
                case "NoExpiration": return "no expiration";
                case "ProductDeleted": return "Product deleted";
                case "SortExpiration": return "expiration date";
                case "SortStock": return "stock";
                default: return key;
            }
        }
    }
}
