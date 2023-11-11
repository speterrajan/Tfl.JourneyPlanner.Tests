using NUnit.Framework;
using OpenQA.Selenium;
using Tfl.JourneyPlanner.Tests.Context;

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

        public void VerifytheJourneyResult()
        {
            Wait.Until(_ => JourneyResultHeader.Displayed);
            Assert.AreEqual("Journey results", JourneyResultHeader.Text);

            Wait.Until(_ => EarlierJourneys.Displayed);
            Wait.Until(_ => LaterJourneys.Displayed);

            EarlierJourneys.Displayed.Should().BeTrue();
            LaterJourneys.Displayed.Should().BeTrue();
        }
    }
}
