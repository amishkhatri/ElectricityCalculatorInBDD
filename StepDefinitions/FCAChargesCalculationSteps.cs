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
    public class FCAChargesCalculationsSteps
    {
        // double expectedresult;
        FCAChargesBilled expectedresult;
        double fcacharges;
        int Units;

        string webapi = "https://localhost:44338/api/FCACharges/";

        public FCAChargesBilled callwebapi(string parameters)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = httpClient.GetAsync(parameters).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        //string apiResponse = response.Content.ReadAsStringAsync().Result;
                        //expectedresult = Convert.ToDouble(apiResponse);

                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        expectedresult = JsonConvert.DeserializeObject<FCAChargesBilled>(apiResponse);
                        fcacharges = expectedresult.fcacharges;
                    }
                }
            }
            return expectedresult;
        }

        
        [Given(@"I consume (.*) units in a month")]
        public void GivenIConsumeUnitsInAMonth(int units)
        {   
            webapi = webapi + "Calculation?units=" + units;
        }

        [When(@"the state MOG electricity bill gets generated")]
        public void WhenTheStateMOGElectricityBillGetsGenerated()
        {
         //   webapi = webapi + "FCACalculation?units=" + Units;
            expectedresult = callwebapi(webapi);
        }

        [Then(@"the total charges will be amounted as Rs (.*)")]
        public void ThenTheTotalChargesWillBeAmountedAsRs(Decimal charges)
        {
            Assert.AreEqual(charges, expectedresult.fcacharges);
        }
    }
}