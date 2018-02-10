using Automation.Configuration;
using Automation.Core.SeleniumUtility;
using TechTalk.SpecFlow;
using WebUI.Automation.Pages;
using WebUI.Automation.Pages.Login;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace WebUI.Automation.Tests.Steps
{
    [Binding]
	public class LoginSteps : StandardStepsBase
	{
        public string mUrl;
        public string mValidUser;
        public string mValidPasswd;
        public string mInvalidPasswd;
        public LoginPage mLoginPage;
        public WebDriverWait mWait;

        public LoginSteps(IExtendedWebDriver webDriver, Options options, WebDriverWait wait) : base(webDriver, options, wait)
		{
            mUrl = options.SiteUri.ToString();
            mValidUser = Constants.VALID_USER_NAME;
            mValidPasswd = Constants.VALID_PASSWORD;
            mInvalidPasswd = Constants.INVALID_PASSWORD;
            mLoginPage = new LoginPage(WebDriver, options, wait);
            mWait = wait;
         
		}

        [Given(@"I am on the Gmail login screen")]
        public void GivenIAmOnTheGmailLoginScreen()
        {
            WebDriver.Navigate().GoToUrl(mUrl);
        }

        [When(@"I submit my valid credentials")]
        public void WhenISubmitMyValidCredentials()
        {
            mLoginPage.LoginToGmail(mValidUser,mValidPasswd);
        }

        [Then(@"I see my Gmail Inbox")]
        public void ThenISeeMyGmailInbox()
        {
            mWait.Until(ExpectedConditions.TitleContains("Inbox"));
            Assert.AreEqual(mLoginPage.GetMailInboxUrl(), "https://mail.google.com/mail/#inbox");  
        }

        [When(@"I submit invalid credentials")]
        public void WhenISubmitInvalidCredentials()
        {
            mLoginPage.LoginToGmail(mValidUser, mInvalidPasswd);
        }

        [Then(@"I remain on the Gmail login screen")]
        public void ThenIRemainOnTheGmailLoginScreen()
        {
            Assert.AreEqual(WebDriver.Title,"Gmail");
        }

        [Then(@"I am shown a message indicating that my credentials are incorrect")]
        public void ThenIAmShownAMessageIndicatingThatMyCredentialsAreIncorrect()
        {
            Assert.AreEqual(mLoginPage.RetrunErrorMessage(),"Wrong password. Try again or click Forgot password to reset it.");
        }

        [Given(@"I have logged in to my Gmail")]
        public void GivenIHaveLoggedInToMyGmail()
        {
            WebDriver.Navigate().GoToUrl(mUrl);
            mLoginPage.LoginToGmail(mValidUser, mValidPasswd);
            mWait.Until(ExpectedConditions.TitleContains("Inbox"));

        }

        [When(@"I sign out")]
        public void ThenISignOut()
        {
            mLoginPage.menu.Click();
            mLoginPage.signOut.Click();

        }

        [Then(@"I am navigated to the Gmail login screen")]
        public void ThenIAmNavigatedToTheGmailLoginScreen()
        {
            Assert.AreEqual(WebDriver.Title,"Gmail");
        }
	}
}