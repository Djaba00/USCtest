using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USCtext.DAL.Entities
{
    public class Flat
    {
        public int Id { get; set; }

        public string Street { get; set; }
        public int StreetNumber { get; set; }
        public int? Building { get; set; }
        public int FlatNumber { get; set; }

        public bool IsColdWatherDevice { get; set; }
        public bool IsHotWatherDevice { get; set; }
        public bool IsElectricPowerDevice { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Tax> Taxes { get; set; }

        public string GetFullAddress()
        {
            if (Building is null)
                return $"ул. {Street} д. {StreetNumber} кв. {FlatNumber}";
            else
                return $"ул. {Street} д. {StreetNumber} строение {Building} кв. {FlatNumber}";
        }
    }
}
