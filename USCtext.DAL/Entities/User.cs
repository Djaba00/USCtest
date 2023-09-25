using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USCtext.DAL.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int PassportSeries { get; set; }
        public int PassportNumber { get; set; }

        public string FlatId { get; set; }
        public Flat Flat {  get; set; }
    }
}
