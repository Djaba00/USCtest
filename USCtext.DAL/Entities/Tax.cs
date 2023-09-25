using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USCtext.DAL.Entities
{
    public class Tax
    {
        public int Id { get; set; }

        public double ColdWatherVolume { get; set; }
        public decimal ColdWather { get; set; }
        public double HotWatherVolume { get; set; }
        public decimal HotWather { get; set; }
        public double ElectricPowerVolume { get; set; }
        public decimal ElectricPower { get; set; }

        public bool IsPayed { get; set; }

        public string FlatId { get; set; }
        public Flat Flat { get; set; }
    }
}
