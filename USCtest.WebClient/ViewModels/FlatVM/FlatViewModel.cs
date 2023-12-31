﻿using System.Collections.Generic;
using USCtest.BLL.Models;
using USCtest.WebClient.ViewModels.RegistrationVM;
using USCtest.WebClient.ViewModels.TaxVM;

namespace USCtest.WebClient.ViewModels.FlatVM
{
    public class FlatViewModel
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public bool IsColdWaterDevice { get; set; }
        public bool IsHotWaterDevice { get; set; }
        public bool IsElectricPowerDevice { get; set; }

        public int Residents { get; set; }

        public decimal Debt { get; set; }

        public List<RegistrationViewModel> Registrations { get; set; }

        public List<TaxViewModel> Taxes { get; set; }
    }
}
