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
    }
}
