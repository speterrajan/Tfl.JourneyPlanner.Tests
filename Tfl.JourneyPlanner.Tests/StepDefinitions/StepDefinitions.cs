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

        [When(@"the user search the journey with the following locations")]
        public void WhenTheUserSearchTheJourneyWithTheFollowingLocations(Table table)
        {
            table.Rows.Count().Should().Be(1, "Expected to have only one row");
            var location = table.CreateInstance<JourneyLocationsTable>();
            PageContext.JourneyPlanner.Search(location);
            PageContext.JourneyResults = new JourneyResultsPage(DriverContext);
        }

        [Then(@"the valid Journey results should be displayed")]
        public void ThenTheValidJourneyResultsShouldBeDisplayed()
        {
            PageContext.JourneyPlanner.WaitForPageLoad();
            PageContext.JourneyResults.VerifytheJourneyResult();
        }
    }
}
