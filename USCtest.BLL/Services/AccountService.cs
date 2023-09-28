using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USCtest.BLL.Interfaces;
using USCtest.BLL.Models;
using USCtest.DAL.Entities;
using USCtest.DAL.Interfaces;

namespace USCtest.BLL.Services
{
    public class AccountService : IAccountService
    {
        IUnitOfWork db;
        IMapper mapper;

        public AccountService(IUnitOfWork db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        // правки
        public async Task ChangeRegistrationAsync(UserProfileModel userModel)
        {
            if (userModel != null)
            {
                var user = mapper.Map<UserProfile>(userModel);
                var currentUser = await db.UserProfiles.GetAsync(user.Id);

                if (currentUser != null)
                {
                    currentUser.Flats = user.Flats;
                    await db.UserProfiles.UpdateAsync(currentUser);
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

        public async Task UpdateUserProfileAsync(UserProfileModel userModel)
        {
            if (userModel != null)
            {
                var user = mapper.Map<UserProfile>(userModel);

                var currentUser = await db.UserProfiles.GetAsync(user.Id);

                if (currentUser != null)
                {
                    currentUser.FirstName = user.FirstName;
                    currentUser.LastName = user.LastName;
                    currentUser.MiddleName = user.MiddleName;

                    currentUser.PassportSeries = user.PassportSeries;
                    currentUser.PassportNumber = user.PassportNumber;

                    currentUser.Flats = user.Flats;

                    await db.UserProfiles.UpdateAsync(currentUser);
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

        public async Task ChangePassword(UserProfileModel userDto, string currentPassword, string newPassword)
        {
            if (userDto != null)
            {
                var user = mapper.Map<ApplicationUser>(userDto);

                var currentUser = await db.Accounts.FindByIdAsync(user.Id);

                if (currentUser != null)
                {
                    await db.Accounts.ChangePasswordAsync(currentUser, currentPassword, newPassword);
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
    }
}
