using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirShopp.UI.Models
{
    public class ProductInDataModel
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductUrl { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public DateTime ProductInDate { get; set; }
        public string warehouseName { get; set; }

    }
}