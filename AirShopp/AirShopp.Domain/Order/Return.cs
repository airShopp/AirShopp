using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirShopp.Domain
{
    public class Return
    {
        public Return()
        {

        }

        public long Id { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string ReturnReason { get; set; }
        public string ReturnStatus { get; set; }
        public string CustomerName { get; set; }

        public long OrderId { get; set; }
        public virtual Order Order { get; set; }

        public long OrderItemId { get; set; }
        public virtual OrderItem OrderItem { get; set; }
    }
}
