using System.Collections.Generic;
using USCtest.BLL.Models;

namespace USCtest.WebClient.ViewModels.UserVM
{
    public class UserViewModel
    {
        public string Id { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }

        public string FullName { get; set; }

        public string Passport { get; set; }

        public List<string> Flats { get; set; }
    }
}