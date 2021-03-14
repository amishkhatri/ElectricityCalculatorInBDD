Feature: Duty Charges Calculation
	As a user I should be able to calculate the Duty Charges on the units billed to the ABC State Electricity Consumer based on the below calculation.
	U (Units for duty)
	F (Duty Charge)
	Slab Wise Duty (G) : G = U * F
    FCA on Duty (H) : H = G * 0.13
    Total Duty Charges (I) : I = G + H Sum of I is considered for final calculation

Scenario Outline: Calculate the Duty Charges for the Domestic Electricity Consumer in all 4 Slabs for consumption
	Given the consumer consumes <units> units of energy
	When the state ABC electricity bill gets generate
	Then the slabwise duty charges amounted to Rs <slabwisedutytotal>
	And the total FCA charges amounted to Rs <fcadutytotal>
	And the Total Duty Charges amounted to Rs <totalduty>



	Examples:
		| units | slabwisedutytotal | fcadutytotal | totalduty |
		| 40    | 3.60              | 0.468        | 4.068     |
		| 95    | 11.40             | 1.482        | 12.882    |
		| 250   | 30.00             | 3.9          | 33.900    |
		| 700   | 84.00             | 10.92        | 94.92     |