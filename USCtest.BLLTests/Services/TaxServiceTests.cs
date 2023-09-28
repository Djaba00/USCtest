using Microsoft.VisualStudio.TestTools.UnitTesting;
using USCtest.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USCtest.BLL.BusinesModels;
using USCtest.BLL.Models;
using USCtest.BLL.BusinesModels.Helpers;

namespace USCtest.BLL.Services.Tests
{
    [TestClass()]
    public class TaxServiceTests
    {
        [TestMethod()]
        public void CalculateTest()
        {
            // Arange

            var taxService = new TaxService(null, null);

            var flat1 = new FlatModel()
            {
                Street = "Pushkina",
                StreetNumber = 10,
                FlatNumber = 5,
                IsColdWaterDevice = true,
                IsElectricPowerDevice = true,
                IsHotWaterDevice = true,
                Taxes = new List<TaxModel>(),
                Registrations = new List<RegistrationModel>(),
            };

            var flat2 = new FlatModel()
            {
                Street = "Kolotushkina",
                StreetNumber = 12,
                FlatNumber = 6,
                IsColdWaterDevice = false,
                IsElectricPowerDevice = false,
                IsHotWaterDevice = false,
                Taxes = new List<TaxModel>(),
                Registrations = new List<RegistrationModel>(),
            };

            var flat3 = new FlatModel()
            {
                Street = "Kolotushkina",
                StreetNumber = 12,
                FlatNumber = 6,
                IsColdWaterDevice = false,
                IsElectricPowerDevice = false,
                IsHotWaterDevice = false,
                Taxes = new List<TaxModel>(),
                Registrations = new List<RegistrationModel>(),
            };

            var user1 = new UserProfileModel()
            {
                FirstName = "Test",
                LastName = "Testovich",
                PassportSeries = "1010",
                PassportNumber = "101010",
                Registrations = new List<RegistrationModel>(),
            };

            var user2 = new UserProfileModel()
            {
                FirstName = "Test1",
                LastName = "Testovich1",
                PassportSeries = "1011",
                PassportNumber = "101011",
                Registrations = new List<RegistrationModel>(),
            };

            var user3 = new UserProfileModel()
            {
                FirstName = "Test2",
                LastName = "Testovich2",
                PassportSeries = "1012",
                PassportNumber = "101012",
                Registrations = new List<RegistrationModel>(),
            };

            var user4 = new UserProfileModel()
            {
                FirstName = "Test3",
                LastName = "Testovich3",
                PassportSeries = "1013",
                PassportNumber = "101013",
                Registrations = new List<RegistrationModel>(),
            };

            var registrtionUser1 = new RegistrationModel()
            {
                Flat = flat1,
                User = user1,
                RegistrationDate = new DateTime(2010, 7, 12),
            };

            flat1.Registrations.Add(registrtionUser1);
            user1.Registrations.Add(registrtionUser1);

            var registrtionUser2 = new RegistrationModel()
            {
                Flat = flat2,
                User = user2,
                RegistrationDate = new DateTime(2015, 8, 12),
            };

            flat2.Registrations.Add(registrtionUser2);
            user2.Registrations.Add(registrtionUser2);

            var registrtion1User3 = new RegistrationModel()
            {
                Flat = flat3,
                User = user3,
                RegistrationDate = new DateTime(2017, 8, 12),
                RemoveDate = new DateTime(2023, 9, 15),
            };

            flat3.Registrations.Add(registrtion1User3);
            user3.Registrations.Add(registrtion1User3);

            var registrtion2User3 = new RegistrationModel()
            {
                Flat = flat3,
                User = user4,
                RegistrationDate = new DateTime(2018, 10, 15),
            };

            flat3.Registrations.Add(registrtion2User3);
            user4.Registrations.Add(registrtion2User3);

            var taxFlat1 = new TaxModel()
            {
                Date = new DateTime(2023, 8, 28),
                Residents = 1,
                ColdWaterVolume = 10,
                HotWaterHeatVolume = 10,
                HotWaterThermalEnergyVolume = 0.5349,
                ElectricityDayVolume = 10,
                ElectricityNightVolume = 10,
            };

            flat1.Taxes.Add(taxFlat1);

            var indicationsFlat11 = new IndicationsModel()
            {
                ColdWater = 25,
                HotWaterHeat = 25,
                ElectricityDay = 25,
                ElectricityNight = 25,
            };

            flat1.Indications = indicationsFlat11;

            var taxFlat3 = new TaxModel()
            {
                Date = new DateTime(2023, 8, 28),
                Residents = 2
            };

            flat3.Taxes.Add(taxFlat3);

            var customDate = new DateTime(2023, 9, 28);
            // Act

            taxService.CalculateForTest(flat1);
            taxService.CalculateForTest(flat2);
            taxService.CalculateForTest(flat3);

            // Assert

            // Flat 1

            Assert.AreEqual(Math.Round(flat1.Taxes.Last().ColdWaterVolume, 4), 15);
            Assert.AreEqual(Math.Round(flat1.Taxes.Last().ColdWaterCost, 4), 536.7m);

            Assert.AreEqual(Math.Round(flat1.Taxes.Last().HotWaterHeatVolume, 4), 15);
            Assert.AreEqual(Math.Round(flat1.Taxes.Last().HotWaterHeatCost, 4), 536.7m);

            Assert.AreEqual(Math.Round(flat1.Taxes.Last().HotWaterThermalEnergyVolume, 5), 0.2942);
            Assert.AreEqual(Math.Round(flat1.Taxes.Last().HotWaterThermalEnergyCost, 4), 293.8096m);

            Assert.AreEqual(Math.Round(flat1.Taxes.Last().ElectricityDayVolume, 4), 15);
            Assert.AreEqual(Math.Round(flat1.Taxes.Last().ElectricityDayCost, 4), 73.5m);

            Assert.AreEqual(Math.Round(flat1.Taxes.Last().ElectricityNightVolume, 4), 15);
            Assert.AreEqual(Math.Round(flat1.Taxes.Last().ElectricityNightCost, 4), 34.65m);

            // Flat 2

            Assert.AreEqual(Math.Round(flat2.Taxes.Last().ColdWaterVolume, 4), 4.85);
            Assert.AreEqual(Math.Round(flat2.Taxes.Last().ColdWaterCost, 4), 173.533m);

            Assert.AreEqual(Math.Round(flat2.Taxes.Last().HotWaterHeatVolume, 4), 4.01);
            Assert.AreEqual(Math.Round(flat2.Taxes.Last().HotWaterHeatCost, 4), 143.4778m);

            Assert.AreEqual(Math.Round(flat2.Taxes.Last().HotWaterThermalEnergyVolume, 5), 0.05349);
            Assert.AreEqual(Math.Round(flat2.Taxes.Last().HotWaterThermalEnergyCost, 4), 53.4199m);

            Assert.AreEqual(Math.Round(flat2.Taxes.Last().ElectricPowerVolume, 4), 164);
            Assert.AreEqual(Math.Round(flat2.Taxes.Last().ElectricPowerCost, 4), 701.92m);

            // Flat 3

            Assert.AreEqual(Math.Round(flat3.Taxes.Last().ColdWaterVolume, 4), 7.9217);
            Assert.AreEqual(Math.Round(flat3.Taxes.Last().ColdWaterCost, 4), 283.4372m);

            Assert.AreEqual(Math.Round(flat3.Taxes.Last().HotWaterHeatVolume, 4), 6.5497);
            Assert.AreEqual(Math.Round(flat3.Taxes.Last().HotWaterHeatCost, 4), 234.3471m);

            Assert.AreEqual(Math.Round(flat3.Taxes.Last().HotWaterThermalEnergyVolume, 5), 0.08737);
            Assert.AreEqual(Math.Round(flat3.Taxes.Last().HotWaterThermalEnergyCost, 4), 87.2525m);

            Assert.AreEqual(Math.Round(flat3.Taxes.Last().ElectricPowerVolume, 4), 267, 8667);
            Assert.AreEqual(Math.Round(flat3.Taxes.Last().ElectricPowerCost, 2), 1146.47m);
        }
    }
}