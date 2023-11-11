using OpenQA.Selenium;
using Tfl.JourneyPlanner.Tests.Context;
using Tfl.JourneyPlanner.Tests.Tables;

namespace Tfl.JourneyPlanner.Tests.PageObjects
{
    public class JourneyPlannerPage : BasePage
    {
        public JourneyPlannerPage(WebDriverContext context) : base(context)
        {
        }

        private IWebElement AcceptAllCookies => Driver.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll"));
        private IWebElement FromLocation => Driver.FindElement(By.Id("InputFrom"));
        private IWebElement FromLocationSuggestion => Driver.FindElement(By.XPath("//*[input[@id='InputFrom']]/*[contains(@class, 'tt-dropdown-menu')]"));
        private IWebElement ToLocation => Driver.FindElement(By.Id("InputTo"));
        private IWebElement ToLocationSuggestion => Driver.FindElement(By.XPath("//*[input[@id='InputTo']]/*[contains(@class, 'tt-dropdown-menu')]"));
        private IWebElement PlanJourneyButton => Driver.FindElement(By.Id("plan-journey-button"));
        private IWebElement ChangeTimeLink => Driver.FindElement(By.XPath("//*[contains(@class, 'change-departure-time')]"));
        private IWebElement ArriveOption => Driver.FindElement(By.Id("arriving"));

        public void NavigateToJourneyPlanner()
        {
            Driver.Url = "https://tfl.gov.uk";
            WaitForPageLoad();
        }

        public void InputAndSearch(JourneyLocationsTable location, bool clickPlanJourneyButton)
        {
            FromLocation.SendKeys(location.From);
            Wait.Until(_ => FromLocationSuggestion.Displayed);
            FromLocation.SendKeys(Keys.ArrowDown);
            FromLocation.SendKeys(Keys.Enter);

            ToLocation.SendKeys(location.To);
            Wait.Until(_ => ToLocationSuggestion.Displayed);
            ToLocation.SendKeys(Keys.ArrowDown);
            ToLocation.SendKeys(Keys.Enter);

            if (clickPlanJourneyButton)
            {
                ClickPlanJourneyButton();
            }
        }

        public void AcceptCookies()
        {
            AcceptAllCookies.Click();
        }

        public void ClickPlanJourneyButton()
        {
            Wait.Until(_ => PlanJourneyButton.Displayed);
            PlanJourneyButton.Click();
        }

        public void SearchWithNoAutoSelectOptions(JourneyLocationsTable location)
        {
            FromLocation.SendKeys(location.From);
            FromLocation.SendKeys(Keys.Tab);
            ToLocation.SendKeys(location.To);
            ToLocation.SendKeys(Keys.Tab);

            ClickPlanJourneyButton();
        }

        public void ClickChangeTimeLink()
        {
            Wait.Until(_ => ChangeTimeLink.Displayed);
            ChangeTimeLink.Click();
        }

        public void ClickArriveOption()
        {
            ArriveOption.Click();
        }
    }
}
