﻿using AirShopp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.DataAccess
{
    public class AreaRepository : IAreaRepository
    {
        public AirShoppContext _context = new AirShoppContext();

        public List<Area> GetAreaByProvinceId(long provinceId)
        {
            List<City> cityList = _context.City.Where(y => y.ProvinceId == provinceId).ToList();

            //return _context.Area.Where(x=>x.CityId == );
        }

    }
}
