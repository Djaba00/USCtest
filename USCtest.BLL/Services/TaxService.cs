using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using USCtest.BLL.BusinesModels.Helpers;
using USCtest.BLL.DTOEntities;
using USCtest.BLL.Interfaces;
using USCtext.DAL.Entities;
using USCtext.DAL.Interfaces;

namespace USCtest.BLL.Services
{
    public class TaxService : ITaxService
    {
        IUnitOfWork db;
        IMapper mapper;

        public TaxService(IUnitOfWork db, IMapper mapper, Microsoft.AspNetCore.Identity.UserManager<User> userManager)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task Calculate(UserDTO user)
        {
            CommonCalculate(user);

            await db.Users.UpdateAsync(mapper.Map<User>(user));
        }

        private void CommonCalculate(UserDTO user)
        {
            var coldWaterVolume = CalculateVolume(user, Indications.ColdWater);
            var coldWaterCost = CalculateCost(user, Indications.ColdWater, coldWaterVolume);

            var hotWaterHeatVolume = CalculateVolume(user, Indications.HotWaterHeat);
            var hotWaterHeatCost = CalculateCost(user, Indications.HotWaterHeat, hotWaterHeatVolume);

            var hotWaterHotWaterThermalEnergytVolume = CalculateVolume(user, Indications.HotWatherThermalEnergy);
            var hotWaterHotWaterThermalEnergytCost = CalculateCost(user, Indications.HotWatherThermalEnergy, hotWaterHotWaterThermalEnergytVolume);

            double electricityDayVolume = 0;
            decimal electricityDayCost = 0;

            double electricityNightVolume = 0;
            decimal electricityNightCost = 0;
            double electricyVolume = 0;
            decimal electricyCost = 0;

            if (user.Flat.IsElectricPowerDevice)
            {
                electricityDayVolume = CalculateVolume(user, Indications.ElectricityDay);
                electricityDayCost = CalculateCost(user, Indications.ElectricityDay);

                electricityNightVolume = CalculateVolume(user, Indications.ElectricityNight);
                electricityNightCost = CalculateCost(user, Indications.ElectricityNight);
            }
            else
            {
                electricyVolume = CalculateVolume(user, Indications.Electricity);
                electricyCost = CalculateCost(user, Indications.Electricity, electricyVolume);
            }


            var newTaxDto = new TaxDTO()
            {
                Date = DateTime.Now,
                ColdWaterVolume = coldWaterVolume,
                ColdWatherCost = coldWaterCost,
                HotWatherHeatVolume = hotWaterHeatVolume,
                HotWatherHeatCost = hotWaterHeatCost,
                HotWatherThermalEnergytVolume = hotWaterHotWaterThermalEnergytVolume,
                HotWatherThermalEnergyCost = hotWaterHotWaterThermalEnergytCost,
                ElectricPowerVolume = electricyVolume,
                ElectricPowerCost = electricyCost,
                ElectricityDayVolume = electricityDayVolume,
                ElectricityDayCost = electricityDayCost,
                ElectricityNightVolume = electricityNightVolume,
                ElectricityNightCost = electricityNightCost,
            };

            user.Flat.Taxes.Add(newTaxDto);
        }

        private double CalculateVolume(UserDTO user, Indications indications)
        {
            var lastTaxDate = user.Flat.Taxes.Max(x => x.Date);
            var lastTax = user.Flat.Taxes.FirstOrDefault(f => f.Date == lastTaxDate);
            var peopleCount = user.Flat.Users.Count;

            switch (indications)
            {
                case Indications.ColdWater:
                    var currentColdWatherVolume = user.Indications.ColdWather;

                    if (user.Flat.IsColdWatherDevice)
                    {
                        var lastVolume = lastTax.ColdWaterVolume;

                        var currentVolume = lastVolume == default ? currentColdWatherVolume : currentColdWatherVolume - lastVolume;

                        return currentVolume;
                    }
                    else
                    {
                        var currentVolume = peopleCount * Normatives.ColdWather;

                        return currentVolume;
                    }

                    break;

                case Indications.HotWaterHeat:

                    var watherHeatVolume = user.Indications.HotWatherHeat;

                    if (user.Flat.IsHotWatherDevice)
                    {
                        var lastVolume = lastTax.HotWatherHeatVolume;

                        var currentVolume = lastVolume == default ? watherHeatVolume : watherHeatVolume - lastVolume;

                        return currentVolume;
                    }
                    else
                    {
                        var currentVolume = peopleCount * Normatives.HotWatherHeat;

                        return currentVolume;
                    }

                    break;

                case Indications.HotWatherThermalEnergy:

                    var watherHeat = user.Indications.HotWatherHeat;
                    var thermalEnergyVolume = watherHeat * Normatives.HotWatherHeat;

                    if (user.Flat.IsHotWatherDevice)
                    {
                        var lastVolume = lastTax.HotWatherThermalEnergytVolume;

                        var currentVolume = lastVolume == default ? thermalEnergyVolume : thermalEnergyVolume - lastVolume;

                        return currentVolume;
                    }
                    else
                    {
                        var currentVolume = peopleCount * Normatives.HotWatherThermalEnergy;

                        return currentVolume;
                    }

                    break;

                case Indications.Electricity:

                    var electricityVolume = user.Indications.Electricity;

                    var currentElectricityVolume = peopleCount * Normatives.Electricity;

                    return currentElectricityVolume;

                    break;

                case Indications.ElectricityDay:

                    var electricityDayVolume = user.Indications.ElectricityDay - lastTax.ElectricityDayVolume;

                    return electricityDayVolume;

                    break;

                case Indications.ElectricityNight:

                    var electricityNightVolume = user.Indications.ElectricityNight - lastTax.ElectricityNightVolume;

                    return electricityNightVolume;

                    break;

                default:
                    return 0;
                    break;
            }
        }

        private decimal CalculateCost(UserDTO user, Indications indications, double volume = 0)
        {
            switch (indications)
            {
                case Indications.ColdWater:
                    return Convert.ToDecimal(volume * Fees.ColdWather);
                    break;

                case Indications.HotWaterHeat:
                    return Convert.ToDecimal(volume * Fees.HotWatherHeat);
                    break;

                case Indications.HotWatherThermalEnergy:
                    return Convert.ToDecimal(volume * Fees.HotWatherThermalEnergy);
                    break;

                case Indications.Electricity:
                    return Convert.ToDecimal(volume * Fees.ColdWather);
                    break;

                case Indications.ElectricityDay:
                    return Convert.ToDecimal(user.Indications.ElectricityDay * Fees.ElectricityDay);
                    break;

                case Indications.ElectricityNight:
                    return Convert.ToDecimal(user.Indications.ElectricityNight * Fees.ElectricityNight);
                    break;

                default:
                    return 0;
                    break;
            }
        }

    }
}
