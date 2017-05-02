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
            List<City> cityList = new List<City>();
            _context.City.Where(x => x.CityId == cityId).ToList().ForEach(city =>
            {
                cityList.Add(new City()
                {
                    Id = city.Id,
                    CityId = city.CityId,
                    CityName = city.CityName,
                    ProvinceId = city.ProvinceId,
                });
            });
            return cityList;
        }
    }
}
