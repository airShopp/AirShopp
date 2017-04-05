using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Domain
{
    public class Province
    {
        public long Id { get; set; }
        public long ProvinceId { get; set; }
        public string ProvinceName { get; set; }

        public ICollection<City> Citys { get; set; }
    }
}
