using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using USCtest.BLL.BusinesModels.Helpers;
using USCtest.BLL.Models;
using USCtest.BLL.Interfaces;
using USCtest.DAL.Entities;
using USCtest.DAL.Interfaces;
using USCtest.DAL.Repositories;

namespace USCtest.BLL.Services
{
    public class TaxService : ITaxService
    {
        IUnitOfWork db;
        IMapper mapper;

        public TaxService(IUnitOfWork db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task TaxPaymentAsync(int taxId)
        {
            var currentTax = await db.Taxes.GetAsync(taxId);

            if (currentTax != null)
            {
                currentTax.IsPayed = true;

                await db.Taxes.UpdateAsync(currentTax);
            }
        }

        public async Task CreateTaxAsync(FlatModel flatModel)
        {
            flatModel.Taxes.Add(CommonCalculate(flatModel));

            var updateFlat = mapper.Map<Flat>(flatModel);

            await db.Flats.UpdateAsync(updateFlat);
        }

        public async Task UpdateTaxAsync(int taxId)
        {
            var currentTax = await db.Taxes.GetAsync(taxId);

            if (currentTax != null)
            {
                var flat = mapper.Map<FlatModel>(currentTax.Flat);

                var updTax = mapper.Map<Tax>(CommonCalculate(flat));

                currentTax = updTax;

                await db.Taxes.UpdateAsync(currentTax);
            }
        }

        public void CalculateForTest(FlatModel flatModel)
        {
            CommonCalculate(flatModel);
        }

        private TaxModel CommonCalculate(FlatModel flatModel)
        {
            var coldWaterVolume = CalculateVolume(flatModel, Indications.ColdWater);
            var coldWaterCost = CalculateCost(flatModel, Indications.ColdWater, coldWaterVolume);

            var hotWaterHeatVolume = CalculateVolume(flatModel, Indications.HotWaterHeat);
            var hotWaterHeatCost = CalculateCost(flatModel, Indications.HotWaterHeat, hotWaterHeatVolume);

            var hotWaterHotWaterThermalEnergytVolume = CalculateVolume(flatModel, Indications.HotWatherThermalEnergy);
            var hotWaterHotWaterThermalEnergytCost = CalculateCost(flatModel, Indications.HotWatherThermalEnergy, hotWaterHotWaterThermalEnergytVolume);

            double electricityDayVolume = 0;
            decimal electricityDayCost = 0;

            double electricityNightVolume = 0;
            decimal electricityNightCost = 0;
            double electricyVolume = 0;
            decimal electricyCost = 0;

            if (flatModel.IsElectricPowerDevice)
            {
                electricityDayVolume = CalculateVolume(flatModel, Indications.ElectricityDay);
                electricityDayCost = CalculateCost(flatModel, Indications.ElectricityDay);

                electricityNightVolume = CalculateVolume(flatModel, Indications.ElectricityNight);
                electricityNightCost = CalculateCost(flatModel, Indications.ElectricityNight);
            }
            else
            {
                electricyVolume = CalculateVolume(flatModel, Indications.Electricity);
                electricyCost = CalculateCost(flatModel, Indications.Electricity, electricyVolume);
            }

            var summaryCost = coldWaterCost + hotWaterHeatCost + hotWaterHotWaterThermalEnergytCost +
                +electricityDayCost + electricityNightCost + electricyCost;

            var newTaxModel = new TaxModel()
            {
                Date = DateTime.Now,
                ColdWaterVolume = coldWaterVolume,
                ColdWatherCost = coldWaterCost,
                HotWatherHeatVolume = hotWaterHeatVolume,
                HotWatherHeatCost = hotWaterHeatCost,
                HotWatherThermalEnergyVolume = hotWaterHotWaterThermalEnergytVolume,
                HotWatherThermalEnergyCost = hotWaterHotWaterThermalEnergytCost,
                ElectricPowerVolume = electricyVolume,
                ElectricPowerCost = electricyCost,
                ElectricityDayVolume = electricityDayVolume,
                ElectricityDayCost = electricityDayCost,
                ElectricityNightVolume = electricityNightVolume,
                ElectricityNightCost = electricityNightCost,
                SummaryCost = summaryCost,
            };

            return newTaxModel;
        }

        protected double CalculateVolume(FlatModel flatModel, Indications indications)
        {
            TaxModel lastTax = new TaxModel(); 

            if (flatModel.Taxes.Count != 0)
            {
                lastTax = flatModel.Taxes.OrderBy(x => x.Date).Last();
                //lastTax = flatModel.Taxes.FirstOrDefault(f => f.Date == lastTaxDate);
            }
           
            var peopleCount = flatModel.Registrations.Where(r => r.RemoveDate > DateTime.MinValue).Count();

            switch (indications)
            {
                case Indications.ColdWater:
                    var currentColdWatherVolume = flatModel.Indications.ColdWather;

                    if (flatModel.IsColdWatherDevice)
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

                case Indications.HotWaterHeat:

                    var watherHeatVolume = flatModel.Indications.HotWaterHeat;

                    if (flatModel.IsHotWatherDevice)
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

                case Indications.HotWatherThermalEnergy:

                    var watherHeat = flatModel.Indications.HotWaterHeat;
                    var thermalEnergyVolume = watherHeat * Normatives.HotWatherThermalEnergy;

                    if (flatModel.IsHotWatherDevice)
                    {
                        var lastVolume = lastTax.HotWatherThermalEnergyVolume;

                        var currentVolume = lastVolume == default ? thermalEnergyVolume : thermalEnergyVolume - lastVolume;

                        return currentVolume;
                    }
                    else
                    {
                        var currentVolume = peopleCount * Normatives.HotWatherThermalEnergy;

                        return currentVolume;
                    }

                case Indications.Electricity:

                    var electricityVolume = flatModel.Indications.Electricity;

                    var currentElectricityVolume = peopleCount * Normatives.Electricity;

                    return currentElectricityVolume;

                case Indications.ElectricityDay:

                    var electricityDayVolume = flatModel.Indications.ElectricityDay - lastTax.ElectricityDayVolume;

                    return electricityDayVolume;

                case Indications.ElectricityNight:

                    var electricityNightVolume = flatModel.Indications.ElectricityNight - lastTax.ElectricityNightVolume;

                    return electricityNightVolume;

                default:
                    return 0;
            }
        }

        private decimal CalculateCost(FlatModel flatModel, Indications indications, double volume = 0)
        {
            switch (indications)
            {
                case Indications.ColdWater:
                    return Convert.ToDecimal(volume * Fees.ColdWather);

                case Indications.HotWaterHeat:
                    return Convert.ToDecimal(volume * Fees.HotWatherHeat);

                case Indications.HotWatherThermalEnergy:
                    return Convert.ToDecimal(volume * Fees.HotWatherThermalEnergy);

                case Indications.Electricity:
                    return Convert.ToDecimal(volume * Fees.ColdWather);

                case Indications.ElectricityDay:
                    return Convert.ToDecimal(flatModel.Indications.ElectricityDay * Fees.ElectricityDay);

                case Indications.ElectricityNight:
                    return Convert.ToDecimal(flatModel.Indications.ElectricityNight * Fees.ElectricityNight);

                default:
                    return 0;
            }
        }

    }
}
