using BDDElectricityBillKata.Models;
using System;
using TechTalk.SpecFlow;

namespace BDDElectricityBillKata.StepDefinitions
{
    [Binding]
    public class DutyChargesCalculationForBillSteps
    {
        EnergyCharges dutyCharges = new EnergyCharges();
        double result;

        [Given(@"the consumer consumed (.*) unit of energy")]
        public void GivenTheConsumerConsumedUnitOfEnergy(int p0)
        {
            dutyCharges.Units = p0;            
        }
        
        [When(@"the state ABC electricity bill generate")]
        public void WhenTheStateABCElectricityBillGenerate()
        {
            result = dutyCharges.DutyChargesCalculation();
            
        }
        
        [Then(@"the slabwise duty charges will be amounted as Rs (.*)")]
        public void ThenTheSlabwiseDutyChargesWillBeAmountedAsRs(Decimal p0)
        {
            double returnvalue;
            returnvalue = dutyCharges.Slab1DutyCharges + dutyCharges.Slab2DutyCharges + dutyCharges.Slab3DutyCharges + dutyCharges.Slab4DutyCharges;
            returnvalue.Equals(p0);
        }
        
        [Then(@"the total FCA charges will be amounted as Rs (.*)")]
        public void ThenTheTotalFCAChargesWillBeAmountedAsRs(Decimal p0)
        {
            double returnvalue;
            returnvalue = dutyCharges.FCACharges * ( dutyCharges.Slab1DutyCharges + dutyCharges.Slab2DutyCharges + dutyCharges.Slab3DutyCharges + dutyCharges.Slab4DutyCharges);
            returnvalue.Equals(p0);            
        }
        
        [Then(@"the Total Duty charges will be amounted as Rs (.*)")]
        public void ThenTheTotalDutyChargesWillBeAmountedAsRs(Decimal p0)
        {
            result.Equals(p0);
        }
    }
}
