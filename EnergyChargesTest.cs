using NUnit.Framework;
using TechTalk.SpecFlow;
using System;

namespace BDDElectricityBillKata
{
    public class EnergyChargesTest
    {
        [SetUp]
        public void Setup()
        {
        }


        #region "Energy Charges"

        

        [Test]
        public void ShouldReturnEnergyChargesWhenUnitsConsumedIsZero()
        {
            EnergyCharges energycharges = new EnergyCharges();
            energycharges.Units = 0;
            double result = energycharges.EnergyChargesCalculation();
            double expected = 0;
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ShouldReturnEnergyChargesWhenUnitsConsumedIsOneForSlab1()
        {
            EnergyCharges energycharges = new EnergyCharges();
            energycharges.Units = 1;
            double result = energycharges.EnergyChargesCalculation();
            double expected = 4.05;
            Assert.AreEqual(expected, result);
        }



        [Test]
        public void ShouldReturnEnergyChargesWhenUnitsConsumedForSlab1()
        {
            EnergyCharges energycharges = new EnergyCharges();
            energycharges.Units = 45;
            double result = energycharges.EnergyChargesCalculation();
            double expected = 182.25;
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ShouldReturnEnergyChargesWhenUnitsConsumedForSlab2()
        {
            EnergyCharges energycharges = new EnergyCharges();
            energycharges.Units = 51;
            double result = energycharges.EnergyChargesCalculation();
            double expected = 207.45;
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ShouldReturnEnergyChargesWhenUnitsConsumedForSlab3()
        {
            EnergyCharges energycharges = new EnergyCharges();
            energycharges.Units = 151;
            double result = energycharges.EnergyChargesCalculation();
            double expected = 703.80;
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ShouldReturnEnergyChargesWhenUnitsConsumedForSlab4()
        {
            EnergyCharges energycharges = new EnergyCharges();
            energycharges.Units = 301;
            double result = energycharges.EnergyChargesCalculation();
            double expected = 1649.00;
            Assert.AreEqual(expected, result);
        }

        #endregion

        #region "FCA Charges"


        [Test]
        public void ShouldReturnFCAChargesWhenUnitsConsumedForSlab1()
        {
            EnergyCharges FCACharges = new EnergyCharges();
            FCACharges.Units = 1;
            double result = FCACharges.FCACharges * FCACharges.Units;
            double expected = 0.13 ;
            Assert.AreEqual(expected, result);
        }


        [Test]
        public void ShouldReturnFCAChargesWhenUnitsConsumedForSlab2()
        {
            EnergyCharges FCACharges = new EnergyCharges();
            FCACharges.Units = 51;
            double result = FCACharges.FCACharges * FCACharges.Units;
            double expected = 6.63;
            Assert.AreEqual(expected, result);
        }



        [Test]
        public void ShouldReturnFCAChargesWhenUnitsConsumedForSlab3()
        {
            EnergyCharges FCACharges = new EnergyCharges();
            FCACharges.Units = 151;
            double result = FCACharges.FCACharges * FCACharges.Units;
            double expected = 19.63;
            Assert.AreEqual(expected, result);
        }


        [Test]
        public void ShouldReturnFCAChargesWhenUnitsConsumedForSlab4()
        {
            EnergyCharges FCACharges = new EnergyCharges();
            FCACharges.Units = 301;
            double result = FCACharges.FCACharges * FCACharges.Units;
            double expected = 39.13;
            Assert.AreEqual(expected, result);
        }



        #endregion

        #region "Duty Charges"

        [Test]
        public void ShouldReturnDutyChargesWhenUnitsConsumedIsZero()
        {
            EnergyCharges dutycharges = new EnergyCharges();
            dutycharges.Units = 0;
            double result = dutycharges.DutyChargesCalculation();
            double expected = 0;
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ShouldReturnDutyChargesWhenUnitsConsumedIsOneForSlab1()
        {
            EnergyCharges dutycharges = new EnergyCharges();
            dutycharges.Units = 1;
            double result = dutycharges.DutyChargesCalculation();
            double expected = 0.1017;
            Assert.AreEqual(expected, result);
        }


        [Test]
        public void ShouldReturnDutyChargesWhenUnitsConsumedForSlab1()
        {
            EnergyCharges dutycharges = new EnergyCharges();
            dutycharges.Units = 40;
            double result = dutycharges.DutyChargesCalculation();
            double expected = 4.068;
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ShouldReturnDutyChargesWhenUnitsConsumedForSlab2()
        {
            EnergyCharges dutycharges = new EnergyCharges();
            dutycharges.Units = 100;
            double result = dutycharges.DutyChargesCalculation();
            double expected = 11.865;
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ShouldReturnDutyChargesWhenUnitsConsumedForSlab3()
        {
            EnergyCharges dutycharges = new EnergyCharges();
            dutycharges.Units = 180;
            double result = dutycharges.DutyChargesCalculation();
            double expected = 22.713;
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ShouldReturnDutyChargesWhenUnitsConsumedForSlab4()
        {
            EnergyCharges dutycharges = new EnergyCharges();
            dutycharges.Units = 302;
            double result = dutycharges.DutyChargesCalculation();
            double expected = 39.2562;
            Assert.AreEqual(expected, result);
        }


        #endregion



    }
}