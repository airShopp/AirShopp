using AirShopp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.DataAccess
{
    public class ProvinceRepository: IProvinceRepository
    {
        public AirShoppContext _context = new AirShoppContext();
        public List<Province> GetProvince()
        {
            return _context.Province.ToList();
        }

        public Province GetProvinceById(long provinceId)
        {
            return _context.Province.Where(x => x.ProvinceId == provinceId).ToList().FirstOrDefault();
        }
    }
}
