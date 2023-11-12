using NUnit.Framework;
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

        private IWebElement AcceptAllCookiesElement => Driver.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll"));
        private IWebElement FromLocationElement => Driver.FindElement(By.Id("InputFrom"));
        private IWebElement FromLocationSuggestionElement => Driver.FindElement(By.XPath("//*[input[@id='InputFrom']]/*[contains(@class, 'tt-dropdown-menu')]"));
        private IWebElement ToLocationElement => Driver.FindElement(By.Id("InputTo"));
        private IWebElement ToLocationSuggestionElement => Driver.FindElement(By.XPath("//*[input[@id='InputTo']]/*[contains(@class, 'tt-dropdown-menu')]"));
        private IWebElement PlanJourneyButtonElement => Driver.FindElement(By.Id("plan-journey-button"));
        private IWebElement ChangeTimeLinkElement => Driver.FindElement(By.XPath("//*[contains(@class, 'change-departure-time')]"));
        private IWebElement ArriveOptionElement => Driver.FindElement(By.Id("arriving"));
        private IWebElement FromLocationErrorElement => Driver.FindElement(By.Id("InputFrom-error"));
        private IWebElement ToLocationErrorElement => Driver.FindElement(By.Id("InputTo-error"));
        private IWebElement RecentTabElement => Driver.FindElement(By.XPath("//*[@id='jp-recent-tab-jp']"));
        private IWebElement RecentTopElement => Driver.FindElement(By.Id("jp-recent-content-jp-"));
        public void NavigateToJourneyPlanner()
        {
            Driver.Url = "https://tfl.gov.uk";
            WaitForPageLoad();
        }

        public void InputAndSearch(JourneyLocationsTable location, bool clickPlanJourneyButton)
        {
            if (!string.IsNullOrEmpty(location.From))
            {
                FromLocationElement.SendKeys(location.From);
                Wait.Until(_ => FromLocationSuggestionElement.Displayed);
                FromLocationElement.SendKeys(Keys.ArrowDown);
                FromLocationElement.SendKeys(Keys.Enter);
            }

            if (!string.IsNullOrEmpty(location.To))
            {
                ToLocationElement.SendKeys(location.To);
                Wait.Until(_ => ToLocationSuggestionElement.Displayed);
                ToLocationElement.SendKeys(Keys.ArrowDown);
                ToLocationElement.SendKeys(Keys.Enter);
            }

            if (clickPlanJourneyButton)
            {
                ClickPlanJourneyButton();
            }
        }

        public void AcceptCookies()
        {
            AcceptAllCookiesElement.Click();
        }

        public void ClickPlanJourneyButton()
        {
            Wait.Until(_ => PlanJourneyButtonElement.Displayed);
            PlanJourneyButtonElement.Click();
        }

        public void SearchWithNoAutoSelectOptions(JourneyLocationsTable location)
        {
            FromLocationElement.SendKeys(location.From);
            FromLocationElement.SendKeys(Keys.Tab);
            ToLocationElement.SendKeys(location.To);
            ToLocationElement.SendKeys(Keys.Tab);

            ClickPlanJourneyButton();
        }

        public void ClickChangeTimeLink()
        {
            Wait.Until(_ => ChangeTimeLinkElement.Displayed);
            ChangeTimeLinkElement.Click();
        }

        public void ClickArriveOption()
        {
            ArriveOptionElement.Click();
        }

        public string GetFromLocationError()
        {
            Wait.Until(_ => FromLocationErrorElement.Displayed);
            return FromLocationErrorElement.Text;
        }

        public string GetToLocationError()
        {
            Wait.Until(_ => ToLocationErrorElement.Displayed);
            return ToLocationErrorElement.Text;
        }

        public void ClickTopOneRecentJourneySearch()
        {
            Wait.Until(_ => RecentTabElement.Displayed);
            RecentTabElement.Click();
            Wait.Until(_ => RecentTopElement.Displayed);
            RecentTopElement.Click();
        }
    }
}
