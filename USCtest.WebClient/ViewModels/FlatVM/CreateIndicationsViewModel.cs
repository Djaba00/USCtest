namespace USCtest.WebClient.ViewModels.FlatVM
{
    public class CreateIndicationsViewModel
    {
        public int FlatId { get; set; }

        public bool IsColdWatherDevice { get; set; }
        public bool IsHotWatherDevice { get; set; }
        public bool IsElectricPowerDevice { get; set; }

        public IndicationsViewModel IndicationsViewModel { get; set; }

        public CreateIndicationsViewModel()
        {
            IndicationsViewModel = new IndicationsViewModel();
        }
    }
}
