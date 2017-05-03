using AirShopp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirShopp.UI.Models.ViewModel
{
    public class OrderConfirmViewModel
    {
        public Order order { get; set; }
        public decimal ActuallyAmount { get; set; }
        public decimal DisCountAmount { get; set; }
    }
}