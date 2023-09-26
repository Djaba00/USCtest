﻿using System;
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

        public double ColdWatherVolume { get; set; }
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

        public string FlatId { get; set; }
        public virtual Flat Flat { get; set; }
    }
}