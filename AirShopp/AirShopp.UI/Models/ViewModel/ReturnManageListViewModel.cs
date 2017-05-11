using AirShopp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirShopp.UI.Models.ViewModel
{
    public class ReturnManageListViewModel
    {
        public ReturnManageListViewModel()
        {
            ReturningList = new List<Order>();
            ReturningList = new List<Order>();
            ReturnFinishedList = new List<Order>();
        }

        public List<Order> RequestingList { get; set; }
        public List<Order> ReturningList { get; set; }
        public List<Order> ReturnFinishedList { get; set; }
    }
}