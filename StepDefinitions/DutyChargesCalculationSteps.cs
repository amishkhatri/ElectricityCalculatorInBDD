using BDDElectricityBillKata.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net.Http;
using TechTalk.SpecFlow;

namespace BDDElectricityBillKata.StepDefinitions
{
    [Binding]
    public class DutyChargesCalculationSteps
    {
        DutyChargesBilled expectedresult;
        double totaldutycharges;
        double slabdutycharges;
        double fcadutycharges;
        string webapi = "https://localhost:44338/api/DutyCharges/";

        public DutyChargesBilled callwebapi(string parameters)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = httpClient.GetAsync(parameters).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        expectedresult = JsonConvert.DeserializeObject<DutyChargesBilled>(apiResponse);
                        totaldutycharges = expectedresult.totaldutycharges;
                        slabdutycharges = expectedresult.slabdutycharges;
                        fcadutycharges = expectedresult.fcadutycharges;
                    }
                }
            }
            return expectedresult;
        }

        public DutyChargesCalculationSteps(ScenarioContext scenarioContext)
        {
           
        }

        [Given(@"consumer consumed (.*) units of energy")]
        public void GivenConsumerConsumedUnitsOfEnergy(int units)
        {
            webapi = webapi + "Calculation?units=" + units;
            expectedresult = callwebapi(webapi);
        }


        [When(@"the state ABDY electricity bill generated")]
        public void WhenTheStateABCElectricityBillGenerated()
        {
            expectedresult = callwebapi(webapi);
            totaldutycharges = expectedresult.totaldutycharges;
        }

        [Then(@"the slabwise duty charges amounted to Rs (.*)")]
        public void ThenTheSlabwiseDutyChargesAmountedToRs(Decimal charges)
        {
            Assert.AreEqual(charges, slabdutycharges);
        }

        [Then(@"the total FCA charges amounted to Rs (.*)")]
        public void ThenTheTotalFCAChargesAmountedToRs(Decimal charges)
        {
            Assert.AreEqual(charges, fcadutycharges);
        }

        [Then(@"the Total Duty Charges amounted to Rs (.*)")]
        public void ThenTheTotalDutyChargesAmountedToRs(Decimal charges)
        {
            Assert.AreEqual(charges, totaldutycharges);
        }
    }
}
