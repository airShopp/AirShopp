using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Domain
{
    public class Area
    {
        public long Id { get; set; }
        public long AreaId { get; set; }
        public string AreaName { get; set; }
        public long CityId { get; set; }

        public City City { get; set; }
    }
}
