using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Configuration;
using log4net;

namespace SwagLabs_Automation
{
    public class CorePage
    {
        public static IWebDriver driver; 
        public const string DataPath = "C:\\Users\\muham\\source\\repos\\SwagLabs_Automation\\SwagLabs_Automation\\Data\\Data.xml";
        public static readonly ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static IWebDriver SeleniumInit(string browser)
        {
            // sbshxbshxcs
            try
            {
                switch (browser)
                {
                    case "Chrome":
                        var chromeOptions = new ChromeOptions();
                        chromeOptions.AddArguments("--start-maximized");
                        chromeOptions.AddArguments("--incognito");
                        IWebDriver chromeDriver = new ChromeDriver(chromeOptions);
                        driver = chromeDriver;
                        log.Info("Chrome browser selected and initialized.");
                        break;

                    case "Edge":
                        var edgeOptions = new EdgeOptions();
                        edgeOptions.AddArguments("--start-maximized");
                        edgeOptions.AddArguments("--incognito");
                        IWebDriver edgeDriver = new EdgeDriver(edgeOptions);
                        driver = edgeDriver;
                        log.Info("Edge browser selected and initialized.");
                        break;

                    default:
                        log.Error("Invalid browser type");
                        throw new ArgumentException("Invalid browser type");

                }
            }
            catch (Exception ex)
            {
                log.Error("Error occurred while initializing the browser", ex);
            }

            return driver;
        }


        #region Initializations and Cleanups

        public TestContext instance;
        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        { }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        { }

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        { }

        [ClassCleanup]
        public static void ClassCleanup()
        { }

        [TestInitialize]
        public void TestInit()
        {
            SeleniumInit(ConfigurationManager.AppSettings["Browser"].ToString());
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["url"].ToString());
        }

        [TestCleanup]
        public void TestCleanup()
        {
            string testName = TestContext.TestName;
            TakeScreenShot(testName);
            driver.Close();
        }

        #endregion


        public static void Write(By locator, string value)
        {
            try
            {
                driver.FindElement(locator).SendKeys(value);
                log.Info("Writing value: " + value + " in element: " + locator);
            }
            catch (NoSuchElementException ex)
            {
                log.Error("Element not found: " + locator, ex);
                throw ex;
            }
        }

        public static void Click(By locator)
        {
            try
            {
                driver.FindElement(locator).Click();
                log.Info("Click action performed on element: " + locator);
            }
            catch (Exception ex)
            {
                log.Error("An error occurred while performing the click action on element: " + locator, ex);
                throw;
            }
        }

        public static void AssertEqual(By locator, string expectedtext)
        {
            try
            {
                string actualText = driver.FindElement(locator).Text;
                Assert.AreEqual(expectedtext, actualText);
                log.Info("Assertion performed, expected text: " + expectedtext + " actual text: " + actualText);
            }
            catch (Exception ex)
            {
                log.Error("Assertion failed with exception: " + ex);
                throw;
            }
        }

        public static void SelectDropDownMenu(By locator, string value)
        {
            try
            {
                new SelectElement(driver.FindElement(locator)).SelectByValue(value);
                log.Info("Selected value: " + value + " from dropdown menu with locator: " + locator);
            }
            catch (Exception ex)
            {
                log.Error("Error occurred while selecting value from dropdown menu: " + ex.Message);
                throw;
            }
        }


        public static void TakeScreenShot(string testName)
        {
            string timeOfExecution = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");

            // Generate the screenshot file name
            string fileName = testName + "_" + timeOfExecution + ".png";

            // Set the directory path
            string directoryPath = ConfigurationManager.AppSettings["Ss_Path"].ToString();

            // Combine the directory path and file name
            string screenshotFilePath = Path.Combine(directoryPath, fileName);

            // Take a screenshot and save it to the specified directory
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(screenshotFilePath, ScreenshotImageFormat.Png);
            log.Info("Screenshot taken succussfully");
        }
    }
}
