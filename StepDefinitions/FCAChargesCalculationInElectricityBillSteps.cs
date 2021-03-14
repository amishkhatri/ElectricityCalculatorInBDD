using BDDElectricityBillKata.Models;
using System;
using TechTalk.SpecFlow;

namespace BDDElectricityBillKata.StepDefinitions
{
    [Binding]
    public class FCAChargesCalculationInElectricityBillSteps
    {
        EnergyCharges ec = new EnergyCharges();
        double result;

        [Given(@"I consumed (.*) in a month")]
        public void GivenIConsumedInAMonth(int p0)
        {
            ec.Units = p0;
           // ScenarioContext.Current.Pending();
        }
        
        [When(@"the state ABC electricity bill gets generate")]
        public void WhenTheStateABCElectricityBillGetsGenerate()
        {
            result = ec.FCACharges * ec.Units;
            // ScenarioContext.Current.Pending();
        }

        [Then(@"the total energy charges will be Rs (.*)")]
        public void ThenTheTotalEnergyChargesWillBeRs(Decimal p0)
        {
            result.Equals(p0);
            // ScenarioContext.Current.Pending();
        }
    }
}
