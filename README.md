#### TFL Automation Technical Test

The goal of this project is to build a test automation framework with some tests based on the TfL website – Journey Planner widget which is at www.tfl.gov.uk.

#### Note
- Pre requisite : Chrome Browser version 119

#### Visual Studio

Visual Studio needs a little extra configuration. Install the following extensions;
- SpecFlow for Visual Studio 2022

#### Setup - Windows

- Download and install Visual Studio 2022
- The required .net frameworks(6.0)

#### Nuget Packegs Used
- Selenium WebDriver 4.15.0
- Selenium Support 4.15.0
- Selenium WebDriver ChromeDriver 119.0.6045.10500
- SpecFlow NUnit 3.9.40
- FluentAssertions 6.2.0

#### Frame Work Details
- Feature file is added in the Features folder
- Page object classes are stored in the PageObjects folder
- Steps bindings are in the StepDefinitions folder
- Page Context and Driver Context in the Context Folder
- Driver setup and quit is configured in the Hooks file


#### Running Tests
- Once the solution is build successfully then test explorer will show the tests as follows
![image](https://github.com/speterrajan/Tfl.JourneyPlanner.Tests/assets/63073438/b5172439-6cf5-493e-9fde-f9571bfd314e)

#### Test Execution
- All tests are passing successfully 
![image](https://github.com/speterrajan/Tfl.JourneyPlanner.Tests/assets/63073438/c00fc02b-31ed-4408-af10-d5a8900f616d)

    
