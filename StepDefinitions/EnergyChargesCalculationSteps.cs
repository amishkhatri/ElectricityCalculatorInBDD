using BDDElectricityBillKata.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace BDDElectricityBillKata.StepDefinitions
{
    [Binding]

    public class EnergyChargesCalculationSteps
    {
        EnergyChargesBilled expectedresult;
        double totalenergycharges;
        double SlabCharges;


        string webapi = "https://localhost:44338/api/EnergyCharges/";
       
        public EnergyChargesBilled callwebapi(string parameters)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = httpClient.GetAsync(parameters).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        expectedresult = JsonConvert.DeserializeObject<EnergyChargesBilled>(apiResponse);
                        totalenergycharges = expectedresult.TotalEnergyCharges;
                    }

                }
            }
            return expectedresult;
        }

        [Given(@"I consumed (.*) units in a month")]
        public void GivenIConsumedUnitsInAMonth(int units)
        {
            webapi = webapi + "Calculation?units=" + units;
            expectedresult = callwebapi(webapi);
            totalenergycharges = expectedresult.TotalEnergyCharges;
        }

        [When(@"the state ABDY electricity bill gets generated")]
        public void WhenTheStateABDYElectricityBillGetsGenerated()
        {
            expectedresult = callwebapi(webapi);
            totalenergycharges = expectedresult.TotalEnergyCharges;
        }

        [Then(@"the total energy charges as amounted to Rs(.*)")]
        public void ThenTheTotalEnergyChargesAsAmountedToRs(Decimal charges)
        {
            Assert.AreEqual(charges, totalenergycharges);
        }

        

        [Then(@"I should be charged with an amount of Rs(.*) for Slab (.*)")]
        public void ThenIShouldBeChargedWithAnAmountOfRsForSlab(Decimal charges, int slab)
        {

            bool returnvalue = false;

            switch (slab)
            {
                case 1:
                    returnvalue = charges.Equals(expectedresult.Slab1Charges);
                    SlabCharges = expectedresult.Slab1Charges;
                    break;
                case 2:
                    returnvalue = charges.Equals(expectedresult.Slab2Charges);
                    SlabCharges = expectedresult.Slab2Charges;
                    break;
                case 3:
                    returnvalue = charges.Equals(expectedresult.Slab3Charges);
                    SlabCharges = expectedresult.Slab3Charges;
                    break;
                case 4:
                    returnvalue = charges.Equals(expectedresult.Slab4Charges);
                    SlabCharges = expectedresult.Slab4Charges;
                    break;
            }
            Assert.AreEqual(SlabCharges,charges);

        }
    }
}
