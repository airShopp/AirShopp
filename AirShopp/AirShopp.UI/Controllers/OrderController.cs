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
    public class OrderController : FliterController
    {
        private IOrderservice _orderService;
        private readonly IReadFromDb _readFromDb;

        public OrderController(IOrderservice orderService,IReadFromDb readFromDb)
        {
            _orderService = orderService;
            _readFromDb = readFromDb;
        }

        // GET: Order
        public ActionResult Index()
        {
            Customer customer = Session[Constants.SESSION_USER] as Customer;
            List<Order> orderList = _orderService.LoadOrderList(customer.Id);
            OrderViewModel orderViewModel = new OrderViewModel();
            orderViewModel.AllOrder.AddRange(orderList);
            orderViewModel.PendingPaymentOrder.AddRange(orderList.Where(x => x.OrderStatus == "OBLIGATION").ToList());
            orderViewModel.PendingDeliveryOrder.AddRange(orderList.Where(x => x.OrderStatus == "OBLIGATION").ToList());
            orderViewModel.PendingReceivedOrder.AddRange(orderList.Where(x => x.OrderStatus == "OBLIGATION").ToList());
            orderViewModel.FinishedOrder.AddRange(orderList.Where(x => x.OrderStatus == "OBLIGATION").ToList());
            return View("OrderList", orderViewModel);
        }
        public ActionResult OrderDetail(long orderId)
        {
            Order order = _readFromDb.Orders.Where(x => x.Id == orderId).FirstOrDefault();
            return View("OrderDetail", order);
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
            //string cartItemStr = "1;2;3;";
            //string[] cartItemsIdList = cartItemStr.Split(';');
            //List<OrderItem> orderItems = new List<OrderItem>();
            //for (int i = 0; i < cartItemsIdList.Length; i++)
            //{
            //    if (!string.IsNullOrEmpty(cartItemsIdList[i]))
            //    {
            //        CartItem cartItem = _readFromDb.CartItems.Where(x => x.Id == long.Parse(cartItemsIdList[i])).FirstOrDefault();
            //        OrderItem orderItem = new OrderItem();
            //        orderItem.ProductId = cartItem.ProductId;
            //        orderItem.Quantity = cartItem.Quantity;
            //        orderItem.UnitPrice = cartItem.PricePerProduct;
            //        orderItems.Add(orderItem);
            //    }
            //}


            return View();
        }
        public ActionResult SubmitOrder()
        {
            return View();
        }
    }
}