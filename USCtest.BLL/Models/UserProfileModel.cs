using System;
using System.Collections.Generic;
using System.Globalization;

namespace USCtest.BLL.Models
{
    public class UserProfileModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }

        //public List<FlatModel> Flats { get; set; }

        public List<RegistrationModel> Registrations { get; set; }

        public string GetFullName()
        {
            return $"{LastName} {FirstName} {MiddleName}";
        }

        public string GetFullPassport()
        {
            return PassportSeries + PassportNumber;
        }
    }
}
