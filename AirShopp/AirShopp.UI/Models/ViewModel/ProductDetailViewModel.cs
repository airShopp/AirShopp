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
        [DefaultValue("")]
        public string Description { get; set; }
        [DefaultValue("")]
        public List<string> ProductUrl { get; set; }
        [DefaultValue(0)]
        public int Sales { get; set; }
        [DefaultValue(0)]
        public int CommentAmount { get; set; }
        [DefaultValue(0)]
        public int ProductAmount { get; set; }
        public DateTime BuyTime { get; set; } //OrderItem => OrderDate
        public List<CustomerCommentDataModel> comments { get; set; }

    }
}