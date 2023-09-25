using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USCtext.DAL.Entities;

namespace USCtest.BLL.DTOEntities
{
    public class FlatDTO
    {
        public int Id { get; set; }

        public string Street { get; set; }
        public int StreetNumber { get; set; }
        public int? Building { get; set; }
        public int FlatNumber { get; set; }

        public bool IsColdWatherDevice { get; set; }
        public bool IsHotWatherDevice { get; set; }
        public bool IsElectricPowerDevice { get; set; }

        public int Residents { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Tax> Taxes { get; set; }
    }
}
