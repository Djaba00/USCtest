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

        public async Task<List<UserProfileModel>> GetAllUsersAsync()
        {
            var users = await db.UserProfiles.GetAllAsync();

            if (users != null)
            {
                var userModels = new List<UserProfileModel>();

                foreach (var user in users)
                {
                    userModels.Add(mapper.Map<UserProfileModel>(user));
                }

                return userModels;
            }

            return null;
        }

        public async Task<UserProfileModel> GetUserByIdAsync(int id)
        {
            var user = await db.UserProfiles.GetAsync(id);

            if (user != null)
            {
                return mapper.Map<UserProfileModel>(user);
            }
            else
            {
                throw new Exception("Пользователь не найден");
            }
        }

        public async Task<List<UserProfileModel>> GetUsersByNameAsync(string name)
        {
            var allUsers = await db.UserProfiles.GetAllAsync();

            var users = allUsers.Where(c => c.GetFullName().Contains(name));

            if (users != null)
            {
                var usersDto = new List<UserProfileModel>();

                foreach (var user in users)
                {
                    usersDto.Add(mapper.Map<UserProfileModel>(user));
                }

                return usersDto;
            }
            else
            {
                throw new Exception("Пользователи не найдены");
            }
        }

        public async Task CreateUserAsync(UserProfileModel userDto)
        {
            if (userDto != null)
            {
                var user = mapper.Map<UserProfile>(userDto);

                await db.UserProfiles.CreateAsync(user);
            }
            else
            {
                throw new Exception("Не корректный формат данных пользователя");
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            var currentUser = await db.UserProfiles.GetAsync(id);

            if (currentUser != null)
            {
                await db.UserProfiles.DeleteAsync(id);
            }
            else
            {
                throw new Exception("Пользователь не найден");
            }
        }

        public async Task AddNewRegistrtionAsync(RegistrationModel registrationModel)
        {
            if (registrationModel.RegistrationDate != DateTime.MinValue && registrationModel != null)
            {
                var registration = mapper.Map<Registration>(registrationModel);

                await db.Registrations.CreateRegistrationAsync(registration);
            }
            else
            {
                throw new Exception("Некорректный формат времени");
            }
        }

        public async Task UpdateRegistrtionAsync(RegistrationModel registrationModel)
        {
            if (registrationModel.RegistrationDate != DateTime.MinValue && registrationModel != null)
            {
                var registration = mapper.Map<Registration>(registrationModel);

                await db.Registrations.UpdateRegistrtionAsync(registration);
            }
            else
            {
                throw new Exception("Некорректный формат времени");
            }
        }
    }
}
