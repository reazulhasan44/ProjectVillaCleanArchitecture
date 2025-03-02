using ProjectVilla.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVilla.Application.Services.Interface
{
    public interface IVillaNumberService
    {
        IEnumerable<VillaNumber> GetAllVillaNumbers();
        VillaNumber GetVillaNumberById(int id);
        void CreateVillaNumber(VillaNumber villa);
        void UpdateVillaNumber(VillaNumber villa);
        bool DeleteVillaNumber(int id);
        bool CheckVillaNumberExist(int villa_number);
    }
}
