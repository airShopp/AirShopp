using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirShopp.UI.Models
{
    public class InventoryProductListDataModel
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductUrl { get; set; }
        public string CategoryName { get; set; }
        public bool IsOnSale { get; set; }
        public decimal Price { get; set; }
        public string ProviderName { get; set; }
        public decimal Discount { get; set; }
        public string  WarehouseName{ get; set; }
        public string KeepDate { get; set; }
        public DateTime ProductionDate { get; set; }
    }
}