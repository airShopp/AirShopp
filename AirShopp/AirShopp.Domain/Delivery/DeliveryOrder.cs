using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Domain
{
    public class DeliveryOrder
    {
        // 出库单
        public long Id { get; set; }// PK
        public string DeliveryOrderNumber { get; set; }// Serial Number like CK-20160101-0002
        public DateTime DeliveryDate { get; set; }// Delivery Date like 2016-01-01
        public string TotalRMBInChinese { get; set; }// Summary money in chinese
        public string TotalRMBInNumberic { get; set; }// Summary money in numberic
        public long OrderId { get; set; }// Foreign key ref Order (Id)

        public virtual Order Order { get; set; }// Contains receiver related information
        public virtual ICollection<DeliveryOrderItem> DeliveryOrderItems { get; set; }// Items in Delivery order
    }
}
