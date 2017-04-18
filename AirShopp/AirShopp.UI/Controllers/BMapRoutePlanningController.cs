using System;
using System.Collections.Generic;
using AirShopp.UI.Models.ViewModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirShopp.Domain;

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

            City city = _cityService.GetCity(address.Area.CityId).FirstOrDefault();

            Province province = _provinceService.GetProvince(city.ProvinceId).FirstOrDefault();

            DeliveryStation deliveryStation = _deliveryStationService.GetDeliveryStation(address.AreaId).FirstOrDefault();

            // 1. Click query delivery info button and pass params()
            // 2. 

            List<OriginPointsViewModel> pointsList = new List<OriginPointsViewModel>();

            OriginPointsViewModel startUpPoint = new OriginPointsViewModel(){
                Name = "起点",
                Address = "江苏昆山物流转运中心",
                Longitude = 120.964369,
                Latitude = 31.372474,
                Remark = ""
            };
            pointsList.Add(startUpPoint);


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