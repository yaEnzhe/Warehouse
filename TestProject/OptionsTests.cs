using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace WarehouseApp.Tests
{
    /// <summary>
    /// Тестовая обертка для логики конвертации валют
    /// </summary>
    public static class TestCurrencyConverter
    {
        public static decimal ConvertFromBase(decimal priceInRub, string currency, decimal rate)
        {
            if (currency == "RUB")
                return priceInRub;
            if (rate <= 0)
                throw new ArgumentException("Курс должен быть больше нуля");
            return Math.Round(priceInRub / rate, 2);
        }

        public static decimal ConvertToBase(decimal priceInCurrentCurrency, string currency, decimal rate)
        {
            if (currency == "RUB")
                return priceInCurrentCurrency;
            if (rate <= 0)
                throw new ArgumentException("Курс должен быть больше нуля");
            return Math.Round(priceInCurrentCurrency * rate, 2);
        }

        public static string GetCurrencySymbol(string currencyCode)
        {
            if (string.IsNullOrEmpty(currencyCode))
                return currencyCode ?? "";

            var symbols = new Dictionary<string, string>
            {
                { "RUB", "₽" },
                { "USD", "$" },
                { "EUR", "€" },
                { "KZT", "₸" },
                { "GBP", "£" },
                { "CNY", "¥" }
            };
            return symbols.TryGetValue(currencyCode.ToUpper(), out var s) ? s : currencyCode;
        }

        public static bool IsValidCurrency(string currencyCode)
        {
            var validCurrencies = new[] { "RUB", "USD", "EUR", "KZT" };
            return currencyCode != null && validCurrencies.Contains(currencyCode.ToUpper());
        }
    }

    [TestClass]
    public class OptionsExtendedTests
    {
        #region ConvertFromBase Tests

        [TestMethod]
        public void ConvertFromBase_WhenCurrencyRUB_ReturnsSameValue()
        {
            // Arrange
            decimal[] testPrices = { 0m, 0.01m, 1m, 10.50m, 100m, 999.99m, 10000m };

            foreach (var price in testPrices)
            {
                // Act
                var result = TestCurrencyConverter.ConvertFromBase(price, "RUB", 1.0m);

                // Assert
                Assert.AreEqual(price, result, $"Ошибка для цены {price}");
            }
        }

        [TestMethod]
        public void ConvertFromBase_WhenCurrencyUSD_ConvertsCorrectly()
        {
            // Arrange
            var testCases = new[]
            {
                new { RubPrice = 100m, Rate = 90m, Expected = 1.11m },
                new { RubPrice = 450m, Rate = 90m, Expected = 5.00m },
                new { RubPrice = 1m, Rate = 100m, Expected = 0.01m },
                new { RubPrice = 0m, Rate = 90m, Expected = 0.00m },
                new { RubPrice = 1000m, Rate = 85.5m, Expected = 11.70m }
            };

            foreach (var tc in testCases)
            {
                // Act
                var result = TestCurrencyConverter.ConvertFromBase(tc.RubPrice, "USD", tc.Rate);

                // Assert
                Assert.AreEqual(tc.Expected, result,
                    $"Цена {tc.RubPrice} RUB при курсе {tc.Rate} должна быть {tc.Expected} USD");
            }
        }

        [TestMethod]
        public void ConvertFromBase_WhenCurrencyEUR_ConvertsCorrectly()
        {
            // Arrange
            decimal priceInRub = 100m;
            decimal rate = 100m;
            decimal expected = 1.00m;

            // Act
            var result = TestCurrencyConverter.ConvertFromBase(priceInRub, "EUR", rate);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ConvertFromBase_WhenCurrencyKZT_ConvertsCorrectly()
        {
            // Arrange
            decimal priceInRub = 1000m;
            decimal rate = 0.2m;
            decimal expected = 5000.00m;

            // Act
            var result = TestCurrencyConverter.ConvertFromBase(priceInRub, "KZT", rate);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ConvertFromBase_WithVerySmallAmounts_HandlesCorrectly()
        {
            // Arrange
            decimal priceInRub = 0.01m;
            decimal rate = 100m;
            decimal expected = 0.00m;

            // Act
            var result = TestCurrencyConverter.ConvertFromBase(priceInRub, "USD", rate);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ConvertFromBase_WithLargeAmounts_HandlesCorrectly()
        {
            // Arrange
            decimal priceInRub = 1_000_000m;
            decimal rate = 90m;
            decimal expected = 11111.11m;

            // Act
            var result = TestCurrencyConverter.ConvertFromBase(priceInRub, "USD", rate);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ConvertFromBase_WithZeroRate_ThrowsException()
        {
            // Act and Assert

            AssertEx.ThrowsException<ArgumentException>(() =>
                TestCurrencyConverter.ConvertFromBase(100m, "USD", 0m));
        }

        [TestMethod]
        public void ConvertFromBase_WithNegativeRate_ThrowsException()
        {
            // Act and Assert
            AssertEx.ThrowsException<ArgumentException>(() =>
                TestCurrencyConverter.ConvertFromBase(100m, "USD", -5m));
        }
        [TestMethod]
        public void ConvertFromBase_WithAllSupportedCurrencies_Works()
        {
            var currencies = new[] { "USD", "EUR", "KZT" };
            foreach (var currency in currencies)
            {
                var result = TestCurrencyConverter.ConvertFromBase(100m, currency, 90m);
                Assert.IsTrue(result > 0);
            }
        }

        #endregion

        #region ConvertToBase Tests

        [TestMethod]
        public void ConvertToBase_WhenCurrencyRUB_ReturnsSameValue()
        {
            // Arrange
            decimal[] testPrices = { 0m, 0.01m, 1m, 50.75m, 1000m };

            foreach (var price in testPrices)
            {
                // Act
                var result = TestCurrencyConverter.ConvertToBase(price, "RUB", 1.0m);

                // Assert
                Assert.AreEqual(price, result);
            }
        }

        [TestMethod]
        public void ConvertToBase_WhenCurrencyUSD_ConvertsCorrectly()
        {
            // Arrange
            var testCases = new[]
            {
                new { UsdPrice = 100m, Rate = 90m, Expected = 9000m },
                new { UsdPrice = 10.50m, Rate = 90m, Expected = 945.00m },
                new { UsdPrice = 1m, Rate = 85.5m, Expected = 85.50m },
                new { UsdPrice = 0m, Rate = 90m, Expected = 0.00m }
            };

            foreach (var tc in testCases)
            {
                // Act
                var result = TestCurrencyConverter.ConvertToBase(tc.UsdPrice, "USD", tc.Rate);

                // Assert
                Assert.AreEqual(tc.Expected, result);
            }
        }

        [TestMethod]
        public void ConvertToBase_RoundTrip_WithinAcceptableTolerance()
        {
            // Arrange
            decimal originalRub = 1000m;
            decimal rate = 90m;

            // Act
            decimal usd = TestCurrencyConverter.ConvertFromBase(originalRub, "USD", rate);
            decimal backToRub = TestCurrencyConverter.ConvertToBase(usd, "USD", rate);

            // Assert - допустимая погрешность = 1 копейка * курс
            // При курсе 90: погрешность до 0.90 копеек допустима
            decimal tolerance = 0.01m * rate;

            Assert.AreEqual(originalRub, backToRub, tolerance,
                $"Round-trip конвертация {originalRub} RUB → USD → RUB " +
                $"потеряла {originalRub - backToRub} RUB, что в пределах допустимого {tolerance} RUB");
        }

        [TestMethod]
        public void ConvertToBase_WithZeroRate_ThrowsException()
        {
            // Act and Assert
            AssertEx.ThrowsException<ArgumentException>(() =>
                TestCurrencyConverter.ConvertToBase(100m, "USD", 0m));
        }

        #endregion

        #region GetCurrencySymbol Tests

        [TestMethod]
        public void GetCurrencySymbol_ReturnsCorrectSymbols()
        {
            // Arrange and Act and Assert
            var testCases = new Dictionary<string, string>
            {
                { "RUB", "₽" },
                { "rub", "₽" },
                { "USD", "$" },
                { "EUR", "€" },
                { "KZT", "₸" },
                { "GBP", "£" },
                { "CNY", "¥" }
            };

            foreach (var tc in testCases)
            {
                var result = TestCurrencyConverter.GetCurrencySymbol(tc.Key);
                Assert.AreEqual(tc.Value, result, $"Для валюты {tc.Key}");
            }
        }

        [TestMethod]
        public void GetCurrencySymbol_WhenUnknownCurrency_ReturnsOriginalCode()
        {
            // Arrange
            string[] unknownCurrencies = { "XXX", "ABC", "UNKNOWN" };

            foreach (var currency in unknownCurrencies)
            {
                // Act
                var result = TestCurrencyConverter.GetCurrencySymbol(currency);

                // Assert
                Assert.AreEqual(currency, result);
            }
        }

        [TestMethod]
        public void GetCurrencySymbol_WhenNullOrEmpty_HandlesGracefully()
        {
            // Act and Assert
            // Метод возвращает пустую строку для null и для empty
            string resultForNull = TestCurrencyConverter.GetCurrencySymbol(null);
            string resultForEmpty = TestCurrencyConverter.GetCurrencySymbol("");

            Assert.AreEqual("", resultForNull, "При null должна возвращаться пустая строка");
            Assert.AreEqual("", resultForEmpty, "При пустой строке должна возвращаться пустая строка");
            Assert.IsNotNull(resultForNull);
            Assert.IsNotNull(resultForEmpty);
        }
        #endregion

        #region IsValidCurrency Tests

        [TestMethod]
        public void IsValidCurrency_WithValidCurrencies_ReturnsTrue()
        {
            // Arrange
            string[] validCurrencies = { "RUB", "USD", "EUR", "KZT", "rub", "usd" };

            foreach (var currency in validCurrencies)
            {
                // Act
                bool isValid = TestCurrencyConverter.IsValidCurrency(currency);

                // Assert
                Assert.IsTrue(isValid, $"Валюта {currency} должна считаться валидной");
            }
        }

        [TestMethod]
        public void IsValidCurrency_WithInvalidCurrencies_ReturnsFalse()
        {
            // Arrange
            string[] invalidCurrencies = { "GBP", "JPY", "CNY", "", "ABC123" };

            foreach (var currency in invalidCurrencies)
            {
                // Act
                bool isValid = TestCurrencyConverter.IsValidCurrency(currency);

                // Assert
                Assert.IsFalse(isValid, $"Валюта {currency} не должна считаться валидной");
            }
        }

        [TestMethod]
        public void IsValidCurrency_WithNull_ReturnsFalse()
        {
            // Act
            bool isValid = TestCurrencyConverter.IsValidCurrency(null);

            // Assert
            Assert.IsFalse(isValid);
        }

        #endregion

        #region Edge Cases Tests

        [TestMethod]
        public void CurrencyConversion_SmallAmounts_RoundToZero()
        {
            // Arrange
            var testCases = new[]
            {
                new { RubPrice = 0.001m, Expected = 0.00m, Description = "0.001 RUB → 0.00 USD" },
                new { RubPrice = 0.004m, Expected = 0.00m, Description = "0.004 RUB → 0.00 USD" },
                new { RubPrice = 0.005m, Expected = 0.00m, Description = "0.005 RUB → 0.00 USD (банковское округление)" },
                new { RubPrice = 0.006m, Expected = 0.01m, Description = "0.006 RUB → 0.01 USD" },
                new { RubPrice = 0.009m, Expected = 0.01m, Description = "0.009 RUB → 0.01 USD" },
                new { RubPrice = 0.01m,  Expected = 0.01m, Description = "0.01 RUB → 0.01 USD" }
            };

            foreach (var tc in testCases)
            {
                // Act
                var result = TestCurrencyConverter.ConvertFromBase(tc.RubPrice, "USD", 1m);

                // Assert
                Assert.AreEqual(tc.Expected, result, tc.Description);
            }
        }

        [TestMethod]
        public void CurrencyConversion_WithExchangeRate_RoundsCorrectly()
        {
            // С реальным курсом
            decimal rate = 90m;

            // 0.10 RUB при курсе 90 = 0.0011 USD = 0.00 USD
            var result1 = TestCurrencyConverter.ConvertFromBase(0.10m, "USD", rate);
            Assert.AreEqual(0.00m, result1, "0.10 RUB при курсе 90 → 0.00 USD");

            // 0.90 RUB при курсе 90 = 0.01 USD
            var result2 = TestCurrencyConverter.ConvertFromBase(0.90m, "USD", rate);
            Assert.AreEqual(0.01m, result2, "0.90 RUB при курсе 90 → 0.01 USD");
        }

        [TestMethod]
        public void CurrencyConversion_MaximumValues_HandlesCorrectly()
        {
            // Arrange
            decimal maxPrice = decimal.MaxValue / 1000m;
            decimal rate = 0.01m;

            // Act
            var result = TestCurrencyConverter.ConvertFromBase(maxPrice, "USD", rate);

            // Assert 
            Assert.IsTrue(result > 0, "Результат должен быть положительным");
            Assert.IsFalse(result == decimal.MaxValue || result == decimal.MinValue,
                "Результат не должен быть на границе переполнения");
        }

        [TestMethod]
        public void CurrencyConversion_MinimumPositiveValue_HandlesCorrectly()
        {
            // Arrange
            decimal minPrice = 0.0001m;
            decimal rate = 10000m;

            // Act
            var result = TestCurrencyConverter.ConvertFromBase(minPrice, "USD", rate);

            // Assert
            Assert.AreEqual(0.00m, result);
        }

        #endregion
    }
}