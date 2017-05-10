using AirShopp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirShopp.UI.Models.ViewModel
{
    public class DeliveryStationListViewModel
    {
        public List<DeliveryStationViewModel> DeliveryStations { get; set; }
        public List<Province> Provinces { get; set; }
        public List<City> Cities { get; set; }
        public List<Area> Areas { get; set; }
    }
    public class DeliveryStationViewModel
    {
        public string Location { get; set; }
        public DeliveryStation DeliverStation { get; set; }
    }
}