using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace SwagLabs_Automation
{
    public class CheckoutPage : CorePage
    {
        #region Locators
        By FirstNameloc = By.Id("first-name");
        By LastNameloc = By.Id("last-name");
        By PostalCodeloc = By.Id("postal-code");
        By CancelBtnloc = By.Id("cancel");
        By ContinueBtnloc = By.Id("continue");
        By EntryErrorloc = By.ClassName("error-message-container");
        By FinishBtnloc = By.Id("finish");
        By ContinueBtnAssertloc = By.CssSelector("div.page_wrapper div:nth-child(1) div.header_container div.header_secondary_container > span.title");
        #endregion

        public void FillDetails(string firstName, string lastName, string postalCode, string expectedText)
        {
            try
            {
                Write(FirstNameloc, firstName);
                Write(LastNameloc, lastName);
                Write(PostalCodeloc, postalCode);
                Click(ContinueBtnloc);
                AssertEqual(ContinueBtnAssertloc, expectedText);
                Click(FinishBtnloc);
                log.Info("Submission with valid details successful");
            }
            catch (Exception ex)
            {
                log.Error("An error occur filling valid details in checkout: " + ex.Message);
                throw;
            }

            
        }

        public void FillWithEmptyDetails(string expectedText)
        {
            try
            {
                Click(ContinueBtnloc);
                AssertEqual(EntryErrorloc, expectedText);
                log.Info("Submission with empty details successful");
            }
            catch (Exception ex)
            {
                log.Error("An error occur Clicking checkout button with empty details: " + ex.Message);
                throw;
            }
        }

        public void FillWithEmptyFirstNameDetails(string lastName, string postalCode, string expectedText)
        {
            try
            {
                Write(LastNameloc, lastName);
                Write(PostalCodeloc, postalCode);
                Click(ContinueBtnloc);
                AssertEqual(EntryErrorloc, expectedText);
                log.Info("Submission with empty firstname successful");
            }
            catch (Exception ex)
            {
                log.Error("An error occur Clicking checkout button with empty firstname: " + ex.Message);
                throw;
            }
        }

        public void FillWithEmptyLastNameDetails(string firstName, string postalCode, string expectedText)
        {
            try
            {
                Write(FirstNameloc, firstName);
                Write(PostalCodeloc, postalCode);
                Click(ContinueBtnloc);
                AssertEqual(EntryErrorloc, expectedText);
                log.Info("Submission with empty lastname successful");
            }
            catch (Exception ex)
            {
                log.Error("Error while trying to fill with empty last name details: " + ex.Message);
            }
        }

        public void FillWithEmptyPostalCodeDetails(string firstName, string lastName, string expectedText)
        {
            try
            {
                Write(FirstNameloc, firstName);
                Write(LastNameloc, lastName);
                Click(ContinueBtnloc);
                AssertEqual(EntryErrorloc, expectedText);
                log.Info("Submission with empty postalcode successful");

            }
            catch (Exception ex)
            {
                log.Error("Error while trying to fill with empty postal code details: " + ex.Message);
            }
        }

        public void CancelCheckout()
        {
            Click(CancelBtnloc);
        }
    }
}
