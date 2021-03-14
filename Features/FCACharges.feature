Feature: FCA Charges Calculation
	As a user I should be be able to calculate the FCA charges which means the Fuel Cost Adjustment.
	E = A (units) * 0.13 i.e. 13 paise per unit

Scenario Outline:Calculate the FCA Charges for the Domestic Electricity Consumer on the units billed
	Given I consumed <units> units in a month
	When the state ABC electricity bill gets generated
	Then the total energy charges as amounted to Rs <fcatotal>


	Examples:
		| units | fcatotal |
		| 40    | 5.2      |
		| 100   | 13       |
		| 350   | 45.5     |