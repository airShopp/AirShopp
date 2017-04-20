using System;
using System.Collections.Generic;
using AirShopp.UI.Models.ViewModel;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Web.Mvc;
using AirShopp.Domain;
using AirShopp.Common;
using AirShopp.Comman;
using AirShopp.UI.Models;

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

            Address address = _addressService.GetAddress(1).FirstOrDefault();

            // Current area delivery station
            DeliveryStation deliveryStation = _deliveryStationService.GetDeliveryStation(address.AreaId, 2).FirstOrDefault();

            List<OriginPointsViewModel> pointsList = new List<OriginPointsViewModel>();

            OriginPointsViewModel startUpPoint = new OriginPointsViewModel("起点", "江苏昆山物流转运中心", 120.964369, 31.372474, "");
            pointsList.Add(startUpPoint);

            OriginPointsViewModel firstPoint = new OriginPointsViewModel(deliveryStation.ParentDeliveryStation.Name, deliveryStation.ParentDeliveryStation.Address, deliveryStation.ParentDeliveryStation.Longitude, deliveryStation.ParentDeliveryStation.Latitude, "");
            pointsList.Add(firstPoint);

            OriginPointsViewModel secondPoint = new OriginPointsViewModel(deliveryStation.Name, deliveryStation.Address, deliveryStation.Longitude, deliveryStation.Latitude, "");
            pointsList.Add(secondPoint);

            List<DeliveryStation> stationList = new List<DeliveryStation>();
            Dictionary<double, DeliveryStation> distanceMap = new Dictionary<double, DeliveryStation>();
            foreach (var obj in deliveryStation.DeliveryStations)
            {
                distanceMap.Add(MathHelper.GetDistance(obj.Longitude, obj.Latitude, address.Longitude, address.Latitude), obj);
            }

            var tempMap = distanceMap.OrderBy(o => o.Key).ToDictionary(o => o.Key, p => p.Value);

            int index = 1;
            foreach (var o in tempMap.Keys)
            {
                if ((index == tempMap.Keys.Count && tempMap.Keys.Count <= 20) || index == 21)
                {
                    break;
                }
                stationList.Add(tempMap[o]);
                index++;
            }

            String baseURL = "http://api.map.baidu.com/routematrix/v2/driving?";

            String output = "output=json";

            String origins = "&origins=";

            for (var i = 0; i < stationList.Count; i++)
            {
                if (i == 0)
                {
                    origins += stationList[i].Latitude + "," + stationList[i].Longitude;
                }
                else
                {
                    origins += "|" + stationList[i].Latitude + "," + stationList[i].Longitude;
                }
            }

            String destinations = "&destinations=" + address.Latitude + "," + address.Longitude;

            String ak = "&ak=" + Constants.BMAP_AK;

            String str = baseURL + output + origins + destinations + ak;

            BMapDataModel bMapDataModel = JsonHelper.DeserializeJsonToObject<BMapDataModel>(WebAPIHelper.Get(str));

            int minDistanceIndex = bMapDataModel.Result.FindIndex(x => x.Distance.Value == bMapDataModel.Result.Min(y => y.Distance.Value));

            OriginPointsViewModel thirdPoint = new OriginPointsViewModel(stationList[minDistanceIndex].Name, stationList[minDistanceIndex].Address, stationList[minDistanceIndex].Longitude, stationList[minDistanceIndex].Latitude, "");
            pointsList.Add(thirdPoint);

            OriginPointsViewModel endPoint = new OriginPointsViewModel("终点", address.DeliveryAddress, address.Longitude, address.Latitude, "");
            pointsList.Add(endPoint);

            return View(pointsList);
        }

        public ActionResult GetDeliveryInfo(double lng, double lat, int index, double nextLng, double nextLat)
        {
            switch (index)
            {
                case 1:



                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                default:
                    break;
            }
            return Content("");
        }

    }
}