using Automation.Configuration;
using Automation.Core.SeleniumUtility;
using TechTalk.SpecFlow;
using WebUI.Automation.Pages;
using WebUI.Automation.Pages.Login;
using WebUI.Automation.Pages.Inbox;
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
        public InboxPage mInboxPage;

        public LoginSteps(IExtendedWebDriver webDriver, Options options) : base(webDriver, options)
	    {
            mUrl = options.SiteUri.ToString();
            mValidUser = Constants.VALID_USER_NAME;
            mValidPasswd = Constants.VALID_PASSWORD;
            mInvalidPasswd = Constants.INVALID_PASSWORD;
            mLoginPage = new LoginPage(WebDriver, options);
            mInboxPage = new InboxPage(WebDriver, options);
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
            Assert.IsTrue(mInboxPage.VerifyPage());
        }

        [When(@"I submit invalid credentials")]
        public void WhenISubmitInvalidCredentials()
        {
            mLoginPage.LoginToGmail(mValidUser, mInvalidPasswd);
        }

        [Then(@"I remain on the Gmail login screen")]
        public void ThenIRemainOnTheGmailLoginScreen()
        {
            Assert.IsTrue(mLoginPage.VerifyPage());
        }

        [Then(@"I am shown a message indicating that my credentials are incorrect")]
        public void ThenIAmShownAMessageIndicatingThatMyCredentialsAreIncorrect()
        {
            Assert.IsTrue(mLoginPage.VerifyErrorMessage());
        }

        [Given(@"I have logged in to my Gmail")]
        public void GivenIHaveLoggedInToMyGmail()
        {
            WebDriver.Navigate().GoToUrl(mUrl);
            Assert.IsTrue(mLoginPage.VerifyPage());
            mLoginPage.LoginToGmail(mValidUser, mValidPasswd);
            Assert.IsTrue(mInboxPage.VerifyPage());
        }

        [When(@"I sign out")]
        public void ThenISignOut()
        {
            mInboxPage.menu.Click();
            mInboxPage.signOut.Click();
        }

        [Then(@"I am navigated to the Gmail login screen")]
        public void ThenIAmNavigatedToTheGmailLoginScreen()
        {
            Assert.IsTrue(mLoginPage.VerifyPage());
        }
	}
}