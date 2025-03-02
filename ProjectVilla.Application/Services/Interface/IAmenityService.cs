using ProjectVilla.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVilla.Application.Services.Interface
{
    public interface IAmenityService
    {
        IEnumerable<Amenity> GetAllAmenities();
        Amenity GetAmenityById(int id);
        void CreateAmenity(Amenity obj);
        void UpdateAmenity(Amenity obj);
        bool DeleteAmenity(int id);
    }
}
