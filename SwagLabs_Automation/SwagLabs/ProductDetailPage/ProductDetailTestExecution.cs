using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SwagLabs_Automation
{
    [TestClass]
    public class ProductDetailTestExecution
    {
        [TestMethod]
        public void TestMethod1()
        {
            CorePage.driver.Navigate().GoToUrl("https://www.google.com");
        }
    }
}
