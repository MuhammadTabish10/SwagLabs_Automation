using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using System;
using System.Collections.ObjectModel;
using System.Configuration;

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
        By ProductNameloc = By.ClassName("inventory_item_name");
        By TwitterBtnloc = By.ClassName("social_twitter");
        By TwitterAssertloc = By.XPath("//body/div[@id='react-root']/div[1]/div[1]/div[2]/main[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/span[1]");
        By FacebookBtnloc = By.ClassName("social_facebook");
        By FacebookAssertloc = By.LinkText("Log in");
        By LinkedinBtnloc = By.ClassName("social_linkedin");
        By LinkedinAssertloc = By.LinkText("");
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

        public void AlphabetFilter(string productName, string value)
        {
            SelectDropDownMenu(SortDropDownloc, value);
            AssertEqual(ProductNameloc, productName);
        }

        public void PriceFilter(string productPrice, string value)
        {
            SelectDropDownMenu(SortDropDownloc, value);
            AssertEqual(ProductPriceloc, productPrice);
        }

        public void SocialMediaButtons(string twitterValue, string facebookValue, string linkedinValue)
        {
            log.Info("Clicking on Twitter button and asserting its value");
            ClickAndAssertSocialMediaButtons(TwitterBtnloc, TwitterAssertloc, twitterValue);

            log.Info("Clicking on Facebook button and asserting its value");
            ClickAndAssertSocialMediaButtons(FacebookBtnloc, FacebookAssertloc, facebookValue);

            //log.Info("Clicking on Linkedin button and asserting its value");
            //ClickAndAssertSocialMediaButtons(LinkedinBtnloc, LinkedinAssertloc, linkedinValue);
        }
        public void ClickAndAssertSocialMediaButtons(By buttonLocator, By assertLocator, string value)
        {
            string currentWindow = driver.CurrentWindowHandle;

            log.Info("Clicking on the button");
            Click(buttonLocator);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(11);

            log.Info("Waiting for new window to open");
            ReadOnlyCollection<string> windowHandles = driver.WindowHandles;
            foreach (string windowHandle in windowHandles)
            {
                if (!windowHandle.Equals(currentWindow))
                {
                    driver.SwitchTo().Window(windowHandle);
                    break;
                }
            }

            log.Info("Asserting the value");
            AssertEqual(assertLocator, value);

            log.Info("Closing the window and switching back to main window");
            driver.Close();
            driver.SwitchTo().Window(currentWindow);
        }
    }
}
