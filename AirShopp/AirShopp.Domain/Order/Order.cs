using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirShopp.Domain
{
    public class Order
    {
        public Order()
        {
            Returns = new List<Return>();
            DeliveryInfos = new List<DeliveryInfo>();
            Comments = new List<Comment>();
            OrderItems = new List<OrderItem>();
        }

        public long Id { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; } //OBLIGATION TRANSFER DELIVERY FINISHED
        public DateTime DeliveryDate { get; set; }
        public bool IsSpecialOrder { get; set; }
        public string SpecialType { get; set; }

        public long CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public long AddressId { get; set; }
        public virtual Address Address { get; set; }

        public virtual ICollection<Return> Returns { get; set; }
        public virtual DeliveryOrder DeliveryOrder { get; set; }
        public virtual DeliveryNote DeliveryNote { get; set; }
        public virtual ICollection<DeliveryInfo> DeliveryInfos { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
