Feature: Duty Charges Calculation
As a user I should be able to calculate the Duty Charges on the units billed to the ABC State Electricity Consumer based on the below calculation.
	U (Units for duty)
	F (Duty Charge)
	Slab Wise Duty (G) : G = U * F
    FCA on Duty (H) : H = G * 0.13
    Total Duty Charges (I) : I = G + H Sum of I is considered for final calculation

@mytag
Scenario Outline: Calculate the Duty Charges for the Domestic Electricity Consumer in all 4 Slabs for consumption1
	Given consumer consumed <units> units of energy
	When the state ABDY electricity bill generated
	Then the slabwise duty charges amounted to Rs <slabdutycharges>
	And the total FCA charges amounted to Rs <fcadutycharges>
	And the Total Duty Charges amounted to Rs <totaldutycharges>

	Examples:
		| units | slabdutycharges | fcadutycharges | totaldutycharges |
		| 40    | 3.60            | 0.468          | 4.068            |
		| 95    | 9.90            | 1.287          | 11.187           |
		| 250   | 28.50           | 3.705          | 32.205           |
		| 700   | 82.50           | 10.725         | 93.225           |