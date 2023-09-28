using System.Collections.Generic;
using USCtest.BLL.BusinesModels;
using USCtest.BLL.Models;

namespace USCtest.WebClient.ViewModels.FlatVM
{
    public class CreateFlatViewModel
    {
        public string Street { get; set; }
        public int StreetNumber { get; set; }
        public int? Building { get; set; }
        public int FlatNumber { get; set; }

        public bool IsColdWaterDevice { get; set; }
        public bool IsHotWaterDevice { get; set; }
        public bool IsElectricPowerDevice { get; set; }
    }
}
