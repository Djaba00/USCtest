using System.Collections.Generic;
using USCtest.BLL.Models;

namespace USCtest.WebClient.ViewModels.FlatVM
{
    public class FlatViewModel
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public bool IsColdWatherDevice { get; set; }
        public bool IsHotWatherDevice { get; set; }
        public bool IsElectricPowerDevice { get; set; }

        public int Residents { get; set; }

        public List<string> Users { get; set; }
    }
}
