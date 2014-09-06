Feature: KeywordDrivenFeature

Scenario: Enter Welcome Text
	Given I am on the "Welcome" page
	And I enter "Hello" in "Welcome"
	When I click "Submit"
	Then I should be on the "Success" page
	And "Header" text should be "Success"

	#Keywords - these are the scenario steps (Given, When, Then), minus the quoted step regex
	#Data
		#Target - this is the object that the keyword step works against (page, control...)
		#Input - this is the data that is feed into the scenario to set up state and drive specific results
		#Assert - this is the data that is used to assert against