using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirShopp.Domain
{
    public class Return
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string ReturnReason { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public string CustomerName { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order order { get; set; }
		


    }
}
