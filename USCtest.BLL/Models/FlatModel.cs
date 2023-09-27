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

        //public List<UserProfileModel> Users { get; set; }

        public List<TaxModel> Taxes { get; set; }

        public List<RegistrationModel> Registrations { get; set; }

        public FlatIndications Indications { get; set; }

        public string GetFullAddress()
        {
            if (Building is null)
                return $"ул. {Street} д. {StreetNumber} кв. {FlatNumber}";
            else
                return $"ул. {Street} д. {StreetNumber} строение {Building} кв. {FlatNumber}";
        }

        public decimal GetDebt()
        {
            decimal debt = 0;

            foreach (var tax in  Taxes)
            {
                debt += tax.IsPayed ? 0 : tax.SummaryCost; 
            }

            return debt;
        }
    }
}
