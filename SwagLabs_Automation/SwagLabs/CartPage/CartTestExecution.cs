using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SwagLabs_Automation
{
    [TestClass]
    public class CartTestExecution : CorePage
    {
        LoginPage loginPage = new LoginPage();
        ProductPage productPage = new ProductPage();
        ProductDetailPage productDetailPage = new ProductDetailPage();
        CartPage cartPage = new CartPage();

        [TestMethod]
        [TestCategory("Positive"), TestCategory("Cart")]
        [Owner("Tabish")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", DataPath, "RemoveProductAndCheckContinueBtnTC_001", DataAccessMethod.Sequential)]
        public void RemoveProductAndCheckContinueBtnTC_001()
        {
            #region GetDataFromXML
            string TextOnProductDetail = TestContext.DataRow["TextOnProductDetail"].ToString();
            string value = TestContext.DataRow["value"].ToString();
            string TextOnProductPage = TestContext.DataRow["value"].ToString();
            #endregion

            loginPage.LoginWithValidDetails("standard_user", "secret_sauce", "PRODUCTS");
            productPage.OpenProduct(TextOnProductDetail);
            productDetailPage.AddProductToCart();
            productDetailPage.OpenCart(value);
            cartPage.RemoveFromCart();
            cartPage.ContinueShopping(TextOnProductPage);
        }

        [TestMethod]
        [TestCategory("Positive"), TestCategory("Cart")]
        [Owner("Tabish")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", DataPath, "ProceedToCheckoutTC_002", DataAccessMethod.Sequential)]
        public void ProceedToCheckoutTC_002()
        {
            #region GetDataFromXML
            string TextOnProductDetail = TestContext.DataRow["TextOnProductDetail"].ToString();
            string value = TestContext.DataRow["value"].ToString();
            string TextOnCheckoutPage = TestContext.DataRow["TextOnCheckoutPage"].ToString();
            #endregion

            loginPage.LoginWithValidDetails("standard_user", "secret_sauce", "PRODUCTS");
            productPage.OpenProduct(TextOnProductDetail);
            productDetailPage.AddProductToCart();
            productDetailPage.OpenCart(value);
            cartPage.CheckoutBtn(TextOnCheckoutPage);
        }
    }
}
