using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Domain
{
    public class Address
    {
        public Address()
        {

        }

        public long Id { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhone { get; set; }
        public string DeliveryAddress { get; set; }
        public bool IsDefault { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public long CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public long AreaId { get; set; }
        public virtual Area Area { get; set; }

        public ICollection<Order> orders { get; set; }
    }
}
