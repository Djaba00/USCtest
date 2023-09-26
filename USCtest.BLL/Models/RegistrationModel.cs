using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USCtest.BLL.Models
{
    public class RegistrationModel
    {
        public string UserId { get; set; }
        public int FlatId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? RemoveDate { get; set; }
    }
}
