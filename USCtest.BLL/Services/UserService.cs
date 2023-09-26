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
using System.Security.Claims;

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

        public async Task<List<UserModel>> GetAllUsersAsync()
        {
            var users = await db.UsersManager.Users.ToListAsync();

            if (users != null)
            {
                var userModels = new List<UserModel>();

                foreach (var user in users)
                {
                    userModels.Add(mapper.Map<UserModel>(user));
                }

                return userModels;
            }

            return null;
        }

        public async Task<UserModel> GetUserByIdAsync(string id)
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

        public async Task<List<UserModel>> GetUsersByNameAsync(string name)
        {
            var users = await db.UsersManager.Users.Where(c => c.UserProfile.GetFullName().Contains(name)).ToListAsync();

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

        public async Task CreateUserAsync(UserModel userDto)
        {
            if (userDto != null)
            {
                var user = mapper.Map<ApplicationUser>(userDto);

                await db.UsersManager.CreateAsync(user);
            }
            else
            {
                throw new Exception("Не корректный формат данных пользователя");
            }
        }

        public async Task ChangeRegistrationAsync(UserModel userDto)
        {
            if (userDto != null)
            {
                var user = mapper.Map<ApplicationUser>(userDto);
                var currentUser = await db.UsersManager.FindByIdAsync(user.Id);

                if (currentUser != null)
                {
                    currentUser.UserProfile.Flats = user.UserProfile.Flats;
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

        public async Task UpdateUserAccountAsync(UserModel userModel)
        {
            if (userModel != null)
            {
                var user = mapper.Map<ApplicationUser>(userModel);
                var currentUser = await db.UsersManager.FindByIdAsync(user.Id);

                if (currentUser != null)
                {
                    currentUser.Email = user.Email;
                    currentUser.UserName = user.UserName;

                    currentUser.UserProfile.FirstName = user.UserProfile.FirstName;
                    currentUser.UserProfile.LastName = user.UserProfile.LastName;
                    currentUser.UserProfile.MiddleName = user.UserProfile.MiddleName;
                    
                    currentUser.UserProfile.PassportSeries = user.UserProfile.PassportSeries;
                    currentUser.UserProfile.PassportNumber = user.UserProfile.PassportNumber;

                    currentUser.UserProfile.Flats = user.UserProfile.Flats;

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

        public async Task DeleteUserAsync(string id)
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
