using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USCtest.BLL.DTOEntities;

namespace USCtest.BLL.Interfaces
{
    public interface ITaxService
    {
        Task Calculate(UserDTO user);
    }
}
