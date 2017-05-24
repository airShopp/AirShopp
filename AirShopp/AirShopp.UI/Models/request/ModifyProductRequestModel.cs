using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirShopp.UI.Models.request
{
    public class ModifyProductRequestModel
    {
        public long productId { get; set; }
        public string productName { get; set; }  
        public string productUrl { get; set; }
        public decimal price { get; set; }
        public decimal discounts { get; set; }
        public bool isOnSale { get; set; }

    }
}