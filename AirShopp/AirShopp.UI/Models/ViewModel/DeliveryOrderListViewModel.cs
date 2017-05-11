using AirShopp.UI.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirShopp.UI.Models.ViewModel
{
    public class DeliveryOrderListViewModel : PageListBaseModel
    {
        public List<DeliveryOrderDataModel> DeliveryOrderDataModelList { get; set; }
    }

    public class DeliveryOrderDataModel
    {
        public long Id { get; set; }
        public string DeliveryOrderNumber { get; set; }
        public string AddressAndReceiver { get; set; }
        public string TotalAmount { get; set; }
        public string DeliveryDate { get; set; }
    }
}