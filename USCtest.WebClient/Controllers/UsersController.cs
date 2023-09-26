using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using USCtest.BLL.Interfaces;
using USCtest.WebClient.ViewModels.UserVM;

namespace USCtest.WebClient.Controllers
{
    public class UsersController : Controller
    {
        private IMapper mapper;
        private IUserService userService;

        public UsersController(IMapper mapper, IUserService userService)
        {
            this.mapper = mapper;
            this.userService = userService;
        }

        [Route("Users/Users")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await userService.GetAllUsersAsync();

            var result = new List<UserViewModel>();

            foreach (var user in users)
            {
                result.Add(mapper.Map<UserViewModel>(user));
            }

            return View("Products", result);
        }
    }
}
