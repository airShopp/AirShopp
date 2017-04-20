using AirShopp.Domain;
using System;

namespace AirShopp.UI.Models.ViewModel
{
    public class ProductDetailViewModel
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Sales { get; set; }
        public int CommentAmount { get; set; }
        public int ProductAmount { get; set; }
        public DateTime BuyTime { get; set; } //OrderItem => OrderDate


        public Comment Comment { get; set; }
        public Customer Customer { get; set; }

    }
}