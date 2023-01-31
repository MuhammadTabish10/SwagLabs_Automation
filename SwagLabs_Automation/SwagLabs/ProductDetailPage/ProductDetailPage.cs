using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V107.Network;
using System;
using System.Linq;

namespace SwagLabs_Automation
{
    public class ProductDetailPage : CorePage
    {
        #region Locators
        By ProductDetailBackBtnloc = By.ClassName("inventory_details_back_button");
        By ProductPageAssertloc = By.CssSelector("#header_container > div.header_secondary_container > span");
        By AddToCartBtnloc = By.ClassName("btn_inventory");
        By RemoveFromCartBtnloc = By.ClassName("btn_secondary");
        By CartBadgeloc = By.ClassName("shopping_cart_badge");
        By CartIconloc = By.Id("shopping_cart_container");
        By CartIconAssertloc = By.CssSelector("div.page_wrapper div:nth-child(1) div.header_container div.header_secondary_container > span.title");
        #endregion

        public void CloseProduct(string TextOnProductPage)
        {
            try
            {
                Click(ProductDetailBackBtnloc);
                AssertEqual(ProductPageAssertloc, TextOnProductPage);
                log.Info("Product Page has been Closed.");
            }
            catch (Exception ex)
            {
                log.Error("Error closing product page: " + ex.Message);
            }
        }

        public void AddProductToCart()
        {
            try
            {
                Click(AddToCartBtnloc);
                AssertEqual(CartBadgeloc, "1");
                log.Info("Product has been Added.");
            }
            catch (Exception ex)
            {
                log.Error("Error adding product to cart: " + ex.Message);
                throw;
            }
        }

        public void RemoveFromCart() 
        {
            try
            {
                string check = driver.FindElement(CartBadgeloc).Text;
                if (new[] { "1", "2", "3", "4", "5", "6" }.Contains(check))
                {
                    Click(RemoveFromCartBtnloc);
                    log.Info("Product has been Removed.");
                }
                else { }
            }
            catch (Exception ex)
            {
                log.Error("Error removing item from cart: " + ex.Message);
                throw;
            }
        }

        public void OpenCart(string value)
        {
            try
            {
                Click(CartIconloc);
                AssertEqual(CartIconAssertloc, value);
                log.Info("CartPage has been Asserted.");
            }
            catch (Exception ex)
            {
                log.Error("Error opening cart: " + ex.Message);
                throw;
            }
        }
    }
}
