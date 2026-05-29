using WarehouseApp.Classes;
using WarehouseApp.Enums;

namespace TestProject3
{
    [TestClass]
    public sealed class SystemLogTests
    {
        [TestMethod]
        public void Constructor_WhenNewObjectCreated_IdIsNotDefaultGuid()
        {
            var log = new SystemLog();
            Assert.AreNotEqual(Guid.Empty, log.Id);
        }

        [TestMethod]
        public void Constructor_WhenNewObjectCreated_TimestampIsCloseToNow()
        {
            var before = DateTime.Now;
            var log = new SystemLog();
            var after = DateTime.Now;
            Assert.IsTrue(log.Timestamp >= before && log.Timestamp <= after,
                "Timestamp должен быть установлен в момент создания объекта");
        }

        [TestMethod]
        public void Constructor_WhenNewObjectCreated_LevelHasDefaultValue()
        {
            var log = new SystemLog();
            Assert.IsTrue(Enum.IsDefined(typeof(LogLevel), log.Level));
        }

        [TestMethod]
        public void Id_CanBeSetExplicitly()
        {
            var log = new SystemLog();
            var expectedId = Guid.NewGuid();
            log.Id = expectedId;
            Assert.AreEqual(expectedId, log.Id);
        }

        [TestMethod]
        public void Timestamp_CanBeSetExplicitly()
        {
            var log = new SystemLog();
            var expectedTime = new DateTime(2025, 1, 1, 12, 0, 0);
            log.Timestamp = expectedTime;
            Assert.AreEqual(expectedTime, log.Timestamp);
        }

        [TestMethod]
        public void UserName_CanBeSetAndGet()
        {
            var log = new SystemLog();
            var expected = "admin";
            log.UserName = expected;
            Assert.AreEqual(expected, log.UserName);
        }

        [TestMethod]
        public void UserName_DefaultIsNull()
        {
            var log = new SystemLog();
            Assert.IsNull(log.UserName);
        }

        [TestMethod]
        public void Level_CanBeSetAndGet()
        {
            var log = new SystemLog();
            var expected = LogLevel.Error;
            log.Level = expected;
            Assert.AreEqual(expected, log.Level);
        }

        [TestMethod]
        public void Action_CanBeSetAndGet()
        {
            var log = new SystemLog();
            var expected = "Login";
            log.Action = expected;
            Assert.AreEqual(expected, log.Action);
        }

        [TestMethod]
        public void Action_DefaultIsNull()
        {
            var log = new SystemLog();
            Assert.IsNull(log.Action);
        }

        [TestMethod]
        public void Details_CanBeSetAndGet()
        {
            var log = new SystemLog();
            var expected = "User logged in successfully";
            log.Details = expected;
            Assert.AreEqual(expected, log.Details);
        }

        [TestMethod]
        public void Details_DefaultIsNull()
        {
            var log = new SystemLog();
            Assert.IsNull(log.Details);
        }

        [TestMethod]
        public void AllProperties_CanBeSetSimultaneously()
        {
            var id = Guid.NewGuid();
            var timestamp = new DateTime(2025, 3, 15, 10, 30, 0);
            var userName = "Ivan";
            var level = LogLevel.Warning;
            var action = "DeleteProduct";
            var details = "Product ID 1234 deleted";
            var log = new SystemLog
            {
                Id = id,
                Timestamp = timestamp,
                UserName = userName,
                Level = level,
                Action = action,
                Details = details
            };
            Assert.AreEqual(id, log.Id);
            Assert.AreEqual(timestamp, log.Timestamp);
            Assert.AreEqual(userName, log.UserName);
            Assert.AreEqual(level, log.Level);
            Assert.AreEqual(action, log.Action);
            Assert.AreEqual(details, log.Details);
        }
    }
}
