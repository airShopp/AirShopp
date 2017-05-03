using AirShopp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AirShopp.DataAccess
{
    public class CityRepository : ICityRepository
    {
        public AirShoppContext _context = new AirShoppContext();
        public List<City> GetCity()
        {
            return _context.City.ToList();
        }

        public City GetCityById(long cityId)
        {
            return _context.City.Where(x => x.CityId == cityId).ToList().FirstOrDefault();
        }
    }
}
