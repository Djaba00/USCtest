using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USCtext.DAL.Entities;

namespace USCtest.BLL.DTOEntities
{
    public class TaxDTO
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public bool IsPayed { get; set; }

        public double ColdWaterVolume { get; set; }
        public decimal ColdWatherCost { get; set; }

        public double HotWatherHeatVolume { get; set; }
        public decimal HotWatherHeatCost { get; set; }

        public double HotWatherThermalEnergytVolume { get; set; }
        public decimal HotWatherThermalEnergyCost { get; set; }

        public double ElectricPowerVolume { get; set; }
        public decimal ElectricPowerCost { get; set; }

        public double ElectricityDayVolume { get; set; }
        public decimal ElectricityDayCost { get; set; }

        public double ElectricityNightVolume { get; set; }
        public decimal ElectricityNightCost { get; set; }

        public string FlatId { get; set; }
        public Flat Flat { get; set; }
    }
}
