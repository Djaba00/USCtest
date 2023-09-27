using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USCtest.DAL.Entities;

namespace USCtest.BLL.Models
{
    public class RegistrationModel
    {
        public int UserId { get; set; }
        public virtual UserProfileModel User { get; set; }

        public int FlatId { get; set; }
        public virtual FlatModel Flat { get; set; }

        public DateTime RegistrationDate { get; set; }
        public DateTime? RemoveDate { get; set; }
    }
}
