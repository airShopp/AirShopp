using AirShopp.Domain;
using AirShopp.UI.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirShopp.UI.Models.ViewModel
{
    public class ReturnRequestListViewModel : PageListBaseModel
    {
        public ReturnRequestListViewModel()
        {
            ReturnRequestViewModelList = new List<ReturnRequestViewModel>();
        }
        public List<ReturnRequestViewModel> ReturnRequestViewModelList { get; set; }
    }

    public class ReturnRequestDataModel
    {
        public long Id { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string ReturnReason { get; set; }
        public string ReturnStatus { get; set; }
        public string CustomerName { get; set; }
        public long OrderId { get; set; }
        public long OrderItemId { get; set; }
    }
}