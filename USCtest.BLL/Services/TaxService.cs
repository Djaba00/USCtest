using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;
using USCtest.BLL.BusinesModels.Helpers;
using USCtest.BLL.Models;
using USCtest.BLL.Interfaces;
using USCtest.DAL.Entities;
using USCtest.DAL.Interfaces;
using System.Security.Cryptography.Xml;
using System.Collections.Generic;

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
            //flatModel.Taxes.Add(CommonCalculate(flatModel));

            //var updateFlat = mapper.Map<Flat>(flatModel);

            var taxModel = CommonCalculate(flatModel);

            var tax = mapper.Map<Tax>(taxModel);

            await db.Taxes.CreateAsync(tax);
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

        public void CalculateForTest(FlatModel flatModel, DateTime? customDate = null)
        {
            flatModel.Taxes.Add(CommonCalculate(flatModel, customDate));
        }

        private TaxModel CommonCalculate(FlatModel flatModel, DateTime? customDate = null)
        {
            var coldWaterVolume = CalculateVolume(flatModel, Indications.ColdWater);
            var coldWaterCost = CalculateCost(flatModel, Indications.ColdWater, coldWaterVolume);

            var hotWaterHeatVolume = CalculateVolume(flatModel, Indications.HotWaterHeat);
            var hotWaterHeatCost = CalculateCost(flatModel, Indications.HotWaterHeat, hotWaterHeatVolume);

            var hotWaterHotWaterThermalEnergytVolume = CalculateVolume(flatModel, Indications.HotWaterThermalEnergy);
            var hotWaterHotWaterThermalEnergytCost = CalculateCost(flatModel, Indications.HotWaterThermalEnergy, hotWaterHotWaterThermalEnergytVolume);

            double electricityDayVolume = 0;
            decimal electricityDayCost = 0;

            double electricityNightVolume = 0;
            decimal electricityNightCost = 0;
            double electricyVolume = 0;
            decimal electricyCost = 0;

            if (flatModel.IsElectricPowerDevice)
            {
                electricityDayVolume = CalculateVolume(flatModel, Indications.ElectricityDay);
                electricityDayCost = CalculateCost(flatModel, Indications.ElectricityDay, electricityDayVolume);

                electricityNightVolume = CalculateVolume(flatModel, Indications.ElectricityNight);
                electricityNightCost = CalculateCost(flatModel, Indications.ElectricityNight, electricityNightVolume);
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
                FlatId = flatModel.Id,
                Date = customDate is null? DateTime.Now.Date : customDate.Value,
                Residents = flatModel.GetResidentsCount(),
                ColdWaterVolume = coldWaterVolume,
                ColdWaterCost = coldWaterCost,
                HotWaterHeatVolume = hotWaterHeatVolume,
                HotWaterHeatCost = hotWaterHeatCost,
                HotWaterThermalEnergyVolume = hotWaterHotWaterThermalEnergytVolume,
                HotWaterThermalEnergyCost = hotWaterHotWaterThermalEnergytCost,
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

            double daysCount = Normatives.BillingPeriod;

            bool IsEqualResidents = true;

            var residents = new List<int>();

            if (flatModel.Taxes.Count != 0)
            {
                IsEqualResidents = flatModel.GetResidentsCount() == lastTax.Residents;

                lastTax = flatModel.Taxes.OrderBy(x => x.Date).Last();
                daysCount = Math.Ceiling((DateTime.Now.Date - lastTax.Date).TotalDays);

                foreach (var user in flatModel.Registrations )
                {
                    if (lastTax.Date != DateTime.MinValue && user.RemoveDate < DateTime.Now.Date && user.RemoveDate > lastTax.Date)
                    {
                        var days = user.RemoveDate.Value.Subtract(lastTax.Date).Days;
                        residents.Add(days);
                    }
                }
            }
           
            var peopleCount = flatModel.GetResidentsCount();

            switch (indications)
            {
                case Indications.ColdWater:
                    

                    if (flatModel.IsColdWaterDevice)
                    {
                        var currentColdWaterVolume = flatModel.Indications.ColdWater;

                        var lastVolume = lastTax.ColdWaterVolume;

                        var currentVolume = lastVolume == default ? currentColdWaterVolume : currentColdWaterVolume - lastVolume;

                        return currentVolume;
                    }
                    else
                    {
                        var currentVolume = peopleCount * daysCount * Normatives.ColdWater / Normatives.BillingPeriod;

                        if (!IsEqualResidents)
                        {
                            foreach (var days in residents)
                            {
                                currentVolume += days * Normatives.ColdWater / Normatives.BillingPeriod;
                            }
                        }

                        return currentVolume;
                    }

                case Indications.HotWaterHeat:

                    if (flatModel.IsHotWaterDevice)
                    {

                        var waterHeatVolume = flatModel.Indications.HotWaterHeat;

                        var lastVolume = lastTax.HotWaterHeatVolume;

                        var currentVolume = lastVolume == default ? waterHeatVolume : waterHeatVolume - lastVolume;

                        return currentVolume;
                    }
                    else
                    {
                        var currentVolume = peopleCount * daysCount * Normatives.HotWaterHeat / Normatives.BillingPeriod;

                        if (!IsEqualResidents)
                        {
                            foreach (var days in residents)
                            {
                                currentVolume += days * Normatives.HotWaterHeat / Normatives.BillingPeriod;
                            }
                        }

                        return currentVolume;
                    }

                case Indications.HotWaterThermalEnergy:

                    if (flatModel.IsHotWaterDevice)
                    {
                        var waterHeat = flatModel.Indications.HotWaterHeat - lastTax.HotWaterHeatVolume;
                        var thermalEnergyVolume = waterHeat * daysCount * Normatives.HotWaterThermalEnergy / Normatives.BillingPeriod;

                        if (!IsEqualResidents)
                        {
                            foreach (var days in residents)
                            {
                                thermalEnergyVolume += days * Normatives.HotWaterThermalEnergy / Normatives.BillingPeriod;
                            }
                        }

                        var lastVolume = lastTax.HotWaterThermalEnergyVolume;

                        var currentVolume = lastVolume == default ? thermalEnergyVolume : thermalEnergyVolume - lastVolume;

                        return currentVolume;
                    }
                    else
                    {
                        var currentVolume = peopleCount * daysCount * Normatives.HotWaterThermalEnergy / Normatives.BillingPeriod;

                        if (!IsEqualResidents)
                        {
                            foreach (var days in residents)
                            {
                                currentVolume += days * Normatives.HotWaterThermalEnergy / Normatives.BillingPeriod;
                            }
                        }

                        return currentVolume;
                    }

                case Indications.Electricity:

                    var electricityVolume = peopleCount * daysCount * Normatives.Electricity / Normatives.BillingPeriod;

                    if (!IsEqualResidents)
                    {
                        foreach (var days in residents)
                        {
                            electricityVolume += days * Normatives.Electricity / Normatives.BillingPeriod;
                        }
                    }

                    return electricityVolume;

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
                    return Convert.ToDecimal(volume * Fees.ColdWater);

                case Indications.HotWaterHeat:
                    return Convert.ToDecimal(volume * Fees.HotWaterHeat);

                case Indications.HotWaterThermalEnergy:
                    return Convert.ToDecimal(volume * Fees.HotWaterThermalEnergy);

                case Indications.Electricity:
                    return Convert.ToDecimal(volume * Fees.Electricity);

                case Indications.ElectricityDay:
                    return Convert.ToDecimal(volume * Fees.ElectricityDay);

                case Indications.ElectricityNight:
                    return Convert.ToDecimal(volume * Fees.ElectricityNight);

                default:
                    return 0;
            }
        }

    }
}
