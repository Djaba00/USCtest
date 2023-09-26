using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USCtest.BLL.Models;

namespace USCtest.BLL.Interfaces
{
    public interface IAccountService
    {
        Task ChangePassword(UserModel userDto, string currentPassword, string newPassword);
    }
}
