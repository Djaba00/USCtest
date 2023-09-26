using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USCtest.DAL.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }

        public string FlatId { get; set; }
        public virtual ICollection<Flat> Flat { get; set; } 

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
