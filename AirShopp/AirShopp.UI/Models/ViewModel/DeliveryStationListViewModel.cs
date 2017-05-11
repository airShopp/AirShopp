using AirShopp.Domain;
using AirShopp.UI.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirShopp.UI.Models.ViewModel
{
    public class DeliveryStationListViewModel : PageListBaseModel
    {
        public List<DeliveryStationViewModel> DeliveryStations { get; set; }
        public List<Province> Provinces { get; set; }
        public List<City> Cities { get; set; }
        public List<Area> Areas { get; set; }
    }
    public class DeliveryStationViewModel : DeliveryStation
    {
        public string Location { get; set; }
    }
}