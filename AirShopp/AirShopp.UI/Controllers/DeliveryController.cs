using AirShopp.Common;
using AirShopp.Domain;
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
        public DeliveryController(IDeliveryOrderRepository deliveryOrderRepository, IOrderRepository orderRepository, IDeliveryNoteRepository deliveryNoteRepository)
        {
            _deliveryOrderRepository = deliveryOrderRepository;
            _orderRepository = orderRepository;
            _deliveryNoteRepository = deliveryNoteRepository;
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
            return View();
        }

        public ActionResult AddDeliveryStation()
        {
            return View();
        }
    }
}