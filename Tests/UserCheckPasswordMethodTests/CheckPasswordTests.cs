using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UserCheckPasswordTests
{
    [TestClass]
    public class CheckPasswordTests
    {
        private const string AdminPasswordHash = "$2a$11$o9F48orBGIHtcV0MELgrY.CGGeR4Gk7.s1ysMCutS6xpd7kNEv/eq";

        [TestMethod]
        public void CheckPassword_WithCorrectPassword_ReturnsTrue()
        {
            var user = new UserCheckPasswordMethod.CheckPasswordMethod
            {
                HashPassword = AdminPasswordHash
            };

            var result = user.CheckPassword(user, "admin666");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckPassword_WithIncorrectPassword_ReturnsFalse()
        {
            var user = new UserCheckPasswordMethod.CheckPasswordMethod
            {
                HashPassword = AdminPasswordHash
            };

            var result = user.CheckPassword(user, "wrong-password");

            Assert.IsFalse(result);
        }
    }
}
