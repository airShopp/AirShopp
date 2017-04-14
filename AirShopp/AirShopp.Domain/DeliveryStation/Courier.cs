using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Domain
{
    public class Courier
    {
        public long Id { get; set; }// PK
        public string Name { get; set; }// Name
        public string Phone { get; set; }// Phone
        public long DeliveryStationId { get; set; } //Foreign key ref DeliveryStation (Id)

        public virtual DeliveryStation DeliveryStation { get; set; }
    }
}
