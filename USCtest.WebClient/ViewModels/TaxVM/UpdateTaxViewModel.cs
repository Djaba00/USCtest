using USCtest.BLL.Models;

namespace USCtest.WebClient.ViewModels.TaxVM
{
    public class UpdateTaxViewModel
    {
        public int Id { get; set; }

        public bool IsPayed { get; set; }

        public int Residents { get; set; }

        public double ColdWater { get; set; }
        public double HotWaterHeat { get; set; }
        public double Electricity { get; set; }
        public double ElectricityDay { get; set; }
        public double ElectricityNight { get; set; }

        public int FlatId { get; set; }
        public virtual string Flat { get; set; }
    }
}