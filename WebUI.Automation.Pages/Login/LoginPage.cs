using Automation.Core.SeleniumUtility;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace WebUI.Automation.Pages.Login
{
    public class LoginPage : BasePage
    {
        private IExtendedWebDriver driver;
        private WebDriverWait mWait;

        public LoginPage(IExtendedWebDriver webDriver, Options options, WebDriverWait wait) : base(webDriver)
        {
            this.driver = webDriver;
            PageFactory.InitElements(WebDriver, this);
            mWait = wait;
            PageTitleName = "Gmail";
        }

        //Locate the elements on the pages
        [FindsBy(How = How.XPath, Using = "//input[@id='identifierId']")]
        public IWebElement email_phone;

        [FindsBy(How = How.Id, Using = "identifierNext")]
        public IWebElement identifierNext;

        [FindsBy(How = How.XPath, Using = "//input[@name='password']")]
        public IWebElement password;

        [FindsBy(How = How.Id, Using = "passwordNext")]
        public IWebElement login;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"password\"]/div[2]/div[2]")]
        public IWebElement wrongPasswordMessage;

        //Define basic methods on the page
        public string RetrunErrorMessage()
        {
            string errorMessage = wrongPasswordMessage.Text;
            return errorMessage;
        }

        public void SetUserIdentifier(string strUserId)
        {
            email_phone.SendKeys(strUserId);
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

        //Login method
        public void LoginToGmail(string strUserId, string strPassword)
        {
            System.Console.Write("userIdentifier = "+strUserId+", password = "+strPassword);
            SetUserIdentifier(strUserId);
            ClickNext();
            mWait.Until(ExpectedConditions.ElementToBeClickable(password));
            SetPassword(strPassword);
            ClickLogin();
        }

    }
}