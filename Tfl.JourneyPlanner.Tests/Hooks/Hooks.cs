using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Tfl.JourneyPlanner.Tests.Context;

namespace Tfl.JourneyPlanner.Tests.Hooks
{
    [Binding]
    public class Hooks
    {
        public WebDriverContext DriverContext { get; }

        public Hooks(WebDriverContext context)
        {
            DriverContext = context;
        }

        [BeforeScenario()]
        public void BeforeScenarioWithTag()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            IWebDriver driver = new ChromeDriver(options);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.IgnoreExceptionTypes(typeof(NoSuchFrameException));
            wait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            DriverContext.Wait = wait;
            DriverContext.Driver = driver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            DriverContext.Driver.Quit();
        }
    }
}
