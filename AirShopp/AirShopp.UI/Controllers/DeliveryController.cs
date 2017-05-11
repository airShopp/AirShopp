using AirShopp.Common;
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
    public class DeliveryController : Controller
    {
        private IDeliveryOrderRepository _deliveryOrderRepository;
        private IOrderRepository _orderRepository;
        private IDeliveryNoteRepository _deliveryNoteRepository;
        private IDeliveryStationRepository _deliveryStationRepository;
        private IProvinceRepository _provinceRepository;
        private ICityRepository _cityRepository;
        private IAreaRepository _areaRepository;
        private IReadFromDb _readFromDb;

        public DeliveryController(
            IDeliveryOrderRepository deliveryOrderRepository,
            IOrderRepository orderRepository,
            IDeliveryNoteRepository deliveryNoteRepository,
            IDeliveryStationRepository deliveryStationRepository,
            IProvinceRepository provinceRepository,
            ICityRepository cityRepository,
            IAreaRepository areaRepository,
        IReadFromDb readFromDb)
        {
            _deliveryOrderRepository = deliveryOrderRepository;
            _orderRepository = orderRepository;
            _deliveryNoteRepository = deliveryNoteRepository;
            _deliveryStationRepository = deliveryStationRepository;
            _provinceRepository = provinceRepository;
            _cityRepository = cityRepository;
            _areaRepository = areaRepository;
            _readFromDb = readFromDb;
        }

        // GET: Delivery
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DeliveryOrderList()
        {
            List<DeliveryOrder> deliveryOrderList = _deliveryOrderRepository.GetDeliveryOrders();
            List<DeliveryOrderListViewModel> deliveryOrderViewModelList = new List<DeliveryOrderListViewModel>();
            foreach (var item in deliveryOrderList)
            {
                DeliveryOrderListViewModel temp = new DeliveryOrderListViewModel();
                temp.DeliveryOrderNumber = item.DeliveryOrderNumber;
                Order order = _orderRepository.GetOrderByOrderId(item.OrderId);
                temp.AddressAndReceiver = order.Address.DeliveryAddress + "(" + order.Address.ReceiverName + ")";
                temp.TotalAmount = item.TotalRMBInNumberic;
                temp.DeliveryDate = item.DeliveryDate.ToShortDateString();
                temp.Id = item.Id;
                deliveryOrderViewModelList.Add(temp);
            }
            return View(deliveryOrderViewModelList);
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

        public ActionResult DeliveryNoteList()
        {
            List<DeliveryNote> deliveryNoteList = _deliveryNoteRepository.GetDeliveryNotes();
            List<DeliveryNoteListViewModel> deliveryNoteListViewModel = new List<DeliveryNoteListViewModel>();
            foreach (var item in deliveryNoteList)
            {
                DeliveryNoteListViewModel temp = new DeliveryNoteListViewModel();
                Order order = _orderRepository.GetOrderByOrderId(item.OrderId);
                temp.Id = item.Id;
                temp.ReceiverName = order.Address.ReceiverName;
                temp.ReceiverPhone = order.Address.ReceiverPhone;
                temp.ReceiverAddress = order.Address.DeliveryAddress;
                temp.SenderName = "AirShopp官方商城";
                temp.SenderPhone = "0101-12345678";
                temp.SenderAddress = Constants.START_POINT_ADDRESS;
                temp.DeliveryNoteNumber = item.DeliveryNoteNumber;
                temp.QRCodeImgSrc = item.QRCodeImgURL;
                deliveryNoteListViewModel.Add(temp);
            }
            return View(deliveryNoteListViewModel);
        }

        public ActionResult DeliveryStationList()
        {
            //List<DeliveryStation> deliveryStationList = _deliveryStationRepository.GetInitDeliveryStations();

            var deliveryStationViewModel = (from p in _readFromDb.Provinces
                                                join c in _readFromDb.Cities on p.ProvinceId equals c.ProvinceId
                                                join a in _readFromDb.Areas on c.CityId equals a.CityId
                                                join d in _readFromDb.DeliveryStations on a.Id equals d.AreaId
                                                select new
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
                                                }).ToList();

            List<Province> provinceList = _provinceRepository.GetProvince();
            List<City> CityList = _cityRepository.GetCity();
            List<Area> AreaList = _areaRepository.GetArea();



            DeliveryStationListViewModel deliveryStationListViewModel = new DeliveryStationListViewModel()
            {
                DeliveryStations = deliveryStationViewModel.ConvertAll<DeliveryStationViewModel>(item => new DeliveryStationViewModel()
                {
                    DeliverStation = new DeliveryStation()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Address = item.Address,
                        Area = item.Area,
                        AreaId = item.AreaId,
                        Couriers = item.Couriers,
                        DeliveryStations = item.DeliveryStations,
                        Latitude = item.Latitude,
                        Longitude = item.Longitude,
                        ParentDeliveryStation = item.ParentDeliveryStation,
                        ParentStationId = item.ParentStationId,
                        StationLevel = item.StationLevel
                    },
                    Location = item.Location
                }),
                Provinces = provinceList,
                Cities = CityList,
                Areas = AreaList
            };

            return View(deliveryStationListViewModel);
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

            return View("DeliveryStationList");
        }
    }
}