using Microsoft.AspNetCore.Mvc;
using ProjectVilla.Application.Services.Interface;

namespace ProjectVilla.Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly IVillaService _villaService;
        public VillaController(IVillaService villaService)
        {
            _villaService = villaService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
