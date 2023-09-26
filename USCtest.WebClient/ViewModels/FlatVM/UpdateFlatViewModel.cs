﻿using System.Collections.Generic;
using USCtest.BLL.Models;

namespace USCtest.WebClient.ViewModels.FlatVM
{
    public class UpdateFlatViewModel
    {
        public int Id { get; set; }

        public string Street { get; set; }
        public int StreetNumber { get; set; }
        public int? Building { get; set; }
        public int FlatNumber { get; set; }

        public bool IsColdWatherDevice { get; set; }
        public bool IsHotWatherDevice { get; set; }
        public bool IsElectricPowerDevice { get; set; }

        public List<UserModel> Users { get; set; }
    }
}
