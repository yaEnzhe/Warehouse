using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UserHashPasswordBCryptTests
{
    [TestClass]
    public class HashPasswordBCryptTests
    {
        [TestMethod]
        public void HashPasswordBCrypt_WithPlainTextPassword_SetsHashedPassword()
        {
            var user = new UserHashPasswordBCryptMethod.HashPasswordBCryptMethod();

            user.HashPasswordBCrypt(user, "admin666");

            Assert.IsFalse(string.IsNullOrWhiteSpace(user.HashPassword));
            Assert.AreNotEqual("admin666", user.HashPassword);
        }
    }
}
