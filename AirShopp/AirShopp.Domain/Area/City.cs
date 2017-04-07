using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Domain
{
    public class City
    {
        public long Id { get; set; }
        public long CityId { get; set; }
        public string CityName { get; set; }
        public long ProvinceId { get; set; }

        //public Province Province { get; set; }
        //public ICollection<Area> Areas { get; set; }
    }
}
