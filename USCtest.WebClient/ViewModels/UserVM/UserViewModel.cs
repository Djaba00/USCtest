using System.Collections.Generic;
using USCtest.BLL.Models;
using USCtest.WebClient.ViewModels.FlatVM;
using USCtest.WebClient.ViewModels.RegistrationVM;

namespace USCtest.WebClient.ViewModels.UserVM
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Passport { get; set; }

        public List<RegistrationViewModel> Registrations { get; set; }
    }
}