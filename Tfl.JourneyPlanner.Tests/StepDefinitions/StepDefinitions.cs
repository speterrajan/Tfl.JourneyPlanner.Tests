using TechTalk.SpecFlow.Assist;
using Tfl.JourneyPlanner.Tests.Context;
using Tfl.JourneyPlanner.Tests.PageObjects;
using Tfl.JourneyPlanner.Tests.Tables;

namespace Tfl.JourneyPlanner.Tests.StepDefinitions
{
    [Binding]
    public class StepDefinitions
    {
        public PageContext PageContext { get; }
        public WebDriverContext DriverContext { get; }

        public StepDefinitions(PageContext context, WebDriverContext driverContext)
        {
            PageContext = context;
            DriverContext = driverContext;
        }

        [Given(@"the user navigate to tfl journey planner website")]
        public void GivenTheUserNavigateToTflJourneyPlannerWebsite()
        {
            PageContext.JourneyPlanner = new JourneyPlannerPage(DriverContext);
            PageContext.JourneyPlanner.NavigateToJourneyPlanner();
            PageContext.JourneyPlanner.AcceptCookies();
        }

        [When(@"the user (search|input) the journey with the following locations")]
        public void WhenTheUserSearchTheJourneyWithTheFollowingLocations(string typeOfOperation, Table table)
        {
            var location = table.CreateInstance<JourneyLocationsTable>();
            PageContext.JourneyPlanner.InputAndSearch(location, typeOfOperation == "search");
            PageContext.JourneyResults = new JourneyResultsPage(DriverContext);
        }

        [When(@"the user search the journey with the following invalid locations")]
        public void WhenTheUserSearchTheJourneyWithTheFollowingInvalidLocations(Table table)
        {
            var inputLocations = table.CreateInstance<JourneyLocationsTable>();
            PageContext.JourneyPlanner.SearchWithNoAutoSelectOptions(inputLocations);
            PageContext.JourneyResults = new JourneyResultsPage(DriverContext);
        }

        [When(@"the user click on the change time link")]
        public void WhenTheUserClickOnTheChangeTimeLink()
        {
            PageContext.JourneyPlanner.WaitForPageLoad();
            PageContext.JourneyPlanner.ClickChangeTimeLink();
        }

        [When(@"the user click on the Arriving option and press the plan my journey button")]
        public void WhenTheUserClickOnTheArrivingOptionAndPressThePlanMyJourneyButton()
        {
            PageContext.JourneyPlanner.ClickArriveOption();
            PageContext.JourneyPlanner.ClickPlanJourneyButton();
        }

        [When(@"the user click on the edit journey link")]
        public void WhenTheUserClickOnTheEditJourneyLink()
        {
            PageContext.JourneyResults.ClickEditJourney();
        }

        [When(@"the user switch to and from locations and press the update journey button")]
        public void WhenTheUserSwitchToAndFromLocationsAndPressTheUpdateJourneyButton()
        {
            PageContext.JourneyResults.ClickSwitchJourney();
            PageContext.JourneyResults.ClickUpdateJourneyButton();
        }

        [Then(@"the valid Journey results should be displayed")]
        public void ThenTheValidJourneyResultsShouldBeDisplayed()
        {
            PageContext.JourneyResults.WaitForPageLoad();
            PageContext.JourneyResults.VerifytheJourneyResult();
        }

        [Then(@"Error message '(.*)' should be displayed")]
        public void ThenErrorMessageTFindAJourneyMatchingYourCriteriaShouldBeDisplayed(string errorMessage)
        {
            PageContext.JourneyResults.WaitForPageResultsDisplayed();
            PageContext.JourneyResults.ErrorMessageElement.Text.Should().Be(errorMessage);
        }

        [Then(@"the Journey results are displayed based on the arrival time")]
        public void ThenTheJourneyResultsAreDisplayedBasedOnTheArrivalTime()
        {
            PageContext.JourneyResults.VerifyArrivingTextOnResults();
        }

        [Then(@"the Journey results are displayed as per the following locations")]
        public void ThenTheJourneyResultsAreDisplayedAsPerTheFollowingLocations(Table table)
        {
            var inputLocations = table.CreateInstance<JourneyLocationsTable>();
            PageContext.JourneyResults.GetResultsSumaryFromLocation().Should().BeEquivalentTo(inputLocations);
        }
    }
}