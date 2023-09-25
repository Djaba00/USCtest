using AutoMapper;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using USCtest.BLL.BusinesModels.Helpers;
using USCtest.BLL.DTOEntities;
using USCtest.BLL.Interfaces;
using USCtext.DAL.Entities;

namespace USCtest.BLL.Services
{
    public class TaxService : ITaxService
    {
        IMapper mapper;

        public TaxService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task Calculate(UserDTO user)
        {
            if (!(user is null))
            {
                CommonCalculate(user);
            }
        }

        private async Task CommonCalculate(UserDTO user)
        {
            var coldWater = 0;
            var coldWaterVolume = 0;

            var elecricity = 0;

            var newTax = new TaxDTO()
            {
                Date = DateTime.Now,
                ColdWatherCost = coldWater,
                ColdWaterVolume = coldWaterVolume,
                ElectricPowerCost = elecricity,
            };

            

            user.Flat.Taxes.Add(mapper.Map<Tax>(newTax));
        }

        private double CalculateVolume(UserDTO user, Indications indications)
        {
            var lastTaxDate = user.Flat.Taxes.Max(x => x.Date);
            var lastTax = user.Flat.Taxes.FirstOrDefault(f => f.Date == lastTaxDate);
            var peopleCount = user.Flat.Users.Count;

            switch (indications)
            {
                case Indications.ColdWather:
                    var currentColdWatherVolume = user.Indications.ColdWather;

                    if (user.Flat.IsColdWatherDevice)
                    {
                        var lastVolume = lastTax.ColdWatherVolume;

                        var currentVolume = lastVolume == default ? currentColdWatherVolume : currentColdWatherVolume - lastVolume;

                        return currentVolume;
                    }
                    else
                    {
                        var currentVolume = peopleCount * Normatives.ColdWather;

                        return currentVolume;
                    }

                    break;

                case Indications.HotWatherHeat:

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
                        var lastVolume = lastTax.HotWatherThermalEnergyVolume;

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

                    return electricityDayVolume.Value;

                    break;

                case Indications.ElectricityNight:

                    var electricityNightVolume = user.Indications.ElectricityNight - lastTax.ElectricityNightVolume;

                    return electricityNightVolume.Value;

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
                case Indications.ColdWather:
                    return Convert.ToDecimal(volume * Fees.ColdWather);
                    break;

                case Indications.HotWatherHeat:
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
