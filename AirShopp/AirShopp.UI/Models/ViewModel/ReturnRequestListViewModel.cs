using AirShopp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirShopp.UI.Models.ViewModel
{
    public class ReturnRequestListViewModel
    {
        public ReturnRequestListViewModel()
        {
            ReturnRequestViewModelList = new List<ReturnRequestViewModel>();
        }
        public List<ReturnRequestViewModel> ReturnRequestViewModelList { get; set; }
    }
}