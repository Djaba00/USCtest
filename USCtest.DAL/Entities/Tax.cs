using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace USCtest.DAL.Entities
{
    public class Tax
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public bool IsPayed { get; set; }

        public int Residents { get; set; }

        public double ColdWaterVolume { get; set; }
        public decimal ColdWaterCost { get; set; }

        public double HotWaterHeatVolume { get; set; }
        public decimal HotWaterHeatCost { get; set; }

        public double HotWaterThermalEnergyVolume { get; set; }
        public decimal HotWaterThermalEnergyCost { get; set; }

        public double ElectricPowerVolume { get; set; }
        public decimal ElectricPowerCost { get; set; }

        public double ElectricityDayVolume { get; set; }
        public decimal ElectricityDayCost { get; set; }

        public double ElectricityNightVolume { get; set; }
        public decimal ElectricityNightCost { get; set; }

        public decimal SummaryCost { get; set; }

        public int FlatId { get; set; }
        public virtual Flat Flat { get; set; }
    }
}
