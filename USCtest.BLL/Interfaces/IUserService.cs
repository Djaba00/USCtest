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
        Task<List<UserModel>> GetAllUsersAsync();
        Task<UserModel> GetUserByIdAsync(string id);
        Task<List<UserModel>> GetUsersByNameAsync(string name);
        Task CreateUserAsync(UserModel userDto);
        Task ChangeRegistrationAsync(UserModel userDto);
        Task UpdateUserAccountAsync(UserModel userDto);
        Task DeleteUserAsync(string id);
    }
}
