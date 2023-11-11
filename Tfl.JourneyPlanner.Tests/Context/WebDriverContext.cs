using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Tfl.JourneyPlanner.Tests.Context
{
    public class WebDriverContext
    {
        public IWebDriver Driver { get; set; }
        public WebDriverWait Wait { get; set; }
    }
}
