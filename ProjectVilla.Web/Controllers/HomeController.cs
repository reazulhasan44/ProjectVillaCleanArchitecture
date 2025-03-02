using Microsoft.AspNetCore.Mvc;
using ProjectVilla.Application.Services.Interface;
using ProjectVilla.Web.Models;
using ProjectVilla.Web.ViewModels;
using System.Diagnostics;

namespace ProjectVilla.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IVillaService _villaService;

        public HomeController(ILogger<HomeController> logger, IVillaService villaService)
        {
            _logger = logger;
            _villaService = villaService;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new()
            {
                VillaList = _villaService.GetAllVillas(),
                Nights = 1,
                CheckInDate = DateOnly.FromDateTime(DateTime.Now),
            };
            return View(homeVM);
        }

        [HttpPost]
        public IActionResult GetVillasByDate(int nights, DateOnly checkInDate)
        {

            HomeVM homeVM = new()
            {
                CheckInDate = checkInDate,
                VillaList = _villaService.GetVillasAvailabilityByDate(nights, checkInDate),
                Nights = nights
            };

            return PartialView("_VillaList", homeVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
