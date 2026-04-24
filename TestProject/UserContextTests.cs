
using WarehouseApp.Classes;


namespace WarehouseApp.Tests
{
    [TestClass]
    public class CurrentUserTests
    {
        [TestInitialize]
        public void SetUp()
        {
            UserContext.Logout();
        }

        [TestCleanup]
        public void TearDown()
        {
            UserContext.Logout();
        }
        
        [TestMethod]
        public void Logout_WhenUserIsLoggedIn_ClearsCurrentUser()
        {
            var testUser = new User
            {
                Id = Guid.NewGuid(),
                Login = "TestUser",
                Name = "Test",
                Surname = "User"
            };
            UserContext.Current = testUser;
            Assert.IsNotNull(UserContext.Current);
            UserContext.Logout();
            Assert.IsNull(UserContext.Current);
        }

        [TestMethod]
        public void Logout_WhenNoUserLoggedIn_DoesNothing()
        {
            UserContext.Current = null;
            UserContext.Logout();
            Assert.IsNull(UserContext.Current);
        }

        [TestMethod]
        public void Current_SetAndGet_ReturnsCorrectUser()
        {
            var expectedUser = new User
            {
                Id = Guid.NewGuid(),
                Login = "Admin",
                Name = "Admin",
                Surname = "System"
            };
            UserContext.Current = expectedUser;
            var actualUser = UserContext.Current;
            Assert.IsNotNull(actualUser);
            Assert.AreEqual(expectedUser.Id, actualUser.Id);
            Assert.AreEqual(expectedUser.Login, actualUser.Login);
        }

        [TestMethod]
        public void Current_ReturnsNull_Initially()
        {
            UserContext.Logout();
            Assert.IsNull(UserContext.Current);
        }
    }
}