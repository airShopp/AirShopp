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

        public List<Province> ProvinceList { get; set; }
        public List<City> CityList { get; set; }
        public List<Area> AreaList { get; set; }
        public string AreaId { get; set; }
        public string Address { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhone { get; set; }
        public bool IsDefault { get; set; }
        public long OrderId { get; set; }
        public OrderConfirmViewModel()
        {
            ProvinceList = new List<Province>();
            CityList = new List<City>();
            AreaList = new List<Area>();
        }
    }
}