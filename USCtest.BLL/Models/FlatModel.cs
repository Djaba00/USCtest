using System.Collections.Generic;
using USCtest.BLL.BusinesModels;

namespace USCtest.BLL.Models
{
    public class FlatModel
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

        public List<TaxModel> Taxes { get; set; }

        public FlatIndications Indications { get; set; }

        public string GetFullAddress()
        {
            if (Building is null)
                return $"ул. {Street} д. {StreetNumber} кв. {FlatNumber}";
            else
                return $"ул. {Street} д. {StreetNumber} строение {Building} кв. {FlatNumber}";
        }
    }
}
