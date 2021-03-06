﻿using System;
using System.Collections.Generic;
using AirShopp.UI.Models.ViewModel;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Web.Mvc;
using AirShopp.Domain;
using AirShopp.Common;
using AirShopp.UI.Models;

namespace AirShopp.UI.Controllers
{
    public class BMapRoutePlanningController : FliterController
    {
        private IAddressService _addressService;
        private IOrderservice _orderService;
        private IDeliveryStationService _deliveryStationService;
        private IDeliveryInfoService _deliveryInfoService;
        private ICourierService _courierService;

        public BMapRoutePlanningController(IAddressService addressService, IOrderservice orderService, IDeliveryStationService deliveryStationService, IDeliveryInfoService deliveryInfoService, ICourierService courierService)
        {
            _addressService = addressService;
            _orderService = orderService;
            _deliveryStationService = deliveryStationService;
            _deliveryInfoService = deliveryInfoService;
            _courierService = courierService;
        }

        //
        // GET: /BMapRoutePlanning/
        public ActionResult Index(long orderId)
        {
            Order order = _orderService.GetOrderByOrderId(orderId);

            if (order.OrderStatus == OrderStatusEnumType.FINISHED.ToString())
            {
                return Content("<script>alert('订单已派送结束');location.href='/Order/OrderDetail?orderId=" + orderId + "'</script>");
            }

            Address address = _addressService.GetAddress(order.AddressId);

            // Current area second level delivery station
            DeliveryStation deliveryStation = _deliveryStationService.GetDeliveryStations(address.AreaId, 2).FirstOrDefault();

            // Get Third level delivery station to destination in current area
            Dictionary<double, DeliveryStation> distanceMap = new Dictionary<double, DeliveryStation>();

            if (deliveryStation.DeliveryStations.Count == 0)
            {
                return Content("<script>alert('当前地址下无子级派送点');location.href='/Order/OrderDetail?orderId=" + orderId + "'</script>");
            }
            else
            {
                foreach (var obj in deliveryStation.DeliveryStations)
                {
                    double key = MathHelper.GetDistance(obj.Longitude, obj.Latitude, address.Longitude, address.Latitude);
                    if (!distanceMap.ContainsKey(key))
                    {
                        distanceMap.Add(key, obj);
                    }
                }
            }

            // Order by distance
            var tempMap = distanceMap.OrderBy(o => o.Key).ToDictionary(o => o.Key, p => p.Value);

            List<DeliveryStation> stationList = new List<DeliveryStation>();
            int index = 1;
            foreach (var o in tempMap.Keys)
            {
                if ((index == tempMap.Keys.Count && tempMap.Keys.Count <= 15) || index == 16)
                {
                    break;
                }
                stationList.Add(tempMap[o]);
                index++;
            }

            // Request BMap WebAPI and receive Json call back data
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

            BMapDataModel bMapDataModel = JsonHelper.
                DeserializeJsonToObject<BMapDataModel>(WebAPIHelper.Get(Constants.BMAP_DRIVING_BASE_URL + Constants.BMAP_OUTPUT_TYPE + origins + destinations + ak));

            // Get min index of delivery station
            int minDistanceIndex = bMapDataModel.Result.FindIndex(x => x.Distance.Value == bMapDataModel.Result.Min(y => y.Distance.Value));

            // init originPoint
            OriginPointViewModel startUpPoint = new OriginPointViewModel(Constants.START_POINT_NAME, Constants.START_POINT_ADDRESS, Constants.START_POINT_LONGITUDE, Constants.START_POINT_LATITUDE);

            OriginPointViewModel firstPoint = new OriginPointViewModel(deliveryStation.ParentDeliveryStation.Name, deliveryStation.ParentDeliveryStation.Address, deliveryStation.ParentDeliveryStation.Longitude, deliveryStation.ParentDeliveryStation.Latitude);

            OriginPointViewModel secondPoint = new OriginPointViewModel(deliveryStation.Name, deliveryStation.Address, deliveryStation.Longitude, deliveryStation.Latitude);

            OriginPointViewModel thirdPoint = new OriginPointViewModel(stationList[minDistanceIndex].Name, stationList[minDistanceIndex].Address, stationList[minDistanceIndex].Longitude, stationList[minDistanceIndex].Latitude);

            OriginPointViewModel endPoint = new OriginPointViewModel(address.DeliveryAddress, address.DeliveryAddress, address.Longitude, address.Latitude);

            List<DeliveryInfoViewModel> deliveryinfos = new List<DeliveryInfoViewModel>();

            List<DeliveryInfo> initDeliveryInfos = _deliveryInfoService.GetDeliveryInfo(orderId);

            foreach(var item in initDeliveryInfos)
            {
                DeliveryInfoViewModel temp = new DeliveryInfoViewModel(item.Description, item.UpdateTime);
                deliveryinfos.Add(temp);
            }

            BMapViewModel bMapViewModel = new BMapViewModel()
            {
                DeliveryInfos = deliveryinfos,
                OriginPoints = new List<OriginPointViewModel>(){
                    startUpPoint,
                    firstPoint,
                    secondPoint,
                    thirdPoint,
                    endPoint
                },
                Order = order
            };

            return View(bMapViewModel);
        }

        public ActionResult GetDeliveryInfo(string point, int index, string nextPoint, int orderId)
        {
            Order order = _orderService.GetOrderByOrderId(orderId);

            int maxIndex = _deliveryInfoService.GetMaxIndex(orderId);
            int backUpIndex = maxIndex;

            OriginPointViewModel currentLocation = JsonHelper.DeserializeJsonToObject<OriginPointViewModel>(point);
            OriginPointViewModel nextLocation = JsonHelper.DeserializeJsonToObject<OriginPointViewModel>(nextPoint);
            switch (index)
            {
                case 1:
                    {
                        order.OrderStatus = OrderStatusEnumType.DELIVERY.ToString();
                        _orderService.UpdateOrder(order);

                        DeliveryInfo packageDeliveryInfo = new DeliveryInfo(string.Format(MessageConstants.DELIVERYINFO_PACKAGE_MESSAGE, currentLocation.Name), ++maxIndex, orderId);
                        DeliveryInfo transferDeliveryInfo = new DeliveryInfo(string.Format(MessageConstants.DELIVERYINFO_TRANSFER_MESSAGE, currentLocation.Name, nextLocation.Name), ++maxIndex, orderId);
                        AddDeliveryInfo(new List<DeliveryInfo>(){
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

                        order.OrderStatus = OrderStatusEnumType.FINISHED.ToString();
                        _orderService.UpdateOrder(order);
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

            List<DeliveryInfo> deliveryInfoList = _deliveryInfoService.GetDeliveryInfoInRange(orderId, backUpIndex);
            return Json(deliveryInfoList);
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