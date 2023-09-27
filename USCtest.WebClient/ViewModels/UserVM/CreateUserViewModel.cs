using System.Collections.Generic;

namespace USCtest.WebClient.ViewModels.UserVM
{
    public class CreateUserViewModel
    {
        public int Id { get; set; }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        public string PassportSeries{ get; set; }
        public string PassportNumber{ get; set; }

        public List<string> Flats { get; set; }
    }
}
