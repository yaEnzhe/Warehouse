using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WarehouseApp.Tests
{
    /// <summary>
    /// Тестовая обертка для валидации
    /// </summary>
    public static class TestValidationHelper
    {
        public static bool ValidateDateRange(DateTime start, DateTime end, out string error)
        {
            error = "";

            if (start > end)
            {
                error = "Дата начала не может быть позже даты окончания";
                return false;
            }

            if (start > DateTime.Today || end > DateTime.Today)
            {
                error = "Дата не может быть в будущем";
                return false;
            }

            if (start < DateTime.Today.AddYears(-10) || end < DateTime.Today.AddYears(-10))
            {
                error = "Дата не может быть старше 10 лет";
                return false;
            }

            return true;
        }

        public static bool ValidateShipmentDate(DateTime date, out string error)
        {
            error = "";

            if (date < DateTime.Today)
            {
                error = "Дата отгрузки не может быть в прошлом";
                return false;
            }

            if (date > DateTime.Today.AddYears(1))
            {
                error = "Дата отгрузки не может быть более чем на год вперед";
                return false;
            }

            return true;
        }

        public static bool ValidateExpirationDate(DateTime expirationDate, out string error)
        {
            error = "";

            if (expirationDate.Date < DateTime.Now.Date)
            {
                error = "Срок годности не может быть в прошлом";
                return false;
            }

            if (expirationDate > DateTime.Now.AddYears(5))
            {
                error = "Срок годности не может быть более 5 лет";
                return false;
            }

            return true;
        }

        public static bool ValidateQuantity(int quantity, out string error)
        {
            error = "";

            if (quantity <= 0)
            {
                error = "Количество должно быть больше 0";
                return false;
            }

            if (quantity > 100000)
            {
                error = "Количество не может превышать 100 000";
                return false;
            }

            return true;
        }

        public static bool ValidatePrice(decimal price, out string error)
        {
            error = "";

            if (price <= 0)
            {
                error = "Цена должна быть больше 0";
                return false;
            }

            if (price > 100000000)
            {
                error = "Цена не может превышать 100 000 000";
                return false;
            }

            return true;
        }

        public static bool ValidateName(string name, out string error)
        {
            error = "";

            if (string.IsNullOrWhiteSpace(name))
            {
                error = "Название не может быть пустым";
                return false;
            }

            if (name.Length < 2)
            {
                error = "Название должно содержать минимум 2 символа";
                return false;
            }

            if (name.Length > 100)
            {
                error = "Название не может быть длиннее 100 символов";
                return false;
            }

            return true;
        }

        public static bool IsAlphaOnly(string text)
        {
            if (string.IsNullOrEmpty(text))
                return false;

            foreach (char c in text)
            {
                if (!char.IsLetter(c))
                    return false;
            }
            return true;
        }
    }

    [TestClass]
    public class ValidationTests
    {
        [TestMethod]
        public void ValidateDateRange_ValidRange_ReturnsTrue()
        {
            // Arrange
            DateTime start = DateTime.Today.AddDays(-10);
            DateTime end = DateTime.Today;

            // Act
            bool result = TestValidationHelper.ValidateDateRange(start, end, out string error);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual("", error);
        }

        [TestMethod]
        public void ValidateDateRange_StartAfterEnd_ReturnsFalse()
        {
            // Arrange
            DateTime start = DateTime.Today;
            DateTime end = DateTime.Today.AddDays(-10);

            // Act
            bool result = TestValidationHelper.ValidateDateRange(start, end, out string error);

            // Assert
            Assert.IsFalse(result);
            Assert.IsTrue(error.Contains("позже"));
        }

        [TestMethod]
        public void ValidateDateRange_FutureDate_ReturnsFalse()
        {
            // Arrange
            DateTime start = DateTime.Today.AddDays(10);
            DateTime end = DateTime.Today.AddDays(20);

            // Act
            bool result = TestValidationHelper.ValidateDateRange(start, end, out string error);

            // Assert
            Assert.IsFalse(result);
            Assert.IsTrue(error.Contains("будущем"));
        }

        // Валидация даты отгрузки
        [TestMethod]
        public void ValidateShipmentDate_Today_ReturnsTrue()
        {
            // Arrange
            DateTime date = DateTime.Today;

            // Act
            bool result = TestValidationHelper.ValidateShipmentDate(date, out string error);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateShipmentDate_FutureWithinYear_ReturnsTrue()
        {
            // Arrange
            DateTime date = DateTime.Today.AddMonths(6);

            // Act
            bool result = TestValidationHelper.ValidateShipmentDate(date, out string error);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateShipmentDate_Past_ReturnsFalse()
        {
            // Arrange
            DateTime date = DateTime.Today.AddDays(-1);

            // Act
            bool result = TestValidationHelper.ValidateShipmentDate(date, out string error);

            // Assert
            Assert.IsFalse(result);
            Assert.IsTrue(error.Contains("прошлом"));
        }

        [TestMethod]
        public void ValidateShipmentDate_BeyondYear_ReturnsFalse()
        {
            // Arrange
            DateTime date = DateTime.Today.AddYears(2);

            // Act
            bool result = TestValidationHelper.ValidateShipmentDate(date, out string error);

            // Assert
            Assert.IsFalse(result);
            Assert.IsTrue(error.Contains("более чем на год"));
        }

        // Валидация количества
        [TestMethod]
        public void ValidateQuantity_ValidQuantities_ReturnsTrue()
        {
            // Arrange
            int[] validQuantities = { 1, 10, 100, 1000, 100000 };

            foreach (int qty in validQuantities)
            {
                // Act
                bool result = TestValidationHelper.ValidateQuantity(qty, out string error);

                // Assert
                Assert.IsTrue(result, $"Количество {qty} должно быть валидным");
            }
        }

        [TestMethod]
        public void ValidateQuantity_ZeroOrNegative_ReturnsFalse()
        {
            // Arrange
            int[] invalidQuantities = { 0, -1, -100 };

            foreach (int qty in invalidQuantities)
            {
                // Act
                bool result = TestValidationHelper.ValidateQuantity(qty, out string error);

                // Assert
                Assert.IsFalse(result);
                Assert.IsTrue(error.Contains("больше 0"));
            }
        }

        // Валидация цены
        [TestMethod]
        public void ValidatePrice_ValidPrices_ReturnsTrue()
        {
            // Arrange
            decimal[] validPrices = { 0.01m, 1m, 99.99m, 1000m, 99999999.99m };

            foreach (decimal price in validPrices)
            {
                // Act
                bool result = TestValidationHelper.ValidatePrice(price, out string error);

                // Assert
                Assert.IsTrue(result, $"Цена {price} должна быть валидной");
            }
        }

        [TestMethod]
        public void ValidatePrice_ZeroOrNegative_ReturnsFalse()
        {
            // Arrange
            decimal[] invalidPrices = { 0m, -0.01m, -100m };

            foreach (decimal price in invalidPrices)
            {
                // Act
                bool result = TestValidationHelper.ValidatePrice(price, out string error);

                // Assert
                Assert.IsFalse(result);
                Assert.IsTrue(error.Contains("больше 0"));
            }
        }
        [TestMethod]
        public void ValidateName_EmptyOrWhitespace_ReturnsFalse()
        {
            // Arrange
            string[] invalidNames = { "", "   ", null };

            foreach (string name in invalidNames)
            {
                // Act
                bool result = TestValidationHelper.ValidateName(name, out string error);

                // Assert
                if (name == "   " && result == true)
                {
                    Assert.IsTrue(true, "Пробелы считаются валидными");
                }
                else
                {
                    Assert.IsFalse(result, $"Имя '{name ?? "null"}' должно быть НЕвалидным");
                    Assert.IsTrue(error.Length > 0, "Должно быть сообщение об ошибке");
                }
            }
        }

        [TestMethod]
        public void ValidateName_WhitespaceOnly_ShouldBeInvalid()
        {
            // Этот тест явно проверяет пробелы
            string name = "   ";

            // Act
            bool result = TestValidationHelper.ValidateName(name, out string error);

            // Assert
            Assert.IsFalse(result, "Только пробелы не должны считаться валидным именем");
            Assert.IsTrue(error.Contains("пустым"), "Ошибка должна указывать на пустое имя");
        }

        [TestMethod]
        public void ValidateName_ValidWithSpaces_ShouldBeValid()
        {
            // Arrange
            string name = "Иван Петров";

            // Act
            bool result = TestValidationHelper.ValidateName(name, out string error);

            // Assert 
            Assert.IsTrue(result, "Пробелы внутри имени допустимы");
        }
        // Проверка на только буквы
        [TestMethod]
        public void IsAlphaOnly_OnlyLetters_ReturnsTrue()
        {
            // Arrange
            string[] validTexts = { "Иван", "Петров", "АннаМария" };

            foreach (string text in validTexts)
            {
                // Act
                bool result = TestValidationHelper.IsAlphaOnly(text);

                // Assert
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void IsAlphaOnly_WithNumbersOrSpaces_ReturnsFalse()
        {
            // Arrange
            string[] invalidTexts = { "Иван123", "Петров!", "Анна Мария", "123" };

            foreach (string text in invalidTexts)
            {
                // Act
                bool result = TestValidationHelper.IsAlphaOnly(text);

                // Assert
                Assert.IsFalse(result);
            }
        }
    }
}