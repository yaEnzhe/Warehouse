using Microsoft.VisualStudio.TestTools.UnitTesting;
using WarehouseApp.Classes;
using System;

namespace WarehouseApp.Tests
{
    /// <summary>
    /// Тестовая обертка для логики паролей
    /// </summary>
    public static class TestPasswordHelper
    {
        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("Пароль не может быть пустым");
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        }
        public static bool CheckPassword(string password, string hash)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(hash))
                return false;

            var hashedInput = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
            return hashedInput == hash;
        }
        public static bool IsPasswordStrong(string password)
        {
            if (string.IsNullOrEmpty(password) || password.Length < 6)
                return false;

            bool hasDigit = false;
            bool hasUpper = false;
            bool hasLower = false;

            foreach (char c in password)
            {
                if (char.IsDigit(c)) hasDigit = true;
                else if (char.IsUpper(c)) hasUpper = true;
                else if (char.IsLower(c)) hasLower = true;
            }

            return hasDigit && hasUpper && hasLower;
        }
    }
    [TestClass]
    public class PasswordExtendedTests
    {
        #region HashPassword Tests

        [TestMethod]
        public void HashPassword_ValidPassword_ReturnsNonNullHash()
        {
            // Arrange
            string password = "MySecret123";

            // Act
            string hash = TestPasswordHelper.HashPassword(password);

            // Assert
            Assert.IsNotNull(hash);
            Assert.IsTrue(hash.Length > 0);
        }

        [TestMethod]
        public void HashPassword_ValidPassword_ReturnsDifferentHashForDifferentPasswords()
        {
            // Arrange
            string password1 = "MySecret123";
            string password2 = "MySecret456";

            // Act
            string hash1 = TestPasswordHelper.HashPassword(password1);
            string hash2 = TestPasswordHelper.HashPassword(password2);

            // Assert
            Assert.AreNotEqual(hash1, hash2, "Разные пароли должны давать разные хэши");
        }

        [TestMethod]
        public void HashPassword_ValidPassword_SamePasswordSameHash()
        {
            // Arrange
            string password = "MySecret123";

            // Act
            string hash1 = TestPasswordHelper.HashPassword(password);
            string hash2 = TestPasswordHelper.HashPassword(password);

            // Assert
            Assert.AreEqual(hash1, hash2, "Одинаковые пароли должны давать одинаковые хэши");
        }

        [TestMethod]
        public void HashPassword_EmptyPassword_ThrowsException()
        {
            // Act & Assert
            AssertEx.ThrowsException<ArgumentException>(() =>
                TestPasswordHelper.HashPassword(""));
        }

        [TestMethod]
        public void HashPassword_NullPassword_ThrowsException()
        {
            // Act & Assert
            AssertEx.ThrowsException<ArgumentException>(() =>
                TestPasswordHelper.HashPassword(null));
        }

        #endregion

        #region CheckPassword Tests

        [TestMethod]
        public void CheckPassword_CorrectPassword_ReturnsTrue()
        {
            // Arrange
            string password = "CorrectPassword";
            string hash = TestPasswordHelper.HashPassword(password);

            // Act
            bool result = TestPasswordHelper.CheckPassword(password, hash);
            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void CheckPassword_WrongPassword_ReturnsFalse()
        {
            // Arrange
            string correctPassword = "CorrectPassword";
            string wrongPassword = "WrongPassword";
            string hash = TestPasswordHelper.HashPassword(correctPassword);

            // Act
            bool result = TestPasswordHelper.CheckPassword(wrongPassword, hash);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckPassword_CorrectPasswordWrongCase_ReturnsFalse()
        {
            // Arrange
            string correctPassword = "CorrectPassword";
            string wrongCasePassword = "correctpassword";
            string hash = TestPasswordHelper.HashPassword(correctPassword);

            // Act
            bool result = TestPasswordHelper.CheckPassword(wrongCasePassword, hash);

            // Assert
            Assert.IsFalse(result, "Пароль чувствителен к регистру");
        }
        [TestMethod]
        public void CheckPassword_EmptyPassword_ReturnsFalse()
        {
            // Arrange
            string hash = TestPasswordHelper.HashPassword("SomePassword");
            // Act
            bool result = TestPasswordHelper.CheckPassword("", hash);
            // Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void CheckPassword_EmptyHash_ReturnsFalse()
        {
            // Arrange
            string password = "SomePassword";
            // Act
            bool result = TestPasswordHelper.CheckPassword(password, "");
            // Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void CheckPassword_NullHash_ReturnsFalse()
        {
            // Act
            bool result = TestPasswordHelper.CheckPassword("password", null);
            // Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void CheckPassword_NullPassword_ReturnsFalse()
        {
            // Arrange
            string hash = TestPasswordHelper.HashPassword("SomePassword");
            // Act
            bool result = TestPasswordHelper.CheckPassword(null, hash);
            // Assert
            Assert.IsFalse(result);
        }
        #endregion
        #region IsPasswordStrong Tests

        [TestMethod]
        public void IsPasswordStrong_StrongPassword_ReturnsTrue()
        {
            // Arrange
            string[] strongPasswords =
            {
                "Password123",
                "MySecureP@ss1",
                "XyZ123abc",
                "Abcdefg1",
                "StrongPwd99",
                "HelloWorld1"
            };

            foreach (var pwd in strongPasswords)
            {
                // Act
                bool result = TestPasswordHelper.IsPasswordStrong(pwd);

                // Assert
                Assert.IsTrue(result, $"Пароль '{pwd}' должен считаться надежным");
            }
        }

        [TestMethod]
        public void IsPasswordStrong_WeakPassword_ReturnsFalse()
        {
            // Arrange
            var weakPasswords = new[]
            {
                new { Password = "123", Reason = "слишком короткий" },
                new { Password = "password", Reason = "только буквы (нет цифр)" },
                new { Password = "PASSWORD", Reason = "только заглавные (нет цифр и строчных)" },
                new { Password = "123456789", Reason = "только цифры" },
                new { Password = "Pass", Reason = "меньше 6 символов" },
                new { Password = "abcdef", Reason = "только строчные (нет цифр и заглавных)" },
                new { Password = "ABCDEF", Reason = "только заглавные (нет цифр и строчных)" },
                new { Password = "123abc", Reason = "нет заглавных букв" },
                new { Password = "123ABC", Reason = "нет строчных букв" },
                new { Password = "Abcdef", Reason = "нет цифр" }
            };

            foreach (var pwd in weakPasswords)
            {
                // Act
                bool result = TestPasswordHelper.IsPasswordStrong(pwd.Password);

                // Assert
                Assert.IsFalse(result, $"Пароль '{pwd.Password}' должен считаться ненадежным ({pwd.Reason})");
            }
        }

        [TestMethod]
        public void IsPasswordStrong_EmptyOrNull_ReturnsFalse()
        {
            // Assert
            Assert.IsFalse(TestPasswordHelper.IsPasswordStrong(""));
            Assert.IsFalse(TestPasswordHelper.IsPasswordStrong(null));
        }

        [TestMethod]
        public void IsPasswordStrong_ExactlyMinLength_WithAllRequirements_ReturnsTrue()
        {
            // Arrange
            string password = "Abc123";
            // Act
            bool result = TestPasswordHelper.IsPasswordStrong(password);
            // Assert
            Assert.IsTrue(result, "Пароль из 6 символов с цифрой, заглавной и строчной должен быть надежным");
        }
        [TestMethod]
        public void IsPasswordStrong_WithSpaces_StillStrongIfRequirementsMet()
        {
            // Arrange
            string[] passwordsWithSpaces =
            {
                "Pass word1",    
                "Hello World 2",  
                "My Pass 123"      
            };

            foreach (var pwd in passwordsWithSpaces)
            {
                // Act
                bool result = TestPasswordHelper.IsPasswordStrong(pwd);

                // Assert 
                Assert.IsTrue(result, $"Пароль '{pwd}' должен считаться надежным (пробелы допустимы)");
            }
        }
        [TestMethod]
        public void IsPasswordStrong_OnlySpaces_ReturnsFalse()
        {
            // Arrange
            string onlySpaces = "      "; // 6 пробелов

            // Act
            bool result = TestPasswordHelper.IsPasswordStrong(onlySpaces);

            // Assert
            Assert.IsFalse(result, "Пароль из одних пробелов не должен считаться надежным");
        }

        [TestMethod]
        public void IsPasswordStrong_SpacesAndLetters_NoDigits_ReturnsFalse()
        {
            // Arrange
            string password = "Pass word"; 

            // Act
            bool result = TestPasswordHelper.IsPasswordStrong(password);

            // Assert
            Assert.IsFalse(result, "Пароль без цифр не должен считаться надежным");
        }
        [TestMethod]
        public void IsPasswordStrong_WithSpecialChars_HandlesCorrectly()
        {
            // Arrange
            string passwordWithSpecial = "Pass@word1";

            // Act
            bool result = TestPasswordHelper.IsPasswordStrong(passwordWithSpecial);

            // Assert 
            Assert.IsTrue(result, "Спецсимволы не должны мешать проверке");
        }
        #endregion
        #region Integration Tests
        [TestMethod]
        public void FullPasswordFlow_HashThenCheck_WorksCorrectly()
        {
            // Arrange
            string originalPassword = "MySecurePwd123";

            // Act 
            string hash = TestPasswordHelper.HashPassword(originalPassword);
            bool isValid = TestPasswordHelper.CheckPassword(originalPassword, hash);
            // Assert
            Assert.IsTrue(isValid, "Пароль должен успешно проходить проверку после хэширования");
        }
        [TestMethod]
        public void FullPasswordFlow_WrongPassword_DoesNotPass()
        {
            // Arrange
            string originalPassword = "MySecurePwd123";
            string wrongPassword = "WrongPwd123";

            // Act
            string hash = TestPasswordHelper.HashPassword(originalPassword);
            bool isValid = TestPasswordHelper.CheckPassword(wrongPassword, hash);

            // Assert
            Assert.IsFalse(isValid, "Неверный пароль не должен проходить проверку");
        }

        #endregion
    }
}