using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Domain
{
    public class DeliveryStation
    {
        public long Id { get; set; }// PK
        public string Name { get; set; }// Name
        public string Address { get; set; } // Address
        public double Latitude { get; set; } // Lat like 31.135641
        public double Longitude { get; set; }// Lng like 121.605321
        public int StationLevel { get; set; }// Station level like 1\2\3
        public long ParentStationId { get; set; } // Foreign key ref DeliveryStation (Id)

        public ICollection<Courier> Couriers { get; set; }

        public DeliveryStation ParentDeliveryStation { get; set; }
        public ICollection<DeliveryStation> DeliveryStations { get; set; }
    }
}
