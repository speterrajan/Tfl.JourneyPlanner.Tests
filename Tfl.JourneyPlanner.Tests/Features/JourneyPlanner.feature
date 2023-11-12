Feature: JourneyPlanner

Scenario: 1. User can be planned a valid journey using the Journey Planner widget with valid locations
	Given the user navigate to tfl journey planner website
	When the user search the journey with the following locations
		| From                     | To              |
		| Newbury Park Underground | North Greenwich |
	Then the valid Journey results should be displayed

Scenario: 2. User planning a journey using the Journey Planner widget with invalid locations
	Given the user navigate to tfl journey planner website
	When the user search the journey with the following invalid locations
		| From | To  |
		| SSS  | 999 |
	Then Error message 'Journey planner could not find any results to your search. Please try again' should be displayed

Scenario: 3. User planning a journey based on the arrival time using the journey planner widget
	Given the user navigate to tfl journey planner website
	When the user input the journey with the following locations
		| From                     | To              |
		| Newbury Park Underground | North Greenwich |
	And the user click on the change time link
	And the user click on the Arriving option and press the plan my journey button
	Then the valid Journey results should be displayed
	And the Journey results are displayed based on the arrival time

Scenario: 4. User unable to plan journey using the Journey Planner widget when no locations entered
	Given the user navigate to tfl journey planner website
	When the user search the journey with the following locations
		| From | To |
		|      |    |
	Then the field 'From' validation message 'The From field is required.' should be displayed
	And the field 'To' validation message 'The To field is required.' should be displayed

Scenario: 5. User able to amend the journey from the journey results page using the edit journey option in the journey planner widget
	Given the user navigate to tfl journey planner website
	When the user search the journey with the following locations
		| From        | To                          |
		| Westminster | Heathrow Airport Terminal 4 |
	Then the valid Journey results should be displayed
	When the user click on the edit journey link
	And the user switch to and from locations and press the update journey button
	Then the valid Journey results should be displayed
	And the Journey results are displayed as per the following locations
		| From                        | To          |
		| Heathrow Airport Terminal 4 | Westminster |

Scenario: 6. User able to see the list of recently planned journeys using the recents tab in the journey planner widget
	Given the user navigate to tfl journey planner website
	When the user search the journey with the following locations
		| From        | To                          |
		| Westminster | Heathrow Airport Terminal 4 |
	Then the valid Journey results should be displayed
	When the user click plan a journey link
	When the user search the journey with the following locations
		| From        | To                          |
		| Westminster | Heathrow Airport Terminal 4 |
	Then the valid Journey results should be displayed
	When the user click plan a journey link
	And the user click on the top recent journey
	Then the Journey results are displayed as per the following locations
		| From        | To                          |
		| Westminster | Heathrow Airport Terminal 4 |
