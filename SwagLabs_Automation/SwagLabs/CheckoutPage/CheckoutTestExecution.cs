using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SwagLabs_Automation
{
    [TestClass]
    public class CheckoutTestExecution : CorePage
    {
        LoginPage loginPage = new LoginPage();
        ProductPage productPage = new ProductPage();
        ProductDetailPage productDetailPage = new ProductDetailPage();
        CartPage cartPage = new CartPage();
        CheckoutPage checkoutPage = new CheckoutPage();


        [TestMethod]
        [TestCategory("Positive"), TestCategory("Checkout")]
        [Owner("Tabish")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", DataPath, "EnterDetailsTC_001", DataAccessMethod.Sequential)]
        public void EnterDetailsTC_001()
        {
            #region GetDataFromXML
            string TextOnProductDetail = TestContext.DataRow["TextOnProductDetail"].ToString();
            string value = TestContext.DataRow["value"].ToString();
            string TextOnCheckoutPage = TestContext.DataRow["TextOnCheckoutPage"].ToString();
            string firstName = TestContext.DataRow["firstName"].ToString();
            string lastName = TestContext.DataRow["lastName"].ToString();
            string postalCode = TestContext.DataRow["postalCode"].ToString();
            string expectedText = TestContext.DataRow["expectedText"].ToString();
            #endregion

            loginPage.LoginWithValidDetails("standard_user", "secret_sauce", "PRODUCTS");
            productPage.OpenProduct(TextOnProductDetail);
            productDetailPage.AddProductToCart();
            productDetailPage.OpenCart(value);
            cartPage.CheckoutBtn(TextOnCheckoutPage);
            checkoutPage.FillDetails(firstName, lastName, postalCode, expectedText);
        }

        [TestMethod]
        [TestCategory("Negative"), TestCategory("Checkout")]
        [Owner("Tabish")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", DataPath, "EnterEmptyDetailsTC_002", DataAccessMethod.Sequential)]
        public void EnterEmptyDetailsTC_002()
        {
            #region GetDataFromXML
            string TextOnProductDetail = TestContext.DataRow["TextOnProductDetail"].ToString();
            string value = TestContext.DataRow["value"].ToString();
            string TextOnCheckoutPage = TestContext.DataRow["TextOnCheckoutPage"].ToString();
            string expectedText = TestContext.DataRow["expectedText"].ToString();
            #endregion

            loginPage.LoginWithValidDetails("standard_user", "secret_sauce", "PRODUCTS");
            productPage.OpenProduct(TextOnProductDetail);
            productDetailPage.AddProductToCart();
            productDetailPage.OpenCart(value);
            cartPage.CheckoutBtn(TextOnCheckoutPage);
            checkoutPage.FillWithEmptyDetails(expectedText);
        }

        [TestMethod]
        [TestCategory("Negative"), TestCategory("Checkout")]
        [Owner("Tabish")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", DataPath, "FillWithEmptyFirstNameDetailsTC_003", DataAccessMethod.Sequential)]
        public void FillWithEmptyFirstNameDetailsTC_003()
        {
            #region GetDataFromXML
            string TextOnProductDetail = TestContext.DataRow["TextOnProductDetail"].ToString();
            string value = TestContext.DataRow["value"].ToString();
            string TextOnCheckoutPage = TestContext.DataRow["TextOnCheckoutPage"].ToString();
            string lastName = TestContext.DataRow["lastName"].ToString();
            string postalCode = TestContext.DataRow["postalCode"].ToString();
            string expectedText = TestContext.DataRow["expectedText"].ToString();
            #endregion

            loginPage.LoginWithValidDetails("standard_user", "secret_sauce", "PRODUCTS");
            productPage.OpenProduct(TextOnProductDetail);
            productDetailPage.AddProductToCart();
            productDetailPage.OpenCart(value);
            cartPage.CheckoutBtn(TextOnCheckoutPage);
            checkoutPage.FillWithEmptyFirstNameDetails(lastName, postalCode, expectedText);
        }

        [TestMethod]
        [TestCategory("Negative"), TestCategory("Checkout")]
        [Owner("Tabish")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", DataPath, "FillWithEmptyLastNameDetailsTC_004", DataAccessMethod.Sequential)]
        public void FillWithEmptyLastNameDetailsTC_004()
        {
            #region GetDataFromXML
            string TextOnProductDetail = TestContext.DataRow["TextOnProductDetail"].ToString();
            string value = TestContext.DataRow["value"].ToString();
            string TextOnCheckoutPage = TestContext.DataRow["TextOnCheckoutPage"].ToString();
            string firstName = TestContext.DataRow["firstName"].ToString();
            string postalCode = TestContext.DataRow["postalCode"].ToString();
            string expectedText = TestContext.DataRow["expectedText"].ToString();
            #endregion

            loginPage.LoginWithValidDetails("standard_user", "secret_sauce", "PRODUCTS");
            productPage.OpenProduct(TextOnProductDetail);
            productDetailPage.AddProductToCart();
            productDetailPage.OpenCart(value);
            cartPage.CheckoutBtn(TextOnCheckoutPage);
            checkoutPage.FillWithEmptyLastNameDetails(firstName, postalCode, expectedText);
        }

        [TestMethod]
        [TestCategory("Negative"), TestCategory("Checkout")]
        [Owner("Tabish")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", DataPath, "FillWithEmptyPostalCodeDetailsTC_005", DataAccessMethod.Sequential)]
        public void FillWithEmptyPostalCodeDetailsTC_005()
        {
            #region GetDataFromXML
            string TextOnProductDetail = TestContext.DataRow["TextOnProductDetail"].ToString();
            string value = TestContext.DataRow["value"].ToString();
            string TextOnCheckoutPage = TestContext.DataRow["TextOnCheckoutPage"].ToString();
            string firstName = TestContext.DataRow["firstName"].ToString();
            string lastName = TestContext.DataRow["lastName"].ToString();
            string expectedText = TestContext.DataRow["expectedText"].ToString();
            #endregion

            loginPage.LoginWithValidDetails("standard_user", "secret_sauce", "PRODUCTS");
            productPage.OpenProduct(TextOnProductDetail);
            productDetailPage.AddProductToCart();
            productDetailPage.OpenCart(value);
            cartPage.CheckoutBtn(TextOnCheckoutPage);
            checkoutPage.FillWithEmptyPostalCodeDetails(firstName, lastName, expectedText);
        }
    }
}
