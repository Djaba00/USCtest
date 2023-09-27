using System.Collections.Generic;
using USCtest.WebClient.ViewModels.FlatVM;

namespace USCtest.WebClient.ViewModels.UserVM
{
    public class UpdateUserViewModel
    {
        public int Id { get; set; }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }

        public List<FlatViewModel> Flats { get; set; }
    }
}
