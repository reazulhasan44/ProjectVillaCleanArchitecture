using ProjectVilla.Application.Common.Interfaces;
using ProjectVilla.Application.Services.Interface;
using ProjectVilla.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Internal;

namespace ProjectVilla.Application.Services.Implementation
{
    public class AmenityService : IAmenityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostingEnvironment _webHostEnvironment;
        public AmenityService(IUnitOfWork unitOfWork, IHostingEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public void CreateAmenity(Amenity amenity)
        {
            _unitOfWork.Amenity.Add(amenity);
            _unitOfWork.Save();
        }

        public bool DeleteAmenity(int id)
        {
            try
            {
                Amenity? objFromDb = _unitOfWork.Amenity.Get(u => u.Id == id);
                if (objFromDb is not null)
                {
                    _unitOfWork.Amenity.Remove(objFromDb);
                    _unitOfWork.Save();
                }
                return true;

            }
            catch (Exception)
            {

                return false;
            }

        }

        public IEnumerable<Amenity> GetAllAmenities()
        {
            return _unitOfWork.Amenity.GetAll(includeProperties: "Villa");
        }


        public Amenity GetAmenityById(int id)
        {
            return _unitOfWork.Amenity.Get(u => u.Id == id, includeProperties: "Villa");
        }

        public void UpdateAmenity(Amenity amenity)
        {
            _unitOfWork.Amenity.Update(amenity);
            _unitOfWork.Save();
        }
    }
}
