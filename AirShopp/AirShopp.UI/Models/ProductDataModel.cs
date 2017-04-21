using System;

namespace AirShopp.UI.Models
{
    public class ProductDataModel
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public double Discounts { get; set; }
        public int Sales { get; set; }
        public string PictureUrl{ get; set; }
        public DateTime DiscountStartTime{ get; set; }
        public DateTime DiscountEndTime { get; set; }
    }
}