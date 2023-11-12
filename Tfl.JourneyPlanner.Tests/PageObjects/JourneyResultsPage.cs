using NUnit.Framework;
using OpenQA.Selenium;
using Tfl.JourneyPlanner.Tests.Context;
using Tfl.JourneyPlanner.Tests.Tables;

namespace Tfl.JourneyPlanner.Tests.PageObjects
{
    public class JourneyResultsPage : BasePage
    {
        public JourneyResultsPage(WebDriverContext context) : base(context)
        {
        }
        private IWebElement JourneyResultHeaderElement => Driver.FindElement(By.XPath("//*[contains(@class, 'jp-results-headline')]"));
        private IWebElement EarlierJourneysElement => Driver.FindElement(By.XPath("//a[text()='Earlier journeys']"));
        private IWebElement LaterJourneysElement => Driver.FindElement(By.XPath("//a[text()='Later journeys']"));
        public IWebElement ErrorMessageElement => Driver.FindElement(By.XPath("//li[@class='field-validation-error']"));
        public IWebElement ResultsSummaryElement => Driver.FindElement(By.ClassName("journey-result-summary"));
        private IWebElement EditJourneyLinkElement => Driver.FindElement(By.XPath("//*[contains(@class, 'edit-journey')]"));
        private IWebElement SwitchJourneyElement => Driver.FindElement(By.XPath("//*[contains(@class, 'switch-button hide-text')]"));
        private IWebElement UpdateJourneyButtonElement => Driver.FindElement(By.XPath("//*[@id='plan-journey-button']"));
        private IWebElement PlanAJourneyLinkElement => Driver.FindElement(By.LinkText("Plan a journey"));

        public void VerifytheJourneyResult()
        {
            Wait.Until(_ => JourneyResultHeaderElement.Displayed);
            Assert.AreEqual("Journey results", JourneyResultHeaderElement.Text);
            WaitForPageResultsDisplayed();
            EarlierJourneysElement.Displayed.Should().BeTrue();
            LaterJourneysElement.Displayed.Should().BeTrue();
        }

        public void WaitForPageResultsDisplayed()
        {
            Wait.Until(_ => EarlierJourneysElement.Displayed);
            Wait.Until(_ => LaterJourneysElement.Displayed);
        }

        public void VerifyArrivingTextOnResults()
        {
            Wait.Until(_ => ResultsSummaryElement.Displayed);
            ResultsSummaryElement.Text.Contains("Arriving:");
        }

        public void ClickEditJourney()
        {
            EditJourneyLinkElement.Click();
        }

        public void ClickSwitchJourney()
        {
            Wait.Until(_ => SwitchJourneyElement.Displayed);
            SwitchJourneyElement.Click();
        }

        public void ClickUpdateJourneyButton()
        {
            UpdateJourneyButtonElement.Click();
        }

        public JourneyLocationsTable GetResultsSumaryFromLocation()
        {
            var resultsSummary = Driver.FindElement(By.ClassName("from-to-wrapper"));
            var results = new JourneyLocationsTable
            {
                From = resultsSummary.FindElement(By.XPath(".//span[contains(text(),'From:')]/../span[@class='notranslate']")).Text,
                To = resultsSummary.FindElement(By.XPath(".//span[contains(text(),'To:')]/../span[@class='notranslate']")).Text
            };
            return results;
        }

        public void ClickPlanAJourneyTab()
        {
            Wait.Until(_ => PlanAJourneyLinkElement.Displayed);
            PlanAJourneyLinkElement.Click();
        }
    }
}
