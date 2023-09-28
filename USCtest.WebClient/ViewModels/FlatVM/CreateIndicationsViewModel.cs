namespace USCtest.WebClient.ViewModels.FlatVM
{
    public class CreateIndicationsViewModel
    {
        public int FlatId { get; set; }
        public int UserPrifileId { get; set; }

        public int Residents { get; set; }
        public bool IsColdWaterDevice { get; set; }
        public bool IsHotWaterDevice { get; set; }
        public bool IsElectricPowerDevice { get; set; }

        public IndicationsViewModel IndicationsViewModel { get; set; }

        public CreateIndicationsViewModel()
        {
            IndicationsViewModel = new IndicationsViewModel();
        }
    }
}
