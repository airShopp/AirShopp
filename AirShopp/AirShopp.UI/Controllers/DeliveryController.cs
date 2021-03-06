﻿using AirShopp.Common;
using AirShopp.Common.Page;
using AirShopp.Domain;
using AirShopp.UI.Models;
using AirShopp.UI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirShopp.UI.Controllers
{
    public class DeliveryController : FliterController
    {
        private IDeliveryOrderRepository _deliveryOrderRepository;
        private IOrderRepository _orderRepository;
        private IDeliveryNoteRepository _deliveryNoteRepository;
        private IDeliveryStationRepository _deliveryStationRepository;
        private ICourierRepository _courierRepository;
        private IProvinceRepository _provinceRepository;
        private ICityRepository _cityRepository;
        private IAreaRepository _areaRepository;
        private IReadFromDb _readFromDb;

        public DeliveryController(
            IDeliveryOrderRepository deliveryOrderRepository,
            IOrderRepository orderRepository,
            IDeliveryNoteRepository deliveryNoteRepository,
            IDeliveryStationRepository deliveryStationRepository,
            ICourierRepository courierRepository,
            IProvinceRepository provinceRepository,
            ICityRepository cityRepository,
            IAreaRepository areaRepository,
        IReadFromDb readFromDb)
        {
            _deliveryOrderRepository = deliveryOrderRepository;
            _orderRepository = orderRepository;
            _deliveryNoteRepository = deliveryNoteRepository;
            _deliveryStationRepository = deliveryStationRepository;
            _courierRepository = courierRepository;
            _provinceRepository = provinceRepository;
            _cityRepository = cityRepository;
            _areaRepository = areaRepository;
            _readFromDb = readFromDb;
        }

        public ActionResult DeliveryOrderList(string num, int? indexNum = 1, int? pageSize = 6)
        {
            if (num == null)
            {
                num = string.Empty;
            }
            var deliveryOrderDataModelList = (from c in _readFromDb.DeliveryOrders
                                              join o in _readFromDb.Orders on c.OrderId equals o.Id
                                              where c.DeliveryOrderNumber.Contains(num)
                                              select new DeliveryOrderDataModel()
                                              {
                                                  Id = c.Id,
                                                  AddressAndReceiver = o.Address.DeliveryAddress + "(" + o.Address.ReceiverName + ")",
                                                  TotalAmount = c.TotalRMBInNumberic,
                                                  DeliveryOrderNumber = c.DeliveryOrderNumber,
                                                  DeliveryDate = c.DeliveryDate.ToString()
                                              }).OrderBy(x => x.DeliveryOrderNumber).ToPagedList(indexNum, pageSize);

            var list = deliveryOrderDataModelList.ToList();
            list.ForEach(x => x.DeliveryDate = (DateTime.Parse(x.DeliveryDate)).ToShortDateString());

            return View(new DeliveryOrderListViewModel()
            {
                DeliveryOrderDataModelList = list,
                PageIndex = deliveryOrderDataModelList.PageIndex,
                TotalCount = deliveryOrderDataModelList.TotalCount,
                TotalPage = deliveryOrderDataModelList.TotalPage,
                pageBar = deliveryOrderDataModelList.getPageBar(),
                searchDeliveryOrderNum = num
            });
        }

        public ActionResult DeliveryOrderDetail(long deliveryOrderId)
        {
            DeliveryOrder deliveryOrder = _deliveryOrderRepository.GetDeliveryOrderByPK(deliveryOrderId);

            if (deliveryOrder == null)
            {
                return Content("<script>alert('出库单无效');location.href='/Delivery/DeliveryOrderList'</script>");
            }

            Order order = _orderRepository.GetOrderByOrderId(deliveryOrder.OrderId);

            DeliveryOrderDetailViewModel deliveryOrderDetail = new DeliveryOrderDetailViewModel();
            deliveryOrderDetail.DeliverOrderNumber = deliveryOrder.DeliveryOrderNumber;
            deliveryOrderDetail.ReciverAndAddress = order.Address.DeliveryAddress + "(" + order.Address.ReceiverName + ")";
            deliveryOrderDetail.TimeFormat = deliveryOrder.DeliveryDate.Year + " 年 " + deliveryOrder.DeliveryDate.Month + " 月 " + deliveryOrder.DeliveryDate.Day + " 日";
            deliveryOrderDetail.deliverOrderItems = deliveryOrder.DeliveryOrderItems.ToList();
            deliveryOrderDetail.TotalAmountInChinese = deliveryOrder.TotalRMBInChinese;
            deliveryOrderDetail.AuditPerson = "仓管员";
            deliveryOrderDetail.MakeTablePerson = "自动生成";

            return View(deliveryOrderDetail);
        }

        public ActionResult DeliveryNoteList(string num, int? indexNum = 1, int? pageSize = 4)
        {
            if (num == null)
            {
                num = string.Empty;
            }

            var deliveryNoteDataModelList = (from c in _readFromDb.DeliveryNotes
                                             join o in _readFromDb.Orders on c.OrderId equals o.Id
                                             where c.DeliveryNoteNumber.Contains(num)
                                             select new DeliveryNoteDataModel()
                                             {
                                                 Id = c.Id,
                                                 ReceiverName = o.Address.ReceiverName,
                                                 ReceiverPhone = o.Address.ReceiverPhone,
                                                 ReceiverAddress = o.Address.DeliveryAddress,
                                                 SenderName = "AirShopp官方商城",
                                                 SenderPhone = "0101-12345678",
                                                 SenderAddress = Constants.START_POINT_ADDRESS,
                                                 DeliveryNoteNumber = c.DeliveryNoteNumber,
                                                 QRCodeImgSrc = c.QRCodeImgURL
                                             }).OrderBy(x => x.DeliveryNoteNumber).ToPagedList(indexNum, pageSize);

            return View(new DeliveryNoteListViewModel()
            {
                DelvieryNoteDataModelList = deliveryNoteDataModelList.ToList(),
                PageIndex = deliveryNoteDataModelList.PageIndex,
                TotalCount = deliveryNoteDataModelList.TotalCount,
                TotalPage = deliveryNoteDataModelList.TotalPage,
                pageBar = deliveryNoteDataModelList.getPageBar(),
                searchDeliveryNoteNum = num
            });
        }

        public ActionResult DeliveryStationList(string provinceName, string cityName, string areaName, string deliveryStationName, int? indexNum = 1, int? pageSize = 10)
        {
            if (provinceName == null)
            {
                provinceName = string.Empty;
            }

            if (cityName == null)
            {
                cityName = string.Empty;
            }

            if (areaName == null)
            {
                areaName = string.Empty;
            }

            if (deliveryStationName == null)
            {
                deliveryStationName = string.Empty;
            }
            var deliveryStationViewModel = (from p in _readFromDb.Provinces
                                            join c in _readFromDb.Cities on p.ProvinceId equals c.ProvinceId
                                            join a in _readFromDb.Areas on c.CityId equals a.CityId
                                            join d in _readFromDb.DeliveryStations on a.Id equals d.AreaId
                                            where p.ProvinceName.Contains(provinceName) && c.CityName.Contains(cityName) &&
                                                a.AreaName.Contains(areaName) && d.Name.Contains(deliveryStationName)
                                            select new DeliveryStationViewModel
                                            {
                                                Location = p.ProvinceName + c.CityName + a.AreaName,
                                                Id = d.Id,
                                                Name = d.Name,
                                                Address = d.Address,
                                                Area = d.Area,
                                                AreaId = d.AreaId,
                                                Couriers = d.Couriers,
                                                DeliveryStations = d.DeliveryStations,
                                                Latitude = d.Latitude,
                                                Longitude = d.Longitude,
                                                ParentDeliveryStation = d.ParentDeliveryStation,
                                                ParentStationId = d.ParentStationId,
                                                StationLevel = d.StationLevel
                                            }).OrderBy(x => x.Id).ToPagedList(indexNum, pageSize);

            List<Province> provinceList = _provinceRepository.GetProvince();
            List<City> CityList = _cityRepository.GetCity();
            List<Area> AreaList = _areaRepository.GetArea();

            return View(new DeliveryStationListViewModel()
            {
                DeliveryStations = deliveryStationViewModel.ToList(),
                Provinces = provinceList,
                Cities = CityList,
                Areas = AreaList,
                pageBar = deliveryStationViewModel.getPageBar(),
                PageIndex = deliveryStationViewModel.PageIndex,
                TotalCount = deliveryStationViewModel.TotalCount,
                TotalPage = deliveryStationViewModel.TotalPage,
                stationSearchCondition = new StationSearchCondition()
                {
                    provinceName = provinceName,
                    cityName = cityName,
                    areaName = areaName,
                    deliveryStationName = deliveryStationName
                }
            });
        }

        public ActionResult AddDeliveryStation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDeliveryStation(string name, string location, string address, double lat, double lng)
        {
            string[] str = location.Split(' ');
            string provinceName = str[0];
            string cityName = str[1];
            string areaName = str[2];

            long areaId = 0;

            if (cityName.Equals(provinceName))
            {
                var areaIdRep = (from p in _readFromDb.Provinces
                                 join c in _readFromDb.Cities on p.ProvinceId equals c.ProvinceId
                                 join a in _readFromDb.Areas on c.CityId equals a.CityId
                                 where p.ProvinceName == provinceName && a.AreaName == areaName && (c.CityName == "市辖区" || c.CityName == "县")
                                 select new
                                 {
                                     a.Id
                                 }).FirstOrDefault();
                areaId = areaIdRep.Id;
            }
            else
            {
                var areaIdRep = (from p in _readFromDb.Provinces
                                 join c in _readFromDb.Cities on p.ProvinceId equals c.ProvinceId
                                 join a in _readFromDb.Areas on c.CityId equals a.CityId
                                 where p.ProvinceName == provinceName && a.AreaName == areaName && c.CityName == cityName
                                 select new
                                 {
                                     a.Id
                                 }).FirstOrDefault();
                areaId = areaIdRep.Id;
            }

            DeliveryStation deliveryStation = new DeliveryStation();
            deliveryStation.Name = name;
            deliveryStation.StationLevel = 3;
            deliveryStation.Address = address;
            deliveryStation.AreaId = areaId;
            deliveryStation.Latitude = lat;
            deliveryStation.Longitude = lng;
            deliveryStation.ParentStationId = _deliveryStationRepository.GetParentDeliveryStation(provinceName + areaName + "分拨中心");

            try
            {
                _deliveryStationRepository.AddDeliveryStation(deliveryStation);
            }
            catch (Exception ex)
            {
                return Content("<script>alert('添加出错，请联系IT');location.href='/Delivery/AddDeliveryStation'</script>");
            }

            return RedirectToAction("DeliveryStationList");
        }
        
        [HttpGet]
        public ActionResult DeliveryStationListDetail(long deliveryStationId)
        {
            DeliveryStation deliveryStation = _deliveryStationRepository.GetDeliveryStation(deliveryStationId);
            if (deliveryStationId == 1)
            {
                deliveryStation.DeliveryStations.Remove(deliveryStation);
            }
            return View(deliveryStation);
        }

        [HttpGet]
        public ActionResult AddCourier(long deliveryStationId)
        {
            Courier courier = new Courier();
            courier.Name = ChineseNameHelper.getRandomName();
            courier.Phone = TelHelper.getRandomTel();
            courier.DeliveryStationId = deliveryStationId;

            _courierRepository.AddCourier(courier);

            return RedirectToAction("DeliveryStationListDetail", new { deliveryStationId = deliveryStationId });
        }

        [HttpGet]
        public ActionResult DeleteCourier(long courierId, long deliveryStationId)
        {
            _courierRepository.DeleteCourier(courierId);
            return RedirectToAction("DeliveryStationListDetail", new { deliveryStationId = deliveryStationId });
        }
    }
}