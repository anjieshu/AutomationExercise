using System;
using Automation.Core.SeleniumUtility;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace WebUI.Automation.Pages.Login
{
    public class LoginPage : BasePage
    {
        public string ErrorMessage = "Wrong password. Try again or click Forgot password to reset it.";

        //Locate the elements on the pages
        [FindsBy(How = How.XPath, Using = "//input[@id='identifierId']")]
        public IWebElement userID;

        [FindsBy(How = How.Id, Using = "identifierNext")]
        public IWebElement identifierNext;

        [FindsBy(How = How.XPath, Using = "//input[@name='password']")]
        public IWebElement password;

        [FindsBy(How = How.Id, Using = "passwordNext")]
        public IWebElement login;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"password\"]/div[2]/div[2]")]
        public IWebElement wrongPasswordMessage;

        public LoginPage(IExtendedWebDriver webDriver, Options options) : base(webDriver)
        {
            PageTitleName = "Gmail";
        }

        //Define basic methods on the page
        public string RetrunErrorMessage()
        {
            return wrongPasswordMessage.Text;
        }

        public void SetUserIdentifier(string strUserId)
        {
            userID.SendKeys(strUserId);
        }

        public void SetPassword(string strPassword)
        {
            password.SendKeys(strPassword);
        }

        public void ClickNext()
        {
            identifierNext.Click();
        }

        public void ClickLogin()
        {
            login.Click();
        }

        // Login method
        public void LoginToGmail(string strUserId, string strPassword)
        {
            Console.WriteLine("userIdentifier=" + strUserId + ", password=" + strPassword);
            SetUserIdentifier(strUserId);
            ClickNext();
            WebWait.Until(ExpectedConditions.ElementToBeClickable(password));
            SetPassword(strPassword);
            WebWait.Until(ExpectedConditions.ElementToBeClickable(login));
            ClickLogin();
        }

        // Verify Error Message
        public bool VerifyErrorMessage()
        {
            return RetrunErrorMessage().Equals(ErrorMessage);
        }

        public override bool VerifyPage()
        {
            Console.WriteLine("Login VerifyPage: Page title is " + WebDriver.Title);
            WebWait.Until(ExpectedConditions.TitleIs(PageTitleName));
            return true;
        }
    }
}
