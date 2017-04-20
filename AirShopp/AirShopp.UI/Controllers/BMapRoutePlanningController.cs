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
        private IDeliveryInfoService _deliveryInfoService;
        private ICourierService _courierService;

        public BMapRoutePlanningController(IAddressService addressService, IDeliveryStationService deliveryStationService, IDeliveryInfoService deliveryInfoService, ICourierService courierService)
        {
            _addressService = addressService;
            _deliveryStationService = deliveryStationService;
            _deliveryInfoService = deliveryInfoService;
            _courierService = courierService;
        }

        //
        // GET: /BMapRoutePlanning/
        public ActionResult Index()
        {
            int orderId = 1;
            // Pass Order model
            Address address = _addressService.GetAddress(orderId).FirstOrDefault();

            // Current area delivery station
            DeliveryStation deliveryStation = _deliveryStationService.GetDeliveryStations(address.AreaId, 2).FirstOrDefault();

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

            // init originPoint
            OriginPointsViewModel startUpPoint = new OriginPointsViewModel("起点", "江苏昆山物流转运中心", 120.964369, 31.372474, "");

            OriginPointsViewModel firstPoint = new OriginPointsViewModel(deliveryStation.ParentDeliveryStation.Name, deliveryStation.ParentDeliveryStation.Address, deliveryStation.ParentDeliveryStation.Longitude, deliveryStation.ParentDeliveryStation.Latitude, "");

            OriginPointsViewModel secondPoint = new OriginPointsViewModel(deliveryStation.Name, deliveryStation.Address, deliveryStation.Longitude, deliveryStation.Latitude, "");

            OriginPointsViewModel thirdPoint = new OriginPointsViewModel(stationList[minDistanceIndex].Name, stationList[minDistanceIndex].Address, stationList[minDistanceIndex].Longitude, stationList[minDistanceIndex].Latitude, "");

            OriginPointsViewModel endPoint = new OriginPointsViewModel("终点", address.DeliveryAddress, address.Longitude, address.Latitude, "");

            return View(new List<OriginPointsViewModel>(){
                    startUpPoint,
                    firstPoint,
                    secondPoint,
                    thirdPoint,
                    endPoint
            });
        }

        public ActionResult GetDeliveryInfo(string point, int index, string nextPoint)
        {
            int orderId = 1;
            int maxIndex = _deliveryInfoService.GetMaxIndex(orderId);

            OriginPointsViewModel currentLocation = JsonHelper.DeserializeJsonToObject<OriginPointsViewModel>(point);
            OriginPointsViewModel nextLocation = JsonHelper.DeserializeJsonToObject<OriginPointsViewModel>(nextPoint);
            switch (index)
            {
                case 1:
                    {
                        DeliveryInfo startDeliveryInfo = new DeliveryInfo(MessageConstants.DELIVERYINFO_START_MESSAGE, ++maxIndex, orderId);
                        DeliveryInfo packageDeliveryInfo = new DeliveryInfo(string.Format(MessageConstants.DELIVERYINFO_PACKAGE_MESSAGE, currentLocation.Name), ++maxIndex, orderId);
                        DeliveryInfo transferDeliveryInfo = new DeliveryInfo(string.Format(MessageConstants.DELIVERYINFO_TRANSFER_MESSAGE, currentLocation.Name, nextLocation.Name), ++maxIndex, orderId);
                        AddDeliveryInfo(new List<DeliveryInfo>(){
                            startDeliveryInfo,
                            packageDeliveryInfo,
                            transferDeliveryInfo
                        });
                    }
                    break;
                case 4:
                    {
                        DeliveryInfo receiveDeliveryInfo = new DeliveryInfo(string.Format(
                            MessageConstants.DELIVERYINFO__RECEIVE_MESSAGE, currentLocation.Name), ++maxIndex, orderId);

                        DeliveryStation deliveryStation = _deliveryStationService.GetDeliveryStation(currentLocation.Longitude, currentLocation.Latitude);

                        Courier courier = _courierService.GetCourier(deliveryStation.Id);

                        DeliveryInfo deliveryDeliveryInfo = new DeliveryInfo(string.Format(MessageConstants.DELIVERYINFO_DELIVERY_MESSAGE, currentLocation.Name, courier.Name, courier.Phone), ++maxIndex, orderId
                           );

                        AddDeliveryInfo(new List<DeliveryInfo>(){
                            receiveDeliveryInfo,
                            deliveryDeliveryInfo
                        });
                    }
                    break;
                case 5:
                    {
                        DeliveryInfo endDeliveryInfo = new DeliveryInfo(
                                string.Format(MessageConstants.DELIVERYINFO_END_MESSAGE, currentLocation.Name), ++maxIndex, orderId
                                );
                        _deliveryInfoService.AddDeliverInfo(endDeliveryInfo);

                    }
                    break;
                default:
                    {
                        DeliveryInfo receiveDeliveryInfo = new DeliveryInfo(string.Format(
                            MessageConstants.DELIVERYINFO__RECEIVE_MESSAGE, currentLocation.Name), ++maxIndex, orderId);
                        DeliveryInfo transferDeliveryInfo = new DeliveryInfo(string.Format(
                            MessageConstants.DELIVERYINFO_TRANSFER_MESSAGE,
                            currentLocation.Name, nextLocation.Name), ++maxIndex, orderId);
                        AddDeliveryInfo(new List<DeliveryInfo>(){
                            receiveDeliveryInfo,
                            transferDeliveryInfo
                        });
                    }
                    break;
            }


            return Content("");
        }

        private void AddDeliveryInfo(List<DeliveryInfo> deliveryInfoList)
        {
            foreach (var item in deliveryInfoList)
            {
                _deliveryInfoService.AddDeliverInfo(item);
            }
        }

    }
}