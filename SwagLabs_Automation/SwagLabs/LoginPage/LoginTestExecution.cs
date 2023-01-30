using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Configuration;
using System.Web.UI.WebControls;

namespace SwagLabs_Automation
{
    [TestClass]
    public class LoginTestExecution : CorePage
    {
        LoginPage loginPage = new LoginPage();

        [TestMethod]
        [TestCategory("Positive"), TestCategory("Login")]
        [Owner("Tabish")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", DataPath, "LoginWithValidDetailsTC_001", DataAccessMethod.Sequential)]
        public void LoginWithValidDetailsTC_001()
        {
            #region DataFromXML
            string user = TestContext.DataRow["user"].ToString();
            string pass = TestContext.DataRow["pass"].ToString();
            string expectedtext = TestContext.DataRow["expectedtext"].ToString();
            #endregion
            loginPage.LoginWithValidDetails(user, pass, expectedtext);
        }

        [TestMethod]
        [TestCategory("Negative"), TestCategory("Login")]
        [Owner("Tabish")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", DataPath, "LoginWithInvalidDetailsTC_002", DataAccessMethod.Sequential)]
        public void LoginWithInvalidDetailsTC_002()
        {
            #region DataFromXML
            string user = TestContext.DataRow["user"].ToString();
            string pass = TestContext.DataRow["pass"].ToString();
            string expectedtext = TestContext.DataRow["expectedtext"].ToString();
            #endregion
            loginPage.LoginWithInvalidDetails(user, pass, expectedtext);
        }

        [TestMethod]
        [TestCategory("Negative"), TestCategory("Login")]
        [Owner("Tabish")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", DataPath, "LoginWithEmptyDetailsTC_003", DataAccessMethod.Sequential)]
        public void LoginWithEmptyDetailsTC_003()
        {
            #region DataFromXML
            string expectedtext = TestContext.DataRow["expectedtext"].ToString();
            #endregion
            loginPage.LoginWithEmptyDetails(expectedtext);
        }

        [TestMethod]
        [TestCategory("Negative"), TestCategory("Login")]
        [Owner("Tabish")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", DataPath, "LoginWithEmptyUsernameTC_004", DataAccessMethod.Sequential)]
        public void LoginWithEmptyUsernameTC_004()
        {
            #region DataFromXML
            string pass = TestContext.DataRow["pass"].ToString();
            string expectedtext = TestContext.DataRow["expectedtext"].ToString();
            #endregion
            loginPage.LoginWithEmptyUsername(pass,expectedtext);
        }

        [TestMethod]
        [TestCategory("Negative"), TestCategory("Login")]
        [Owner("Tabish")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", DataPath, "LoginWithEmptyPasswordTC_005", DataAccessMethod.Sequential)]
        public void LoginWithEmptyPasswordTC_005()
        {
            #region DataFromXML
            string user = TestContext.DataRow["user"].ToString();
            string expectedtext = TestContext.DataRow["expectedtext"].ToString();
            #endregion
            loginPage.LoginWithEmptyPassword(user, expectedtext);
        }
    }
}
