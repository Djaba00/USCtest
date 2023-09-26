using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using USCtest.BLL.Models;
using USCtest.BLL.Interfaces;
using USCtest.DAL.Entities;
using USCtest.DAL.Interfaces;

namespace USCtest.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork db;
        IMapper mapper;

        public UserService(IUnitOfWork db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<UserModel> GetUserById(string id)
        {
            var user = await db.UsersManager.FindByIdAsync(id);

            if (user != null)
            {
                return mapper.Map<UserModel>(user);
            }
            else
            {
                throw new Exception("Пользователь не найден");
            }
        }

        public async Task<List<UserModel>> GetUsersByName(string name)
        {
            var users = await db.UsersManager.Users.Where(c => c.GetFullName().Contains(name)).ToListAsync();

            if (users != null)
            {
                var usersDto = new List<UserModel>();

                foreach (var user in users)
                {
                    usersDto.Add(mapper.Map<UserModel>(user));
                }

                return usersDto;
            }
            else
            {
                throw new Exception("Пользователи не найдены");
            }
        }

        public async Task CreateUser(UserModel userDto)
        {
            if (userDto != null)
            {
                var user = mapper.Map<User>(userDto);

                await db.UsersManager.CreateAsync(user);
            }
            else
            {
                throw new Exception("Не корректный формат данных пользователя");
            }
        }

        public async Task ChangePassword(UserModel userDto, string currentPassword, string newPassword)
        {
            if (userDto != null)
            {
                var user = mapper.Map<User>(userDto);

                var currentUser = await db.UsersManager.FindByIdAsync(user.Id);

                if (currentUser != null)
                {
                    await db.UsersManager.ChangePasswordAsync(currentUser, currentPassword, newPassword);
                }
                else
                {
                    throw new Exception("Пользователь не найден");
                }
            }
            else
            {
                throw new Exception("Не корректный формат данных пользователя");
            }
        }

        public async Task ChangeRegistration(UserModel userDto)
        {
            if (userDto != null)
            {
                var user = mapper.Map<User>(userDto);
                var currentUser = await db.UsersManager.FindByIdAsync(user.Id);

                if (currentUser != null)
                {
                    currentUser.Flat = user.Flat;
                    await db.UsersManager.UpdateAsync(currentUser);
                }
                else
                {
                    throw new Exception("Пользователь не найден");
                }
            }
            else
            {
                throw new Exception("Не корректный формат данных пользователя");
            }
        }

        public async Task UpdateUserAccount(UserModel userDto)
        {
            if (userDto != null)
            {
                var user = mapper.Map<User>(userDto);
                var currentUser = await db.UsersManager.FindByIdAsync(user.Id);

                if (currentUser != null)
                {
                    currentUser.FirstName = user.FirstName;
                    currentUser.LastName = user.LastName;
                    currentUser.MiddleName = user.MiddleName;
                    currentUser.Email = user.Email;
                    currentUser.PassportSeries = user.PassportSeries;
                    currentUser.PassportNumber = user.PassportNumber;
                    currentUser.Flat = currentUser.Flat;

                    await db.UsersManager.UpdateAsync(currentUser);
                }
                else
                {
                    throw new Exception("Пользователь не найден");
                }
            }
            else
            {
                throw new Exception("Не корректный формат данных пользователя");
            }
        }

        public async Task DeleteUser(string id)
        {
            var currentUser = await db.UsersManager.FindByIdAsync(id);

            if (currentUser != null)
            {
                await db.UsersManager.DeleteAsync(currentUser);
            }
            else
            {
                throw new Exception("Пользователь не найден");
            }
        }
    }
}
