﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USCtest.DAL.Entities
{
    public class Flat
    {
        public int Id { get; set; }

        public string Street { get; set; }
        public int StreetNumber { get; set; }
        public int? Building { get; set; }
        public int FlatNumber { get; set; }

        public bool IsColdWaterDevice { get; set; }
        public bool IsHotWaterDevice { get; set; }
        public bool IsElectricPowerDevice { get; set; }

        public virtual ICollection<UserProfile> Users { get; set; }

        public virtual ICollection<Tax> Taxes { get; set; }

        public virtual ICollection<Registration> Registrations { get; set; }

        public string GetFullAddress()
        {
            if (Building is null)
                return $"ул. {Street} д. {StreetNumber} кв. {FlatNumber}";
            else
                return $"ул. {Street} д. {StreetNumber} строение {Building} кв. {FlatNumber}";
        }
    }
}
