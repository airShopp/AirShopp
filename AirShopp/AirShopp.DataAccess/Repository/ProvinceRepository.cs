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
        public List<Province> GetProvince(long provinceId)
        {
            List<Province> provinceList = new List<Province>();
            _context.Province.Where(x => x.ProvinceId == provinceId).ToList().ForEach( province => {
                provinceList.Add(new Province(){
                    Id = province.Id,
                    ProvinceId = province.ProvinceId,
                    ProvinceName = province.ProvinceName,
                });
            });
            return provinceList;
        }
    }
}
