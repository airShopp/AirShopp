using System;
using System.Collections.Generic;
using AirShopp.UI.Models.ViewModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirShopp.Domain;
using AirShopp.Common;

namespace AirShopp.UI.Controllers
{
    public class BMapRoutePlanningController : Controller
    {
        private IAddressService _addressService;
        private IDeliveryStationService _deliveryStationService;
        private IProvinceService _provinceService;
        private ICityService _cityService;

        public BMapRoutePlanningController(IAddressService addressService, IDeliveryStationService deliveryStationService, IProvinceService provinceService, ICityService citySrvice)
        {
            _addressService = addressService;
            _deliveryStationService = deliveryStationService;
            _provinceService = provinceService;
            _cityService = citySrvice;
        }

        //
        // GET: /BMapRoutePlanning/
        public ActionResult Index()
        {
            // 1. Click query delivery info button and pass params()
            // 2. 

            Address address = _addressService.GetAddress(1).FirstOrDefault();

            // Current area delivery station
            DeliveryStation deliveryStation = _deliveryStationService.GetDeliveryStation(address.AreaId, 2).FirstOrDefault();

            List<OriginPointsViewModel> pointsList = new List<OriginPointsViewModel>();

            OriginPointsViewModel startUpPoint = new OriginPointsViewModel("起点", "江苏昆山物流转运中心", 120.964369, 31.372474, "");
            pointsList.Add(startUpPoint);

            OriginPointsViewModel firstPoint = new OriginPointsViewModel(deliveryStation.ParentDeliveryStation.Name, deliveryStation.ParentDeliveryStation.Address, deliveryStation.ParentDeliveryStation.Longitude, deliveryStation.ParentDeliveryStation.Latitude, "");

            OriginPointsViewModel secondPoint = new OriginPointsViewModel(deliveryStation.Name, deliveryStation.Address, deliveryStation.Longitude, deliveryStation.Latitude, "");

            List<double> distanceList = new List<double>();
            foreach (var obj in deliveryStation.DeliveryStations)
            {
                distanceList.Add(MathHelper.GetDistance(obj.Longitude, obj.Latitude, address.Longitude, address.Latitude));
            }

            distanceList.Sort();

            if (distanceList.Count >= 50)
            {
                var tempList = distanceList.Take(50).ToList();
                distanceList.Clear();
                distanceList = tempList;
            }

            String baseURL = "http://api.map.baidu.com/routematrix/v2/driving?";

            String output = "output=json";

            String origins = "";

            String destinations = "";

            String ak = "";

            String str = baseURL + output + origins + destinations + ak;

            String s = WebAPIHelper.Get(str);

            OriginPointsViewModel endPoint = new OriginPointsViewModel("终点", address.DeliveryAddress, address.Longitude, address.Latitude, "");

            return View();
        }
    }
}