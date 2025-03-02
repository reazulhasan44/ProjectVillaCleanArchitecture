using Microsoft.AspNetCore.Mvc;
using ProjectVilla.Application.Services.Interface;

namespace ProjectVilla.Web.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly IVillaNumberService _villaNumberService;
        public VillaNumberController(IVillaNumberService villaNumberService)
        {
            _villaNumberService = villaNumberService;
        }
    
        public IActionResult Index()
        {
            var villaNumbers = _villaNumberService.GetAllVillaNumbers();
            return View(villaNumbers);
        }
    }
}
