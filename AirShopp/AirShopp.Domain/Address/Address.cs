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
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public string DeliveryAddress { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhone { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer customer { get; set; }
    }
}
