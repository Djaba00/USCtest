using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USCtest.DAL.Entities
{
    public class UserProfile
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }

        public string FlatId { get; set; }
        public virtual ICollection<Flat> Flats { get; set; }

        public virtual ICollection<Registration> Registrations { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

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
