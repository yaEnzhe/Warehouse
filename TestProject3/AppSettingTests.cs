using WarehouseApp.Classes;

namespace TestProject3
{
    [TestClass]
    public sealed class AppSettingTests
    {
        [TestMethod]
        public void Constructor_WhenNewObjectCreated_PropertiesHaveDefaultValues()
        {
            var setting = new AppSetting();
            Assert.AreEqual(Guid.Empty, setting.Id);
            Assert.IsNull(setting.Key);
            Assert.IsNull(setting.Value);
        }

        [TestMethod]
        public void Id_CanSetAndGetValidGuid()
        {
            var setting = new AppSetting();
            var expectedId = Guid.NewGuid();
            setting.Id = expectedId;
            Assert.AreEqual(expectedId, setting.Id);
        }

        [TestMethod]
        public void Key_CanSetAndGetStringValue()
        {
            var setting = new AppSetting();
            var expectedKey = "Language";
            setting.Key = expectedKey;
            Assert.AreEqual(expectedKey, setting.Key);
        }

        [TestMethod]
        public void Value_CanSetAndGetStringValue()
        {
            var setting = new AppSetting();
            var expectedValue = "RUS";
            setting.Value = expectedValue;
            Assert.AreEqual(expectedValue, setting.Value);
        }

        [TestMethod]
        public void Key_WhenSetToNull_CanRetrieveNull()
        {
            var setting = new AppSetting();
            setting.Key = "some value";
            setting.Key = null;
            Assert.IsNull(setting.Key);
        }

        [TestMethod]
        public void Value_WhenSetToEmptyString_CanRetrieveEmpty()
        {
            var setting = new AppSetting();
            setting.Value = string.Empty;
            Assert.AreEqual(string.Empty, setting.Value);
        }

        [TestMethod]
        public void AllProperties_SetIndependently()
        {
            var id = Guid.NewGuid();
            var key = "Theme";
            var value = "Dark";
            var setting = new AppSetting
            {
                Id = id,
                Key = key,
                Value = value
            };
            Assert.AreEqual(id, setting.Id);
            Assert.AreEqual(key, setting.Key);
            Assert.AreEqual(value, setting.Value);
        }
    }
}
