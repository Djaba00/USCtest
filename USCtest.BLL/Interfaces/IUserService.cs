﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USCtest.BLL.Models;

namespace USCtest.BLL.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> GetUserById(string id);
        Task<List<UserModel>> GetUsersByName(string name);
        Task CreateUser(UserModel userDto);
        Task ChangePassword(UserModel userDto, string currentPassword, string newPassword);
        Task ChangeRegistration(UserModel userDto);
        Task UpdateUserAccount(UserModel userDto);
        Task DeleteUser(string id);
    }
}
