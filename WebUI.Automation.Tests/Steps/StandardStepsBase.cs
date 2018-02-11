using Automation.Core.SeleniumUtility;
using WebUI.Automation.Pages;

namespace WebUI.Automation.Tests.Steps
{
    public abstract class StandardStepsBase
    {
        protected StandardStepsBase(IExtendedWebDriver webDriver, Options options)
        {
			WebDriver = webDriver;
			Options = options;
		}

		protected IExtendedWebDriver WebDriver { get; }

		protected Options Options { get; }
    }
}
