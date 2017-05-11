using AirShopp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirShopp.UI.Models.ViewModel
{
    public class DeliveryOrderDetailViewModel
    {
        public string DeliverOrderNumber { get; set; }
        public string ReciverAndAddress { get; set; }
        public string TimeFormat { get; set; }
        public List<DeliveryOrderItem> deliverOrderItems { get; set; }
        public string TotalAmountInChinese { get; set; }
        public string AuditPerson { get; set; }
        public string MakeTablePerson { get; set; }

    }
}