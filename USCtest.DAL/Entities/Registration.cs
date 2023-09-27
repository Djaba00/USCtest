using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USCtest.DAL.Entities
{
    public class Registration
    {
        public int UserId { get; set; }
        public virtual UserProfile User { get; set; }

        public int FlatId { get; set; }
        public virtual Flat Flat { get; set; }

        public DateTime RegistrationDate { get; set; }
        public DateTime? RemoveDate { get; set; }
    }
}
