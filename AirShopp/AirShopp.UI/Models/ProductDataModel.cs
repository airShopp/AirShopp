using System;

namespace AirShopp.UI.Models
{
    public class ProductDataModel
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public DateTime TimeLimit { get; set; }
        public decimal Discounts { get; set; }
        public int Sales { get; set; }
        public string PictureUrl{ get; set; }
    }
}