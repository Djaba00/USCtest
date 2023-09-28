using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USCtest.BLL.BusinesModels;
using USCtest.BLL.Interfaces;
using USCtest.BLL.Models;
using USCtest.WebClient.Database.Generators;
using USCtest.WebClient.ViewModels.FlatVM;
using USCtest.WebClient.ViewModels.UserVM;

namespace USCtest.WebClient.Controllers
{
    public class FlatController : Controller
    {
        private IMapper mapper;
        private IUserService userService;
        private IFlatService flatService;
        private ITaxService taxService;

        public FlatController(IMapper mapper, IUserService userService, IFlatService flatService, ITaxService taxService)
        {
            this.mapper = mapper;
            this.userService = userService;
            this.flatService = flatService;
            this.taxService = taxService;
        }

        [Route("Flat/List")]
        [HttpGet]
        public async Task<IActionResult> GetAllFlatsAsync()
        {
            var flats = await flatService.GetAllFlatsAsync();

            var result = new List<FlatViewModel>();

            foreach (var flat in flats)
            {
                result.Add(mapper.Map<FlatViewModel>(flat));
            }

            return View("Flats", result);
        }

        [Route("Flat/Add")]
        [HttpGet]
        public async Task<IActionResult> AddFlatAsync()
        {
            return View("AddFlat");
        }

        [Route("Flat/Add")]
        [HttpPost]
        public async Task<IActionResult> AddFlatAsync(CreateFlatViewModel newFlat)
        {
            var flat = mapper.Map<FlatModel>(newFlat);

            if (flat != null)
            {
                await flatService.CreateFlatAsync(flat);
            }

            return RedirectToAction("Flats");
        }

        [Route("Flat/Edit")]
        [HttpGet]
        public async Task<IActionResult> EditFlatAsync(int flatId, int? userId)
        {
            var falt = await flatService.GetFlatByIdAsync(flatId);

            var flatVm = mapper.Map<UpdateFlatViewModel>(falt);

            if (userId.HasValue)
            {
                flatVm.UserId = userId.Value;
            }

            return View("UpdateFlat", flatVm);
        }

        [Route("Flat/Edit")]
        [HttpPost]
        public async Task<IActionResult> EditFlatAsync(UpdateFlatViewModel updateFlat)
        {
            var flat = mapper.Map<FlatModel>(updateFlat);

            if (flat != null)
            {
                await flatService.UpdateFlatAsync(flat);

                return RedirectToAction("UserProfile", "User", new { id = updateFlat.UserId });
            }

            return RedirectToAction("List", "User");
        }

        [Route("Flat/Remove")]
        [HttpPost]
        public async Task<IActionResult> RemoveFlatAsync(int id)
        {
            await flatService.DeleteUserAsync(id);

            return RedirectToAction("Flats");
        }

        [Route("Flat/GenerateFlats")]
        [HttpGet]
        public async Task<IActionResult> GenerateFlats()
        {
            var flatGen = new FlatsGenerator();
            var flatList = flatGen.Generate(10);

            foreach (var flat in flatList)
            {
                await flatService.CreateFlatAsync(flat);
            }

            return RedirectToAction("List");
        }
    }
}
