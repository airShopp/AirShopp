using AirShopp.Domain;
using AirShopp.UI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirShopp.UI.Controllers
{
    public class OrderController : Controller
    {
        private IOrderservice _orderService;

        public OrderController(IOrderservice orderService)
        {
            _orderService = orderService;
        }

        // GET: Order
        public ActionResult Index(long customerId)
        {
            List<Order> orderList = _orderService.LoadOrderList(customerId);
            OrderViewModel orderViewModel = new OrderViewModel();
            orderViewModel.AllOrder.AddRange(orderList);
            orderViewModel.PendingPaymentOrder.AddRange(orderList.Where(x => x.OrderStatus == "OBLIGATION").ToList());
            orderViewModel.PendingDeliveryOrder.AddRange(orderList.Where(x => x.OrderStatus == "OBLIGATION").ToList());
            orderViewModel.PendingReceivedOrder.AddRange(orderList.Where(x => x.OrderStatus == "OBLIGATION").ToList());
            orderViewModel.FinishedOrder.AddRange(orderList.Where(x => x.OrderStatus == "OBLIGATION").ToList());
            return View("OrderList", orderViewModel);
        }
        public ActionResult OrderDetail()
        {
            return View("OrderDetail", null);
        }

        public ActionResult ReturnHistory(long customerId)
        {
            return View("ReturnHistory", null);
        }

        public ActionResult ReturnList(long customerId)
        {
            return View("ReturnList", null);
        }

        public ActionResult GetReturnRequest(long customerId)
        {
            return View("ReturnRequest", null);
        }
        public ActionResult CheckOrder()
        {
            return View();
        }
        public ActionResult SubmitOrder()
        {
            return View();
        }
    }
}