using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USCtest.BLL.Interfaces;
using USCtest.BLL.Models;
using USCtest.BLL.Services;
using USCtest.WebClient.Database.Generators;
using USCtest.WebClient.ViewModels.RegistrationVM;
using USCtest.WebClient.ViewModels.UserVM;

namespace USCtest.WebClient.Controllers
{
    public class UserController : Controller
    {
        private IMapper mapper;
        private IUserService userService;
        private IFlatService flatService;

        public UserController(IMapper mapper, IUserService userService, IFlatService flatService)
        {
            this.mapper = mapper;
            this.userService = userService;
            this.flatService = flatService;
        }

        [Route("User/List")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await userService.GetAllUsersAsync();

            var result = new List<UserViewModel>();

            foreach (var user in users)
            {
                result.Add(mapper.Map<UserViewModel>(user));
            }

            return View("Users", result);
        }

        [Route("User/UserProfile/{id:int}")]
        [HttpGet]
        public async Task<IActionResult> GetUserProfileAsync(int id)
        {
            var user = await userService.GetUserByIdAsync(id);

            var userVm = mapper.Map<UserViewModel>(user);

            return View("UserProfile", userVm);
        }

        [Route("User/Add")]
        [HttpGet]
        public async Task<IActionResult> AddUserAsync()
        {
            return View("AddUser");
        }

        [Route("User/Add")]
        [HttpPost]
        public async Task<IActionResult> AddUserAsync(CreateUserViewModel newUser)
        {
            var user = mapper.Map<UserProfileModel>(newUser);

            if (newUser.Flats != null)
            {
                var flats = new List<FlatModel>();

                foreach (var flat in newUser.Flats)
                {
                    var currentFlat = await flatService.GetFlatByAddressAsync(flat);

                    if (currentFlat != null)
                    {
                        //user.Flats.Add(currentFlat);
                    }
                }
            }

            await userService.CreateUserAsync(user);

            return RedirectToAction("Users");
        }

        [Route("User/Remove")]
        [HttpPost]
        public async Task<IActionResult> RemoveUserAsync(int id)
        {
            await userService.DeleteUserAsync(id);

            return RedirectToAction("Users");
        }

        [Route("User/Deregistration")]
        [HttpPost]
        public async Task<IActionResult> DerigistrtionAsync(RegistrationViewModel registrationViewModel)
        {
            if (registrationViewModel != null)
            {
                var reg = mapper.Map<RegistrationModel>(registrationViewModel);

                reg.RemoveDate = DateTime.Now;

                await userService.UpdateRegistrtionAsync(reg);

                return RedirectToAction("UserProfile", new { id = reg.UserId });
            }
            else
            {
                return RedirectToAction("Users");
            }
        }


        [Route("User/Generate")]
        [HttpGet]
        public async Task<IActionResult> GenerateUsers()
        {
            var userGen = new UsersGenerator();
            var userList = userGen.Generate(10);

            foreach (var user in userList)
            {
                await userService.CreateUserAsync(user);
            }

            return RedirectToAction("List");
        }

        [Route("User/GenerateRegistrations")]
        [HttpGet]
        public async Task<IActionResult> GenerateRegistrations()
        {
            
            //var flats = await flatService.GetAllFlatsAsync();

            //var users = await userService.GetAllUsersAsync();

            //foreach (var flat in flats)
            //{
            //    flat.Generate(users);

            //    foreach (var reg in flat.Registrations)
            //    {
            //        await userService.AddNewRegistrtionAsync(reg);
            //    }
            //}

            return RedirectToAction("List");
        }
    }
}
