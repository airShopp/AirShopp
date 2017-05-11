using System;

namespace AirShopp.UI.Models
{
    public class ProductOutDataModel
    {
        public long ProductId { get; set; }
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public string PictureUrl { get; set; }
        public decimal SalePrice { get; set; }
        public int SaleCount { get; set; }
        public DateTime OutDate { get; set; }
        public int ProductCount { get; set; }
    }
}