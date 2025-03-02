using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectVilla.Application.Services.Interface;
using ProjectVilla.Domain.Entities;
using ProjectVilla.Web.ViewModels;

namespace ProjectVilla.Web.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly IVillaNumberService _villaNumberService;

        private readonly IVillaService _villaService;

        public VillaNumberController(IVillaNumberService villaNumberService, IVillaService villaService)
        {
            _villaNumberService = villaNumberService;
            _villaService = villaService;
        }

        public IActionResult Index()
        {
            var villaNumbers = _villaNumberService.GetAllVillaNumbers();
            return View(villaNumbers);
        }

        public IActionResult Create()
        {
            VillaNumberVM obj = new()
            {
                VillaList = _villaService.GetAllVillas().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
            return View(obj);
        }

        [HttpPost]
        public IActionResult Create(VillaNumberVM obj)
        {
            bool isExist = _villaNumberService.CheckVillaNumberExist(obj.VillaNumber.Villa_Number);
            if (ModelState.IsValid && !isExist)
            {
                _villaNumberService.CreateVillaNumber(obj.VillaNumber);
                TempData["success"] = "The villa number has been created successfully.";
                return RedirectToAction(nameof(Index));
            }
            if (isExist)
            {
                TempData["error"] = "The villa Number already exists.";
            }
            obj.VillaList = _villaService.GetAllVillas().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            return View(obj);
        }

        public IActionResult Update(int villaNumberId)
        {
            var obj = _villaNumberService.GetVillaNumberById(villaNumberId);
            if (obj == null)
            {
                return RedirectToAction("Error", "Home");
            }
            VillaNumberVM objVm = new()
            {
                VillaList = _villaService.GetAllVillas().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                VillaNumber = obj
            };      
            return View(objVm);
        }

        [HttpPost]
        public IActionResult Update(VillaNumberVM villaNumberVM)
        {

            if (ModelState.IsValid)
            {
                _villaNumberService.UpdateVillaNumber(villaNumberVM.VillaNumber);
                TempData["success"] = "The villa Number has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }

            villaNumberVM.VillaList = _villaService.GetAllVillas().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            return View(villaNumberVM);
        }

        public IActionResult Delete(int villaNumberId)
        {
            var obj = _villaNumberService.GetVillaNumberById(villaNumberId);
            if (obj == null)
            {
                return RedirectToAction("Error", "Home");
            }
            VillaNumberVM objVm = new()
            {
                VillaList = _villaService.GetAllVillas().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                VillaNumber = obj
            };
            return View(objVm);
        }

        [HttpPost]
        public IActionResult Delete(VillaNumberVM villaNumberVM)
        {
            VillaNumber? objFromDb = _villaNumberService.GetVillaNumberById(villaNumberVM.VillaNumber.Villa_Number);
            if (objFromDb is not null)
            {
                _villaNumberService.DeleteVillaNumber(objFromDb.Villa_Number);
                TempData["success"] = "The villa number has been deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "The villa number could not be deleted.";
            return View();
        }
    }
}
