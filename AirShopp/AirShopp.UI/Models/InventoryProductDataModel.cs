using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirShopp.UI.Models
{
    public class InventoryProductDataModel
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductUrl { get; set; }
        public bool IsOnSale { get; set; }
        public decimal Price { get; set; }
        public decimal Discounts { get; set; }
    }
}