using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USCtest.BLL.Models;

namespace USCtest.BLL.Interfaces
{
    public interface IFlatService
    {
        Task<FlatModel> GetFlatById(int id);
        Task<List<FlatModel>> GetFlatsByAddress(string address);
        Task CreateFlat(FlatModel flatDTO);
        Task UpdateFlat(FlatModel flatDTO);
        Task DeleteUser(int id);
    }
}
