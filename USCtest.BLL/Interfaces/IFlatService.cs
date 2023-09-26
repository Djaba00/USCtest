using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USCtest.BLL.DTOEntities;

namespace USCtest.BLL.Interfaces
{
    public interface IFlatService
    {
        Task<FlatDTO> GetFlatById(int id);
        Task<List<FlatDTO>> GetFlatsByAddress(string address);
        Task CreateFlat(FlatDTO flatDTO);
        Task UpdateFlat(FlatDTO flatDTO);
        Task DeleteUser(int id);
    }
}
