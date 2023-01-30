using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace SwagLabs_Automation
{
    public class ProductPage : CorePage
    {
        #region Locators
        By AddToCartBtnloc = By.ClassName("btn_inventory");
        By RemoveFromCartBtnloc = By.ClassName("btn_secondary");
        By CartBadgeloc = By.ClassName("shopping_cart_badge");
        By SortDropDownloc = By.ClassName("product_sort_container");
        By ProductPriceloc = By.ClassName("inventory_item_price");
        #endregion


        public void AddAllProductsToCart()
        {
            log.Info("Adding all products to cart");
            try
            {
                for (int i = 0; i < 6; i++)
                {
                    driver.FindElements(AddToCartBtnloc)[i].Click();
                    AssertEqual(CartBadgeloc, (i + 1).ToString());
                }
                log.Info("All the products have been added to cart");
            }
            catch (Exception ex)
            {
                log.Error("An error occurred while adding all products to cart", ex);
                throw;
            }
        }

        public void RemoveAllProductsFromCart()
        {
            log.Info("Removing all products from cart");
            try
            {
                int count = int.Parse(driver.FindElement(CartBadgeloc).Text);
                for (int i = count - 1; i >= 0; i--)
                {
                    AssertEqual(CartBadgeloc, (i + 1).ToString());
                    driver.FindElements(RemoveFromCartBtnloc)[i].Click();
                }
                log.Info("All the products have been removed from cart");
            }
            catch (Exception ex)
            {
                log.Error("An error occurred while removing all products from the cart", ex);
                throw;
            }
        }

    }
}
