using AirShopp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirShopp.UI.Models.ViewModel
{
    public class OrderViewModel
    {
        public List<Order> PendingPaymentOrder { get; set; }
        public List<Order> PendingDeliveryOrder { get; set; }
        public List<Order> PendingReceivedOrder { get; set; } 
        public List<Order> FinishedOrder { get; set; }
        public List<Order> AllOrder { get; set; }

    }
}