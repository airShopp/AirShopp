using AirShopp.Domain;
using AirShopp.UI.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirShopp.UI.Models.ViewModel
{
    public class ReturnManageListViewModel
    {
        public RequestingListViewModel RequestingListViewModel { get; set; }
        public ReturningListViewModel ReturningListViewModel { get; set; }
        public ReturnFinishedListViewModel ReturnFinishedListViewModel { get; set; }
        public int CurrentTab { get; set; }
        public string searchDeliveryNoteNum { get; set; }
    }
    public class RequestingListViewModel : PageListBaseModel
    {
        public List<Order> RequestingList { get; set; }
        public RequestingListViewModel()
        {
            RequestingList = new List<Order>();
        }
    }
    public class ReturningListViewModel : PageListBaseModel
    {
        public List<Order> ReturningList { get; set; }
        public ReturningListViewModel()
        {
            ReturningList = new List<Order>();
        }
    }
    public class ReturnFinishedListViewModel : PageListBaseModel
    {
        public List<Order> ReturnFinishedList { get; set; }
        public ReturnFinishedListViewModel()
        {
            ReturnFinishedList = new List<Order>();
        }
    }
}