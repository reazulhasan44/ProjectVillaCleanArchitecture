using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectVilla.Domain.Entities;

namespace ProjectVilla.Web.ViewModels
{
    public class VillaNumberVM
    {
        public VillaNumber? VillaNumber { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? VillaList { get; set; }
    }
}
