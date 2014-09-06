Feature: KeywordDrivenFeature

Scenario: Enter Welcome Text
	Given I am on the "Welcome" page
	And I enter "Hello" in "Welcome"
	When I click "Submit"
	Then I should be on the "Success" page
	And "Header" text should be "Success"

	#Keywords - these are the scenario steps (Given, When, Then), minus the data in the quoted step regex
	#Data
		#Target - this is the object that the keyword step works against (page, control, element...)
		#Input - this is the data that is feed into the scenario to set up state and drive specific results
		#Assert - this is the data that is used to assert against

	#Given I am on {Target} page - Allows tester to open the target page
	#Given I enter {Input} in {Target} - Allows the tester to type the input in the target element
	#When I click {Target} - Allows the tester to click the target element
	#Then I should be on the {Assert} page - Allows the tester to verify that the asserted page is open
	#Then {Target} text should be {Assert} - Allows the tester to verify that the target element contains the asserted text