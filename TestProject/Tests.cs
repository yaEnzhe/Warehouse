using Microsoft.VisualStudio.TestTools.UnitTesting;
using WarehouseApp.Forms;

[TestClass]
public class OptionsStaticMethodsTests 
{
    
    [TestCleanup]
    public void Cleanup()
    {
        
        Options.CurrentCurrency = "RUB";
        Options.CurrentExchangeRate = 1;
    }

    #region Тесты для GetCurrencySymbol

    [TestMethod]
    [DataRow("RUB", "₽")]
    [DataRow("USD", "$")]
    [DataRow("EUR", "€")]
    [DataRow("XYZ", "XYZ")]
    public void GetCurrencySymbol_ReturnsCorrectSymbol(string currencyCode, string expectedSymbol)
    {
       
        var result = Options.GetCurrencySymbol(currencyCode);

        Assert.AreEqual(expectedSymbol, result);
    }

    #endregion

    #region Тесты для ConvertFromBase (из рублей в другую валюту)

    [TestMethod]
    public void ConvertFromBase_WhenCurrencyIsRub_ReturnsSameValue()
    {
        Options.CurrentCurrency = "RUB";
        decimal priceInRub = 100.50m;
        var result = Options.ConvertFromBase(priceInRub);
        Assert.AreEqual(100.50m, result);
    }

    [TestMethod]
    public void ConvertFromBase_WhenCurrencyIsUsd_ReturnsConvertedValue()
    {
        Options.CurrentCurrency = "USD";
        Options.CurrentExchangeRate = 75.0m; // 1 USD = 75 RUB
        decimal priceInRub = 150.0m;
        var result = Options.ConvertFromBase(priceInRub); // 150 / 75 = 2
        Assert.AreEqual(2.00m, result);
    }

    #endregion
    #region Тесты для ConvertToBase (из другой валюты в рубли)
    [TestMethod]
    public void ConvertToBase_WhenCurrencyIsKzt_ReturnsConvertedValue()
    {
        Options.CurrentCurrency = "KZT";
        Options.CurrentExchangeRate = 0.17m; // 1 KZT = 0.17 RUB
        decimal priceInKzt = 1000m;
        var result = Options.ConvertToBase(priceInKzt); // 1000 * 0.17 = 170
        Assert.AreEqual(170.00m, result);
    }

    #endregion
}