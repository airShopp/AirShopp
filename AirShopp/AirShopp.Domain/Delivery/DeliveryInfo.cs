using AirShopp.Common;
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
        public int Index { get; set; }// DeliveryInfo order
        public DateTime UpdateTime { get; set; }// Process time
        public long OrderId { get; set; }// Foreign key ref Order (Id)

        public virtual Order Order { get; set; }

        public DeliveryInfo(string description, int index, long orderId)
        {
            Description = description;
            Index = index;
            UpdateTime = DateTime.Now;
            OrderId = orderId;
        }

        public DeliveryInfo()
        {

        }
    }
}
