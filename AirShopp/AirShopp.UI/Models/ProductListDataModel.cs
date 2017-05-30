using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirShopp.UI.Models
{
    public class ProductListDataModel
    {
        public long ProductId { get; set; }
        public long CategoryId { get; set; }
        public long ParentId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public decimal Discounts { get; set; }
        public int CommentAmount { get; set; }
        public string ProductUrl { get; set; }
    }
}