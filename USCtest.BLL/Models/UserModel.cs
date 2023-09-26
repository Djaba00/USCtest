using System;
using System.Collections.Generic;

namespace USCtest.BLL.Models
{
    public class UserModel
    {
        public string Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }

        public List<FlatModel> Flats { get; set; }
    }
}
