using AirShopp.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace AirShopp.UI.Models.ViewModel
{
    public class ProductDetailViewModel
    {

        public long ProductId { get; set; } 
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public List<string> ProductUrl { get; set; }
        public int Sales { get; set; }
        public int CommentAmount { get; set; }
        public int ProductAmount { get; set; }
        public DateTime BuyTime { get; set; } //OrderItem => OrderDate
        public List<CustomerCommentDataModel> comments { get; set; }

    }
}