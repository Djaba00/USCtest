using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USCtest.BLL.BusinesModels;
using USCtext.DAL.Entities;

namespace USCtest.BLL.DTOEntities
{
    public class UserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }

        public string FlatId { get; set; }
        public FlatDTO Flat { get; set; }

        public UserIndications Indications { get; set; }
}
}
