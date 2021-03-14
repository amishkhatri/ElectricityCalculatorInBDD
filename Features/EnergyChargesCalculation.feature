Feature: Energy Charges Calculation
As a user want that this feature should calculate the Energy Charges based on the units billed to the Domestic Electricity Consumer for the state ABC
with A (Slabs) and B (Rate)	
Energy Charges C (Charges) = A (Unit Bifurcation) x B (Rate)

Scenario Outline:Calculate the Energy Charges for the Domestic Electricity Consumer in Slab 1 for consumption between 1 to 50 units
	Given I consumed <units> units in a month
	When the state ABDY electricity bill gets generated
	Then the total energy charges as amounted to Rs<slab1total>

	Examples:
		| units | slab1total |
		| 1     | 4.05       |
		| 40    | 162.00     |
		| 50    | 202.50     |


Scenario Outline:Calculate the Energy Charges for the Domestic Electricity Consumer in Slab 2 for consumption between 51 to 150 units
	Given I consumed <units> units in a month
	When the state ABDY electricity bill gets generated
	Then I should be charged with an amount of Rs<slab1total> for Slab 1
	And I should be charged with an amount of Rs<slab2total> for Slab 2
	And the total energy charges as amounted to Rs<energytotal>

	Examples:
		| units | slab1total | slab2total | energytotal |
		| 51    | 202.50     | 4.95       | 207.45      |
		| 100   | 202.50     | 247.50     | 450.00      |
		| 150   | 202.50     | 495.00     | 697.50      |

Scenario Outline:Calculate the Energy Charges for the Domestic Electricity Consumer in Slab 3 for consumption between 151 to 300 units
	Given I consumed <units> units in a month
	When the state ABDY electricity bill gets generated
	Then I should be charged with an amount of Rs<slab1total> for Slab 1
	And I should be charged with an amount of Rs<slab2total> for Slab 2
	And I should be charged with an amount of Rs<slab3total> for Slab 3
	And the total energy charges as amounted to Rs<energytotal>

	Examples:
		| units | slab1total | slab2total | slab3total | energytotal |
		| 151   | 202.50     | 495.00     | 6.30       | 703.80      |
		| 200   | 202.50     | 495.00     | 315.00     | 1012.50     |
		| 300   | 202.50     | 495.00     | 945.00     | 1642.50     |

Scenario Outline:Calculate the Energy Charges for the Domestic Electricity Consumer in Slab 4 for consumption above 300 units
	Given I consumed <units> units in a month
	When the state ABDY electricity bill gets generated
	Then I should be charged with an amount of Rs<slab1total> for Slab 1
	And I should be charged with an amount of Rs<slab2total> for Slab 2
	And I should be charged with an amount of Rs<slab3total> for Slab 3
	And I should be charged with an amount of Rs<slab4total> for Slab 4
	And the total energy charges as amounted to Rs<energytotal>

	Examples:
		| units | slab1total | slab2total | slab3total | slab4total | energytotal |
		| 301   | 202.50     | 495.00     | 945.00     | 6.50       | 1649.00     |
		| 400   | 202.50     | 495.00     | 945.00     | 650.00     | 2292.50     |
		| 1000  | 202.50     | 495.00     | 945.00     | 4550.00    | 6192.50     |