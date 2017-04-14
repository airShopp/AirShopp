using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Domain
{
    public class DeliveryOrderItem
    {
        // 出库单项
        public long Id { get; set; }// PK
        public string ProductName { get; set; }// Name
        public string Unit { get; set; }// Unit
        public int OutNumber { get; set; }// Output number 
        public decimal PricePerProduct { get; set; }// Price per product
        public decimal TotalPrice { get; set; }// Total price
        public string Remarks { get; set; }// Something to be comments
        public long DeliveryOrderId { get; set; }// Foreign key ref DeliveryOrder (Id)

        public virtual DeliveryOrder DeliveryOder { get; set; }
    }
}
