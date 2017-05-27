using AirShopp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirShopp.UI.Models.ViewModel
{
    public class AddressListViewModel
    {
        public string Province { get; set; }
        public string City { get; set; }
        public string Area { get; set; }

        public string Address { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhone { get; set; }
        public bool IsDefault { get; set; }
        public long OrderId { get; set; }
        public long Id { get; set; }

        public List<Address> AddressList { get; set; }
        public List<Province> ProvinceList { get; set; }
        public List<City> CityList { get; set; }
        public List<Area> AreaList { get; set; }

        public AddressListViewModel()
        {
            AddressList = new List<Address>();
            ProvinceList = new List<Province>();
            CityList = new List<City>();
            AreaList = new List<Area>();
        }
    }
}