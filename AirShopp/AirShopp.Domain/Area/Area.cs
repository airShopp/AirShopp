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
        public Area()
        {
            Addresses = new List<Address>();
            DeliveryStations = new List<DeliveryStation>();
        }

        public long Id { get; set; }
        public long AreaId { get; set; }
        public string AreaName { get; set; }
        public long CityId { get; set; }

        public ICollection<Address> Addresses { get; set; }
        public ICollection<DeliveryStation> DeliveryStations { get; set; }
    }
}
