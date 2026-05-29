using WarehouseApp.Classes;
namespace TestProject3
{
    [TestClass]
    public class ContractorCheckResultTests
    {
        [TestMethod]
        public void Success_ShouldReturnSuccessfulResultWithGivenMessage()
        {
            string expectedMessage = "Контрагент проверен успешно";
            var result = ContractorCheckResult.Success(expectedMessage);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsSuccess);
            Assert.IsFalse(result.ShouldBlockOperation);
            Assert.AreEqual(expectedMessage, result.Message);
        }

        [TestMethod]
        public void Error_WithoutBlockFlag_ShouldReturnFailedResult()
        {
            string errorMessage = "Контрагент не найден в реестре";
            var result = ContractorCheckResult.Error(errorMessage);
            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsSuccess);
            Assert.IsFalse(result.ShouldBlockOperation);
            Assert.AreEqual(errorMessage, result.Message);
        }

        [TestMethod]
        public void Error_WithBlockFlagTrue_ShouldSetShouldBlockOperationToTrue()
        {
            string errorMessage = "Контрагент заблокирован";
            bool blockOperation = true;
            var result = ContractorCheckResult.Error(errorMessage, blockOperation);
            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsSuccess);
            Assert.IsTrue(result.ShouldBlockOperation);
            Assert.AreEqual(errorMessage, result.Message);
        }

        [TestMethod]
        public void Error_WithBlockFlagFalse_ShouldSetShouldBlockOperationToFalse()
        {
            string errorMessage = "Ошибка, но операцию не блокируем";
            bool blockOperation = false;
            var result = ContractorCheckResult.Error(errorMessage, blockOperation);
            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsSuccess);
            Assert.IsFalse(result.ShouldBlockOperation);
            Assert.AreEqual(errorMessage, result.Message);
        }

        [TestMethod]
        public void Success_ShouldAllowEmptyOrNullMessage()
        {
            var resultWithEmpty = ContractorCheckResult.Success("");
            Assert.AreEqual("", resultWithEmpty.Message);
            var resultWithNull = ContractorCheckResult.Success(null);
            Assert.IsNull(resultWithNull.Message);
        }

        [TestMethod]
        public void Error_ShouldAllowEmptyOrNullMessage()
        {
            var resultWithEmpty = ContractorCheckResult.Error("");
            Assert.AreEqual("", resultWithEmpty.Message);
            var resultWithNull = ContractorCheckResult.Error(null);
            Assert.IsNull(resultWithNull.Message);
        }
    }
}
