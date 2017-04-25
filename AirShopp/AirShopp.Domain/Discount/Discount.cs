using System;

namespace AirShopp.Domain
{
    public class Discount
    {
        public Discount()
        {

        }

        public long Id { get; set; }
        public decimal Discounts { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsUsed { get; set;}

        public long ProductId { get; set; }
        public Product Product { get; set; }
    }
}
