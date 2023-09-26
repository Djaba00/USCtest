using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using USCtest.BLL.DTOEntities;
using USCtest.BLL.Interfaces;
using USCtext.DAL.Entities;
using USCtext.DAL.Interfaces;

namespace USCtest.BLLTests.Services
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

        public async Task<UserDTO> GetUserById(string id)
        {
            var user = await db.UserManager.FindByIdAsync(id);

            if (user == null)
            {
                return mapper.Map<UserDTO>(user);
            }
            else
            {
                throw new Exception("Пользователь не найден");
            }
        }

        public async Task<List<UserDTO>> GetUsersByName(string name)
        {
            var users = await db.UserManager.Users.Where(c => c.GetFullName().Contains(name)).ToListAsync();

            if (users == null)
            {
                var usersDto = new List<UserDTO>();

                foreach (var user in users)
                {
                    usersDto.Add(mapper.Map<UserDTO>(user));
                }

                return usersDto;
            }    
            else
            {
                throw new Exception("Пользователи не найдены");
            }
        }

        public async Task CreateUser(UserDTO userDto)
        {
            if (userDto != null)
            {
                var user = mapper.Map<User>(userDto);

                await db.UserManager.CreateAsync(user);
            }
            else
            {
                throw new Exception("Не корректный формат данных пользователя");
            }
        }

        public async Task ChangePassword(UserDTO userDto, string currentPassword, string newPassword)
        {
            if (userDto != null)
            {
                var user = mapper.Map<User>(userDto);

                var currentUser = await db.UserManager.FindByIdAsync(user.Id);

                if (currentUser != null)
                {
                    await db.UserManager.ChangePasswordAsync(currentUser, currentPassword, newPassword);
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

        public async Task ChangeRegistration(UserDTO userDto)
        {
            if (userDto != null)
            {
                var user = mapper.Map<User>(userDto);
                var currentUser = await db.UserManager.FindByIdAsync(user.Id);

                if (currentUser != null)
                {
                    currentUser.Flat = user.Flat;
                    await db.UserManager.UpdateAsync(currentUser);
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

        public async Task UpdateUserAccount(UserDTO userDto)
        {
            if (userDto != null)
            {
                var user = mapper.Map<User>(userDto);
                var currentUser = await db.UserManager.FindByIdAsync(user.Id);

                if (currentUser != null)
                {
                    currentUser.FirstName = user.FirstName;
                    currentUser.LastName = user.LastName;
                    currentUser.MiddleName = user.MiddleName;
                    currentUser.Email = user.Email;
                    currentUser.PassportSeries = user.PassportSeries;
                    currentUser.PassportNumber = user.PassportNumber;
                    currentUser.Flat = currentUser.Flat; 

                    await db.UserManager.UpdateAsync(currentUser);
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
            var currentUser = await db.UserManager.FindByIdAsync(id);

            if (currentUser != null)
            {
                await db.UserManager.DeleteAsync(currentUser);
            }
            else
            {
                throw new Exception("Пользователь не найден");
            }
        }
    }
}
