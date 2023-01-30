using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using log4net;

namespace SwagLabs_Automation
{
    public class LoginPage : CorePage
    {
        #region Locators
        By Usernameloc = By.Id("user-name");
        By Passwordloc = By.Id("password");
        By LoginBtnloc = By.Id("login-button");
        By AssertLoginSuccussloc = By.CssSelector("#header_container > div.header_secondary_container > span");
        By AssertLoginErrorloc = By.ClassName("error-message-container");
        #endregion

        public void LoginWithValidDetails(string user, string pass, string expectedtext)
        {
            try
            {
                Write(Usernameloc, user);
                Write(Passwordloc, pass);
                Click(LoginBtnloc);

                AssertEqual(AssertLoginSuccussloc, expectedtext);
                log.Info("Login with valid details is successful");
            }
            catch (Exception ex)
            {
                log.Error("Error occurred during login with valid details: " + ex.Message);
                throw;
            }
        }

        public void LoginWithInvalidDetails(string user, string pass, string expectedtext)
        {
            try
            {
                Write(Usernameloc, user);
                Write(Passwordloc, pass);
                Click(LoginBtnloc);

                AssertEqual(AssertLoginErrorloc, expectedtext);
                log.Info("Login with invalid details is successful");
            }
            catch (Exception ex)
            {
                log.Error("Error occurred during login with invalid details: " + ex.Message);
                throw;
            }
        }

        public void LoginWithEmptyDetails(string expectedtext)
        {
            try
            {
                Click(LoginBtnloc);
                AssertEqual(AssertLoginErrorloc, expectedtext);
                log.Info("Login with empty details is successful");
            }
            catch (Exception ex)
            {
                log.Error("Error occurred during login with empty details: " + ex.Message);
                throw;
            }
        }

        public void LoginWithEmptyUsername(string pass, string expectedtext)
        {
            try
            {
                Write(Passwordloc, pass);
                Click(LoginBtnloc);

                AssertEqual(AssertLoginErrorloc, expectedtext);
                log.Info("Login with empty username is successful");
            }
            catch (Exception ex)
            {
                log.Error("Error occurred during login with empty username: " + ex.Message);
                throw;
            }
        }

        public void LoginWithEmptyPassword(string user, string expectedtext)
        {
            try
            {
                Write(Usernameloc, user);
                Click(LoginBtnloc);

                AssertEqual(AssertLoginErrorloc, expectedtext);
                log.Info("Login with empty password is successful");
            }
            catch (Exception ex)
            {
                log.Error("Error occurred during login with empty password: " + ex.Message);
                throw;
            }
        }
    }
}
