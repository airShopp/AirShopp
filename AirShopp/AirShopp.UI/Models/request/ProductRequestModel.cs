using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirShopp.UI.Models.request
{
    public class ProductRequestModel
    {
        public string productName { get; set; }
        public long categoryId { get; set; }
        public long provider { get; set; }
        public long warehouse { get; set; }
        public DateTime productionTime { get; set; }
        public string keepTime { get; set; }
        public decimal price { get; set; }
        public int productCount { get; set; }
        public string picture { get; set; }
    }
}