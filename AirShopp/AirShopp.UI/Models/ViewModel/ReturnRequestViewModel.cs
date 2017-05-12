using AirShopp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirShopp.UI.Models.ViewModel
{
    public class ReturnRequestViewModel
    {
        public ReturnRequestDataModel ReturnOrder { get; set; }
        public Order Ordrer { get; set; }
        public OrderItem OrderItem{ get; set; }
        public Customer Customer { get; set; }
    }
}