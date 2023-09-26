using System;

namespace USCtest.BLL.Models
{
    public class TaxModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public bool IsPayed { get; set; }

        public double ColdWaterVolume { get; set; }
        public decimal ColdWatherCost { get; set; }

        public double HotWatherHeatVolume { get; set; }
        public decimal HotWatherHeatCost { get; set; }

        public double HotWatherThermalEnergyVolume { get; set; }
        public decimal HotWatherThermalEnergyCost { get; set; }

        public double ElectricPowerVolume { get; set; }
        public decimal ElectricPowerCost { get; set; }

        public double ElectricityDayVolume { get; set; }
        public decimal ElectricityDayCost { get; set; }

        public double ElectricityNightVolume { get; set; }
        public decimal ElectricityNightCost { get; set; }
    }
}
