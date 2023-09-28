using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using USCtest.BLL.Models;

namespace USCtest.BLL.Interfaces
{
    public interface IUserService
    {
        Task<List<UserProfileModel>> GetAllUsersAsync();
        Task<UserProfileModel> GetUserByIdAsync(int id);
        Task<List<UserProfileModel>> GetUsersByNameAsync(string name);
        Task CreateUserAsync(UserProfileModel userDto);
        Task DeleteUserAsync(int id);

        Task AddNewRegistrtionAsync(RegistrationModel registrationModel);
        Task UpdateRegistrtionAsync(RegistrationModel registrationModel);
    }
}
