Feature: FCA Charges Calculation
	As a user I should be be able to calculate the FCA charges which means the Fuel Cost Adjustment.
	E = A (units) * 0.13 i.e. 13 paise per unit

@mytag
Scenario Outline:Calculate the FCA Charges for the Domestic Electricity Consumer on the units billed
	Given I consume <units> units in a month
	When the state MOG electricity bill gets generated
	Then the total charges will be amounted as Rs <fcatotal>

	Examples:
		| units | fcatotal |
		| 40    | 5.20     |
		| 100   | 13.00    |
		| 350   | 45.50    |