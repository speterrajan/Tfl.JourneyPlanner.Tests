using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using Tfl.JourneyPlanner.Tests.Context;

namespace Tfl.JourneyPlanner.Tests.PageObjects
{
    public abstract class BasePage
    {
        protected IWebDriver Driver;
        protected readonly WebDriverWait Wait;

        protected BasePage(WebDriverContext context)
        {
            Driver = context.Driver;
            Wait = context.Wait;
        }
        
        public bool IsPageReady
        {
            get
            {
                try
                {
                    return Driver.ExecuteJavaScript<string>("return document.readyState").Equals("complete");
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public void WaitForPageLoad()
        {
            Wait.Until(x => IsPageReady);
        }
    }
}
