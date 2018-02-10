using Automation.Core.SeleniumUtility;
using WebUI.Automation.Pages;
using OpenQA.Selenium.Support.UI;

namespace WebUI.Automation.Tests.Steps
{
	public abstract class StandardStepsBase
	{
        protected StandardStepsBase(IExtendedWebDriver webDriver, Options options, WebDriverWait wait)
		{
			WebDriver = webDriver;
			Options = options;
            Wait = wait;
		}

		protected IExtendedWebDriver WebDriver { get; }

		protected Options Options { get; }

        protected WebDriverWait Wait { get; }
	}
}