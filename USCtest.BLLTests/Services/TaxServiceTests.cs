using Microsoft.VisualStudio.TestTools.UnitTesting;
using USCtest.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USCtest.BLL.BusinesModels;
using USCtest.BLL.Models;

namespace USCtest.BLL.Services.Tests
{
    [TestClass()]
    public class TaxServiceTests
    {
        [TestMethod()]
        public void CalculateTest()
        {
            var indications = new FlatIndications()
            {
                ColdWather = 100,
                HotWaterHeat = 100,
                Electricity = 0,
                ElectricityDay = 100,
                ElectricityNight = 100
            };

            var flat = new FlatModel()
            {
                Street = "Pushkina",
                StreetNumber = 10,
                FlatNumber = 5,
                IsColdWatherDevice = true,
                IsElectricPowerDevice = true,
                IsHotWatherDevice = true,
                Users = new List<UserModel>(),
                Taxes = new List<TaxModel>(),
                Indications = indications,
            };

            var userFlats = new List<FlatModel>() { flat };

            var user = new UserModel()
            {
                FirstName = "Test",
                LastName = "Testovich",
                PassportSeries = "1010",
                PassportNumber = "101010",
                Flats = userFlats,
            };

            var taxService = new TaxService(null, null);

            taxService.CalculateForTest(flat);

            Assert.AreEqual(flat.Taxes.First().ColdWaterVolume, 100);
            Assert.AreEqual(flat.Taxes.First().ColdWatherCost, 3578);

            Assert.AreEqual(flat.Taxes.First().HotWatherHeatVolume, 100);
            Assert.AreEqual(flat.Taxes.First().HotWatherHeatCost, 3578);

            Assert.AreEqual(flat.Taxes.First().HotWatherThermalEnergyVolume, 5.349);
            Assert.AreEqual(flat.Taxes.First().HotWatherThermalEnergyCost, 5341.99281m);

            Assert.AreEqual(flat.Taxes.First().ElectricityDayVolume, 100);
            Assert.AreEqual(flat.Taxes.First().ElectricityDayCost, 490);

            Assert.AreEqual(flat.Taxes.First().ElectricityNightVolume, 100);
            Assert.AreEqual(flat.Taxes.First().ElectricityNightCost, 231);
        }
    }
}