using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WarehouseApp.Tests
{
    /// <summary>
    /// Тестовая обертка для расчета статуса продукта
    /// </summary>
    public static class TestProductStatusHelper
    {
        public static string CalculateStatus(int stock, DateTime? expirationDate, DateTime? productionDate)
        {
            // Списание если нет на складе или срок годности истек
            if (stock <= 0 || (expirationDate.HasValue && expirationDate.Value.Date < DateTime.Today.Date))
                return "Списан";

            if (!expirationDate.HasValue)
                return "Активен";

            bool isDiscountActive = false;

            if (productionDate.HasValue && productionDate.Value < expirationDate.Value)
            {
                TimeSpan total = expirationDate.Value - productionDate.Value;
                DateTime discountStart = expirationDate.Value.Subtract(TimeSpan.FromDays(total.Days / 3));
                isDiscountActive = DateTime.Today >= discountStart;
            }
            else
            {
                DateTime discountStart = expirationDate.Value.AddDays(-30);
                isDiscountActive = DateTime.Today >= discountStart;
            }

            return isDiscountActive ? "Скидка 30%" : "Активен";
        }
    }

    [TestClass]
    public class ProductStatusTests
    {
        private DateTime today;

        [TestInitialize]
        public void SetUp()
        {
            today = DateTime.Today;
        }

        [TestMethod]
        public void CalculateStatus_WhenStockIsZero_ReturnsSpisan()
        {
            // Arrange
            int stock = 0;
            DateTime? expiration = null;

            // Act
            string status = TestProductStatusHelper.CalculateStatus(stock, expiration, null);

            // Assert
            Assert.AreEqual("Списан", status);
        }

        [TestMethod]
        public void CalculateStatus_WhenExpired_ReturnsSpisan()
        {
            // Arrange
            int stock = 10;
            DateTime? expiration = today.AddDays(-1);

            // Act
            string status = TestProductStatusHelper.CalculateStatus(stock, expiration, null);

            // Assert
            Assert.AreEqual("Списан", status);
        }

        [TestMethod]
        public void CalculateStatus_NoExpiration_ReturnsActive()
        {
            // Arrange
            int stock = 10;
            DateTime? expiration = null;

            // Act
            string status = TestProductStatusHelper.CalculateStatus(stock, expiration, null);

            // Assert
            Assert.AreEqual("Активен", status);
        }

        [TestMethod]
        public void CalculateStatus_DiscountPeriodActive_ReturnsDiscount30()
        {
            // Arrange
            int stock = 10;
            DateTime expirationDate = today.AddDays(10); // Истекает через 10 дней
            DateTime productionDate = today.AddDays(-100); // Произведен 100 дней назад

            // Act
            string status = TestProductStatusHelper.CalculateStatus(stock, expirationDate, productionDate);

            // Assert
            Assert.AreEqual("Скидка 30%", status);
        }

        [TestMethod]
        public void CalculateStatus_DiscountNotActive_ReturnsActive()
        {
            // Arrange
            int stock = 10;
            DateTime expirationDate = today.AddDays(90); // Истекает через 90 дней
            DateTime productionDate = today.AddDays(-100); // Произведен 100 дней назад

            // Act
            string status = TestProductStatusHelper.CalculateStatus(stock, expirationDate, productionDate);

            // Assert
            Assert.AreEqual("Активен", status);
        }
    }
}