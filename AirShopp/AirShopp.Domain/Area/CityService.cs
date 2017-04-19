using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Domain
{
    public class CityService : ICityService
    {
        public ICityRepository _cityRepository;
        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        /*
        public List<City> GetCity(long cityId)
        {
            return _cityRepository.GetCity(cityId);
        }
         * */
    }
}
