using System;
using System.Collections.Generic;
using System.Globalization;

namespace USCtest.BLL.Models
{
    public class UserModel
    {
        public string Id { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }

        public List<FlatModel> Flats { get; set; }

        public List<RegistrationModel> Registrations { get; set; }
    }
}
