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
        private IWebElement JourneyResultHeader => Driver.FindElement(By.XPath("//*[contains(@class, 'jp-results-headline')]"));
        private IWebElement EarlierJourneys => Driver.FindElement(By.XPath("//a[text()='Earlier journeys']"));
        private IWebElement LaterJourneys => Driver.FindElement(By.XPath("//a[text()='Later journeys']"));
        public IWebElement ErrorMessageElement => Driver.FindElement(By.XPath("//li[@class='field-validation-error']"));
        public IWebElement ResultsSummaryElement => Driver.FindElement(By.ClassName("journey-result-summary"));
        private IWebElement EditJourneyLink => Driver.FindElement(By.XPath("//*[contains(@class, 'edit-journey')]"));
        private IWebElement SwitchJourneyElement => Driver.FindElement(By.XPath("//*[contains(@class, 'switch-button hide-text')]"));
        private IWebElement UpdateJourneyButton => Driver.FindElement(By.XPath("//*[@id='plan-journey-button']"));

        public void VerifytheJourneyResult()
        {
            Wait.Until(_ => JourneyResultHeader.Displayed);
            Assert.AreEqual("Journey results", JourneyResultHeader.Text);
            WaitForPageResultsDisplayed();
            EarlierJourneys.Displayed.Should().BeTrue();
            LaterJourneys.Displayed.Should().BeTrue();
        }

        public void WaitForPageResultsDisplayed()
        {
            Wait.Until(_ => EarlierJourneys.Displayed);
            Wait.Until(_ => LaterJourneys.Displayed);
        }

        public void VerifyArrivingTextOnResults()
        {
            Wait.Until(_ => ResultsSummaryElement.Displayed);
            ResultsSummaryElement.Text.Contains("Arriving:");
        }

        public void ClickEditJourney()
        {
            EditJourneyLink.Click();
        }

        public void ClickSwitchJourney()
        {
            Wait.Until(_ => SwitchJourneyElement.Displayed);
            SwitchJourneyElement.Click();
        }

        public void ClickUpdateJourneyButton()
        {
            UpdateJourneyButton.Click();
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
    }
}
