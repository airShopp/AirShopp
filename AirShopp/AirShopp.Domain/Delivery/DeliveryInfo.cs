using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Domain
{
    public class DeliveryInfo
    {
        // 物流信息
        public long Id { get; set; }// PK
        public string Description { get; set; }// DeliveryInfo description
        public string CurrentLocation { get; set; }// Process location
        public DateTime UpdateTime { get; set; }// Process time
        public long OrderId { get; set; }// Foreign key ref Order (Id)

        public virtual Order Order { get; set; }
    }
}
