using System;
using Automation.Core.SeleniumUtility;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;


namespace WebUI.Automation.Pages.Inbox
{
    public class InboxPage : BasePage
    {
        private IExtendedWebDriver driver;
        private WebDriverWait mWait;
        public InboxPage(IExtendedWebDriver webDriver, Options options, WebDriverWait wait) : base(webDriver)
        {
            this.driver = webDriver;
            PageFactory.InitElements(WebDriver, this);
            mWait = wait;
            PageTitleName = "Inbox";
        }

        //Locate the elements on the pages
        [FindsBy(How = How.XPath, Using = "//div/a/span[@class='gb_ab gbii']")]
        public IWebElement menu;

        [FindsBy(How = How.XPath, Using = "//*[@id='gb_71']")]
        public IWebElement signOut;

        public string GetMailInboxUrl()
        {
            string inboxUrl = driver.Url;
            return inboxUrl;
        }
        public override bool VerifyPage()
        {   
            System.Console.Write("Verify page: Page title is "+ driver.Title);
            mWait.Until(ExpectedConditions.TitleContains(PageTitleName));
            return true;
        }
    }
}
