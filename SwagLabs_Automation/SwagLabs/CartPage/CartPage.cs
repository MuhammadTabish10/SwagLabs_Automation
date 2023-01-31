using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Linq;

namespace SwagLabs_Automation
{
    public class CartPage : CorePage
    {
        #region Locators
        By ContinueShoppingBtnloc = By.Id("continue-shopping");
        By CheckoutBtnloc = By.Id("checkout");
        By CartBadgeloc = By.ClassName("shopping_cart_badge");
        By RemoveFromCartBtnloc = By.ClassName("btn_secondary");
        By ProductPageAssertloc = By.CssSelector("#header_container > div.header_secondary_container > span");
        By CheckoutBtnAssertloc = By.CssSelector("div.page_wrapper div:nth-child(1) div.header_container div.header_secondary_container > span.title");
        #endregion

        public void ContinueShopping(string TextOnProductPage)
        {
            try
            {
                log.Info("Clicking on ContinueShopping");
                Click(ContinueShoppingBtnloc);
                AssertEqual(ProductPageAssertloc, "PRODUCTS");
            }
            catch (Exception ex)
            {
                log.Error("An error occur while returning to the product page by clicking ContinueShopping button: " + ex.Message);
                throw;
            }

            
        }
        public void CheckoutBtn(string TextOnCheckoutPage)
        {
            try
            {
                log.Info("Clicking on ContinueShopping");
                Click(CheckoutBtnloc);
                AssertEqual(CheckoutBtnAssertloc, TextOnCheckoutPage);
            }
            catch (Exception ex)
            {
                log.Error("An error occur while clicking on Checkout Button: " + ex.Message);
                throw;
            }

            
        }

        public void RemoveFromCart()
        {
            string check = driver.FindElement(CartBadgeloc).Text;
            try
            {
                if (new[] { "1", "2", "3", "4", "5", "6" }.Contains(check))
                {
                    Click(RemoveFromCartBtnloc);
                    log.Info("Product has been Removed.");
                }
                else { }
            }
            catch (Exception ex)
            {
                log.Error("An error occur while removing a product: " + ex.Message);
                throw;
            }
        }
    }
}
