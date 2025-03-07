﻿using ProjectVilla.Application.Common.Interfaces;
using ProjectVilla.Domain.Entities;
using ProjectVilla.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVilla.Infrastructure.Repository
{
    public class VillaRepository: Repository<Villa> ,IVillaRepository
    {
        private readonly ApplicationDbContext _db;
        public VillaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Villa entity)
        {
            _db.Villas.Update(entity);
        }
    }
}
