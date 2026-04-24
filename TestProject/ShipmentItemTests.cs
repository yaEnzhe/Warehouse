using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WarehouseApp.Tests
{
    public class TestShipmentItem
    {
        public decimal PricePerUnit { get; set; }
        public int Quantity { get; set; }
        public decimal TotalSum => PricePerUnit * Quantity;
    }

    [TestClass]
    public class ShipmentItemTests
    {
        [TestMethod]
        public void TotalSum_WhenValidValues_ReturnsCorrectProduct()
        {
            // Arrange
            var item = new TestShipmentItem { PricePerUnit = 100m, Quantity = 5 };

            // Act
            decimal total = item.TotalSum;

            // Assert
            Assert.AreEqual(500m, total);
        }

        [TestMethod]
        public void TotalSum_WhenZeroQuantity_ReturnsZero()
        {
            // Arrange
            var item = new TestShipmentItem { PricePerUnit = 100m, Quantity = 0 };

            // Act
            decimal total = item.TotalSum;

            // Assert
            Assert.AreEqual(0m, total);
        }

        [TestMethod]
        public void TotalSum_WhenZeroPrice_ReturnsZero()
        {
            // Arrange
            var item = new TestShipmentItem { PricePerUnit = 0m, Quantity = 10 };

            // Act
            decimal total = item.TotalSum;

            // Assert
            Assert.AreEqual(0m, total);
        }

        [TestMethod]
        public void TotalSum_WithDecimals_ReturnsCorrectProduct()
        {
            // Arrange
            var item = new TestShipmentItem { PricePerUnit = 99.99m, Quantity = 3 };

            // Act
            decimal total = item.TotalSum;

            // Assert
            Assert.AreEqual(299.97m, total);
        }

        [TestMethod]
        public void TotalSum_WithLargeNumbers_HandlesCorrectly()
        {
            // Arrange
            var item = new TestShipmentItem { PricePerUnit = 1000000m, Quantity = 1000 };

            // Act
            decimal total = item.TotalSum;

            // Assert
            Assert.AreEqual(1000000000m, total);
        }
    }
}