using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USCtest.BLL.BusinesModels
{
    public class UserIndications
    {
        public double ColdWather { get; set; }
        public double HotWaterHeat { get; set; }
        public double Electricity { get; set; }
        public double ElectricityDay { get; set; }
        public double ElectricityNight { get; set; }

        public UserIndications() { }
    }
}
