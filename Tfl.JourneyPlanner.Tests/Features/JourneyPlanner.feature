Feature: JourneyPlanner

Scenario: 1. User can be planned a valid journey using the Journey Planner widget with valid locations
	Given the user navigate to tfl journey planner website
	When the user search the journey with the following locations
		| From                     | To              |
		| Newbury Park Underground | North Greenwich |
	Then the valid Journey results should be displayed
