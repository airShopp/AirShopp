using AirShopp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.DataAccess
{
    public class CityRepository : ICityRepository
    {
        public AirShoppContext _context = new AirShoppContext();

        public List<City> GetCity(long cityId)
        {
            return _context.City.Where(x => x.CityId == cityId).ToList();
        }
    }
}
