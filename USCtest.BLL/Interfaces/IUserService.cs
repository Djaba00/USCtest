using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USCtest.BLL.DTOEntities;

namespace USCtest.BLL.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> GetUserById(string id);
        Task<List<UserDTO>> GetUsersByName(string name);
        Task CreateUser(UserDTO userDto);
        Task ChangePassword(UserDTO userDto, string currentPassword, string newPassword);
        Task ChangeRegistration(UserDTO userDto);
        Task UpdateUserAccount(UserDTO userDto);
        Task DeleteUser(string id);
    }
}
