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

            OriginPointsViewModel startUpPoint = new OriginPointsViewModel(){
                Name = "起点",
                Address = "江苏昆山物流转运中心",
                Longitude = 120.964369,
                Latitude = 31.372474,
                Remark = ""
            };
            pointsList.Add(startUpPoint);

            OriginPointsViewModel firstPoint = new OriginPointsViewModel()
            {
                Name = deliveryStation.ParentDeliveryStation.Name,
                Address = deliveryStation.ParentDeliveryStation.Address,
                Longitude = deliveryStation.ParentDeliveryStation.Longitude,
                Latitude = deliveryStation.ParentDeliveryStation.Latitude,
                Remark = ""
            };

            OriginPointsViewModel secondPoint = new OriginPointsViewModel()
            {
                Name = deliveryStation.Name,
                Address = deliveryStation.Address,
                Longitude = deliveryStation.Longitude,
                Latitude = deliveryStation.Latitude,
                Remark = ""
            };

            List<double> distanceList = new List<double>();
            foreach (var obj in deliveryStation.DeliveryStations)
            {
                distanceList.Add(MathHelper.GetDistance(obj.Longitude, obj.Latitude, address.Longitude, address.Latitude));
            }

            distanceList.Sort();





            String str = "http://api.map.baidu.com/routematrix/v2/driving?output=json&origins=40.45,116.34|40.54,116.35&destinations=40.34,116.45|40.35,116.46&ak=BZpwjUXFrAlT6g87xFxY4c3Cf82zen93";


            String s = WebAPIHelper.Get(str);


            OriginPointsViewModel endPoint = new OriginPointsViewModel()
            {
                Name = "终点",
                Address = address.DeliveryAddress,
                Longitude = address.Longitude,
                Latitude = address.Latitude,
                Remark = ""
            };










            return View();
        }
	}
}