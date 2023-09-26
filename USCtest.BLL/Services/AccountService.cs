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


        public async Task ChangePassword(UserModel userDto, string currentPassword, string newPassword)
        {
            if (userDto != null)
            {
                var user = mapper.Map<ApplicationUser>(userDto);

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
    }
}
