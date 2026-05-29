using WarehouseApp.Classes;

namespace TestProject3
{
    [TestClass]
    public sealed class LanguageManagerTests
    {
        private string _originalLanguage;

        [TestInitialize]
        public void Setup()
        {
            _originalLanguage = LanguageManager.CurrentLanguage;
        }

        [TestCleanup]
        public void Cleanup()
        {
            LanguageManager.SetLanguage(_originalLanguage);
        }

        [TestMethod]
        public void SetLanguage_WithEng_SetsCurrentLanguageToEng()
        {
            LanguageManager.SetLanguage("ENG");
            Assert.AreEqual("ENG", LanguageManager.CurrentLanguage);
        }

        [TestMethod]
        public void SetLanguage_WithLowerCaseEng_SetsCurrentLanguageToRus()
        {
            LanguageManager.SetLanguage("eng"); // не "ENG"
            Assert.AreEqual("RUS", LanguageManager.CurrentLanguage);
        }

        [TestMethod]
        public void SetLanguage_WithRus_SetsCurrentLanguageToRus()
        {
            LanguageManager.SetLanguage("RUS");
            Assert.AreEqual("RUS", LanguageManager.CurrentLanguage);
        }

        [TestMethod]
        public void SetLanguage_WithAnyOtherString_SetsCurrentLanguageToRus()
        {
            LanguageManager.SetLanguage("FR");
            Assert.AreEqual("RUS", LanguageManager.CurrentLanguage);
        }

        [TestMethod]
        public void Text_WhenKeyNotFound_ReturnsKeyItself()
        {
            LanguageManager.SetLanguage("RUS");
            string result = LanguageManager.Text("NonExistentKey");
            Assert.AreEqual("NonExistentKey", result);
        }
    }
}
