using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SwagLabs_Automation
{
    [TestClass]
    public class ProductTestExecution : CorePage
    {
        LoginPage loginPage = new LoginPage();
        ProductPage productPage = new ProductPage();

        [TestMethod]
        [TestCategory("Positive"), TestCategory("Product")]
        [Owner("Tabish")]
        public void AddAndRemoveAllProductsToCartTC_001()
        {
            loginPage.LoginWithValidDetails("standard_user", "secret_sauce", "PRODUCTS");
            productPage.AddAllProductsToCart();
            productPage.RemoveAllProductsFromCart();
        }

        [TestMethod]
        [TestCategory("Positive"), TestCategory("Product")]
        [Owner("Tabish")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", DataPath, "AToZFilterTC_002", DataAccessMethod.Sequential)]
        public void AToZFilterTC_002()
        {
            loginPage.LoginWithValidDetails("standard_user", "secret_sauce", "PRODUCTS");
            string productName = TestContext.DataRow["productName"].ToString();
            string value = TestContext.DataRow["value"].ToString();
            productPage.AlphabetFilter(productName, value);
        }

        [TestMethod]
        [TestCategory("Positive"), TestCategory("Product")]
        [Owner("Tabish")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", DataPath, "ZToAFilterTC_003", DataAccessMethod.Sequential)]
        public void ZToAFilterTC_003()
        {
            loginPage.LoginWithValidDetails("standard_user", "secret_sauce", "PRODUCTS");
            string productName = TestContext.DataRow["productName"].ToString();
            string value = TestContext.DataRow["value"].ToString();
            productPage.AlphabetFilter(productName, value);
        }

        [TestMethod]
        [TestCategory("Positive"), TestCategory("Product")]
        [Owner("Tabish")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", DataPath, "LowToHighPriceFilterTC_004", DataAccessMethod.Sequential)]
        public void LowToHighPriceFilterTC_004()
        {
            loginPage.LoginWithValidDetails("standard_user", "secret_sauce", "PRODUCTS");
            string productPrice = TestContext.DataRow["productPrice"].ToString();
            string value = TestContext.DataRow["value"].ToString();
            productPage.PriceFilter(productPrice, value);
        }

        [TestMethod]
        [TestCategory("Positive"), TestCategory("Product")]
        [Owner("Tabish")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", DataPath, "HighToLowPriceFilterTC_005", DataAccessMethod.Sequential)]
        public void HighToLowPriceFilterTC_005()
        {
            loginPage.LoginWithValidDetails("standard_user", "secret_sauce", "PRODUCTS");
            string productPrice = TestContext.DataRow["productPrice"].ToString();
            string value = TestContext.DataRow["value"].ToString();
            productPage.PriceFilter(productPrice, value);
        }

        [TestMethod]
        [TestCategory("Positive"), TestCategory("Product")]
        [Owner("Tabish")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", DataPath, "CheckSocialMediaLinksTC_006", DataAccessMethod.Sequential)]
        public void CheckSocialMediaLinksTC_006()
        {
            loginPage.LoginWithValidDetails("standard_user", "secret_sauce", "PRODUCTS");
            #region DataFromXML
            string twitterValue = TestContext.DataRow["twitterValue"].ToString();
            string facebookValue = TestContext.DataRow["facebookValue"].ToString();
            string linkedinValue = TestContext.DataRow["linkedinValue"].ToString();
            #endregion
            productPage.SocialMediaButtons(twitterValue, facebookValue, linkedinValue);
        }
    }
}