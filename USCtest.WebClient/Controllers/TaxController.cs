using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using USCtest.BLL.BusinesModels;
using USCtest.BLL.Interfaces;
using USCtest.BLL.Services;
using USCtest.WebClient.ViewModels.FlatVM;

namespace USCtest.WebClient.Controllers
{
    public class TaxController : Controller
    {
        private IMapper mapper;
        private ITaxService taxService;
        private IFlatService flatService;

        public TaxController(IMapper mapper, ITaxService taxService, IFlatService flatService)
        {
            this.mapper = mapper;
            this.taxService = taxService;
            this.flatService = flatService;
        }


        [Route("Tax/AddIndications")]
        [HttpGet]
        public async Task<IActionResult> AddFlatIndications(int flatId, int? userId)
        {
            var falt = await flatService.GetFlatByIdAsync(flatId);

            var flatVm = mapper.Map<CreateIndicationsViewModel>(falt);

            if (userId.HasValue)
            {
                flatVm.UserPrifileId = userId.Value;
            }

            return View("AddIndicationsView", flatVm);
        }

        [Route("Tax/AddIndications")]
        [HttpPost]
        public async Task<IActionResult> AddFlatIndications(CreateIndicationsViewModel faltVm)
        {
            var flatInd = mapper.Map<IndicationsModel>(faltVm.IndicationsViewModel);

            var flat = await flatService.GetFlatByIdAsync(faltVm.FlatId);

            flat.Indications = flatInd;

            await taxService.CreateTaxAsync(flat);

            if (faltVm.UserPrifileId > 0)
            {
                return RedirectToAction("UserProfile", "User", new { id = faltVm.UserPrifileId });
            }
            else
            {
                return RedirectToAction("List", "User");
            }


        }

        [Route("Tax/Pay")]
        [HttpPost]
        public async Task<IActionResult> PayForTaxAsync(int taxId, int? userId)
        {
            await taxService.TaxPaymentAsync(taxId);

            if(userId.HasValue)
            {
                return RedirectToAction("UserProfile", "User", new { id = userId });
            }
            else
            {
                return RedirectToAction("List", "User");
            }
        }
    }
}
