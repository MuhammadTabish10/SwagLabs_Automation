using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.UI.WebControls;

namespace SwagLabs_Automation
{
    [TestClass]
    public class ProductDetailTestExecution : CorePage
    {
        LoginPage loginPage = new LoginPage();
        ProductPage productPage = new ProductPage();
        ProductDetailPage productDetailPage = new ProductDetailPage();

        [TestMethod]
        [TestCategory("Positive"), TestCategory("ProductDetail")]
        [Owner("Tabish")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", DataPath, "ClickAndOpenProductDetailTC_001", DataAccessMethod.Sequential)]
        public void AddAndRemoveProductFromCartTC_001()
        {
            string TextOnProductDetail = TestContext.DataRow["TextOnProductDetail"].ToString();
            string TextOnProductPage = TestContext.DataRow["TextOnProductPage"].ToString();

            loginPage.LoginWithValidDetails("standard_user", "secret_sauce", "PRODUCTS");
            productPage.OpenProduct(TextOnProductDetail);
            productDetailPage.AddProductToCart();
            productDetailPage.RemoveFromCart();
            productDetailPage.CloseProduct(TextOnProductPage);
        }

        [TestMethod]
        [TestCategory("Positive"), TestCategory("ProductDetail")]
        [Owner("Tabish")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", DataPath, "OpenCartTC_002", DataAccessMethod.Sequential)]
        public void OpenCartTC_002()
        {
            string TextOnProductDetail = TestContext.DataRow["TextOnProductDetail"].ToString();
            string value = TestContext.DataRow["value"].ToString();

            loginPage.LoginWithValidDetails("standard_user", "secret_sauce", "PRODUCTS");
            productPage.OpenProduct(TextOnProductDetail);
            productDetailPage.AddProductToCart();
            productDetailPage.OpenCart(value);
        }
    }
}
