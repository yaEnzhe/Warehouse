using WarehouseApp.Classes;
using WarehouseApp.Enums;

namespace TestProject3
{
    [TestClass]
    public sealed class UserDisplayHelperTests
    {
        [TestMethod]
        public void GetShortName_UserNull_ReturnsEmpty()
        {
            var result = UserDisplayHelper.GetShortName(null);
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void GetShortName_AllFieldsEmpty_ReturnsLogin()
        {
            var user = new User { Login = "john", Surname = "", Name = "", Patronymic = "" };
            var result = UserDisplayHelper.GetShortName(user);
            Assert.AreEqual("john", result);
        }

        [TestMethod]
        public void GetShortName_OnlySurname_ReturnsSurname()
        {
            var user = new User { Surname = "Иванов", Name = null, Patronymic = null };
            var result = UserDisplayHelper.GetShortName(user);
            Assert.AreEqual("Иванов", result);
        }

        [TestMethod]
        public void GetShortName_SurnameAndName_ReturnsSurnameAndInitial()
        {
            var user = new User { Surname = "Петров", Name = "Пётр", Patronymic = "" };
            var result = UserDisplayHelper.GetShortName(user);
            Assert.AreEqual("Петров П.", result);
        }

        [TestMethod]
        public void GetShortName_SurnameNamePatronymic_ReturnsFullWithInitials()
        {
            var user = new User { Surname = "Сидоров", Name = "Сидор", Patronymic = "Сидорович" };
            var result = UserDisplayHelper.GetShortName(user);
            Assert.AreEqual("Сидоров С. С.", result);
        }

        [TestMethod]
        public void GetShortName_NoSurnameButNameAndPatronymic_ReturnsInitialsOnly()
        {
            var user = new User { Surname = "", Name = "Анна", Patronymic = "Петровна" };
            var result = UserDisplayHelper.GetShortName(user);
            Assert.AreEqual("А. П.", result);
        }

        [TestMethod]
        public void GetShortName_WhitespaceTrimming_WorksCorrectly()
        {
            var user = new User { Surname = "  Иванов  ", Name = "  Иван  ", Patronymic = "  Иванович  " };
            var result = UserDisplayHelper.GetShortName(user);
            Assert.AreEqual("Иванов И. И.", result);
        }


        [TestMethod]
        public void GetRoleName_Administrator_ReturnsRussianTranslation()
        {
            var originalLang = LanguageManager.CurrentLanguage;
            LanguageManager.SetLanguage("RUS");
            try
            {
                var result = UserDisplayHelper.GetRoleName(Roles.Administrator);
                Assert.AreEqual("Администратор", result);
            }
            finally
            {
                LanguageManager.SetLanguage(originalLang);
            }
        }

        [TestMethod]
        public void GetRoleName_Storekeeper_ReturnsRussianTranslation()
        {
            var originalLang = LanguageManager.CurrentLanguage;
            LanguageManager.SetLanguage("RUS");
            try
            {
                var result = UserDisplayHelper.GetRoleName(Roles.Storekeeper);
                Assert.AreEqual("Кладовщик", result);
            }
            finally
            {
                LanguageManager.SetLanguage(originalLang);
            }
        }
    }
}
