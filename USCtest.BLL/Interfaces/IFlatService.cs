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
        Task<List<FlatModel>> GetAllFlatsAsync();
        Task<FlatModel> GetFlatByIdAsync(int id);
        Task<FlatModel> GetFlatByAddressAsync(string name);
        Task<List<FlatModel>> GetFlatsByAddressAsync(string address);
        Task AddRegistration(FlatModel flatModel, RegistrationModel registrationModel);
        Task UpdateRegistration(int flatId, RegistrationModel registrationModel);
        Task CreateFlatAsync(FlatModel flatModel);
        Task UpdateFlatAsync(FlatModel flatModel);
        Task DeleteUserAsync(int id);
    }
}
