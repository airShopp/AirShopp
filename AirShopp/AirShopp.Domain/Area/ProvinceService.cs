using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Domain
{
    public class ProvinceService : IProvinceService
    {
        public IProvinceRepository _provinceRepository;
        public ProvinceService(IProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository;
        }
        
        public List<Province> GetProvince(long provinceId)
        {
            return _provinceRepository.GetProvince(provinceId);
        }
         
    }
}
