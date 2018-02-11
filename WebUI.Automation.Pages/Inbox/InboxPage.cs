using Automation.Core.SeleniumUtility;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebUI.Automation.Pages.Inbox
{
    public class InboxPage : BasePage
    {
        // Locate the elements on the pages
        [FindsBy(How = How.XPath, Using = "//div/a/span[@class='gb_ab gbii']")]
        public IWebElement menu;

        [FindsBy(How = How.XPath, Using = "//*[@id='gb_71']")]
        public IWebElement signOut;

        public InboxPage(IExtendedWebDriver webDriver, Options options) : base(webDriver)
        {
            PageTitleName = "Inbox";
        }

        public override bool VerifyPage()
        {   
            Console.WriteLine("Inbox VerifyPage: Page title is " + WebDriver.Title + "\n");
            WebWait.Until(ExpectedConditions.TitleContains(PageTitleName));

            return true;
        }
    }
}