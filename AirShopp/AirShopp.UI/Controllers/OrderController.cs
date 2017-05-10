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
        private IOrderRepository _orderRepository;
        private IProvinceRepository _provinceRepository;
        private ICityRepository _cityRepository;
        private IAreaRepository _areaRepository;
        private ICartItemRepository _cartItemRepository;

        public OrderController(ICartItemRepository cartItemRepository, IOrderservice orderService, IOrderRepository orderRepository, IReadFromDb readFromDb, IProvinceRepository provinceRepository, ICityRepository cityRepository, IAreaRepository areaRepository)
        {
            _orderService = orderService;
            _orderRepository = orderRepository;
            _readFromDb = readFromDb;
            _provinceRepository = provinceRepository;
            _cityRepository = cityRepository;
            _areaRepository = areaRepository;
            _cartItemRepository = cartItemRepository;
        }

        // GET: Order
        public ActionResult Index()
        {
            Customer customer = Session[Constants.SESSION_USER] as Customer;
            List<Order> orderList = _orderService.LoadOrderList(customer.Id);
            OrderViewModel orderViewModel = new OrderViewModel();
            orderViewModel.AllOrder.AddRange(orderList);
            orderViewModel.PendingPaymentOrder.AddRange(orderList.Where(x => x.OrderStatus == "OBLIGATION").ToList());
            orderViewModel.PendingDeliveryOrder.AddRange(orderList.Where(x => x.OrderStatus == "TRANSFER").ToList());
            orderViewModel.PendingReceivedOrder.AddRange(orderList.Where(x => x.OrderStatus == "DELIVERY").ToList());
            orderViewModel.PendingComment.AddRange(orderList.Where(x => x.OrderStatus == "FINISHED" && x.Comments.Count()==0).ToList());
            return View("OrderList", orderViewModel);
        }
        public ActionResult OrderDetail(long orderId)
        {
            Order order = _readFromDb.Orders.Where(x => x.Id == orderId).FirstOrDefault();
            return View("OrderDetail", order);
        }

        public ActionResult ReturnHistory()
        {
            Customer customer = Session[Constants.SESSION_USER] as Customer;
            return View("ReturnHistory", null);
        }

        public ActionResult ReturnList()
        {
            Customer customer = Session[Constants.SESSION_USER] as Customer;
            List<Return> returnList = _orderRepository.GetReturnList(customer.CustomerName);
            returnList = returnList.Where(x => x.ReturnStatus == Constants.REQUESTING).ToList();

            List<Order> orderList = new List<Order>();
            //ReturnRequestListViewModel returnRequestListViewModel = new ReturnRequestListViewModel();
            foreach (Return returnItem in returnList)
            {
                //ReturnRequestViewModel returnRequestViewModel = new ReturnRequestViewModel();
                orderList.Add(_readFromDb.Orders.Where(x => x.Id == returnItem.OrderId).First());
                //returnRequestViewModel.Ordrer = _readFromDb.Orders.Where(x => x.Id == returnItem.OrderId).First();
                //returnRequestViewModel.OrderItem = _readFromDb.OrderItems.Where(x => x.Id == returnItem.OrderItemId).First();
                //returnRequestViewModel.ReturnOrder = returnItem;
                //returnRequestViewModel.Customer = _readFromDb.Customers.Where(x => x.CustomerName == returnItem.CustomerName).First();
                //returnRequestListViewModel.ReturnRequestViewModelList.Add(returnRequestViewModel);
            }
            OrderViewModel orderViewModel = new OrderViewModel();
            orderViewModel.AllOrder = orderList;
            return View("ReturnList", orderViewModel);
        }

        public ActionResult GetReturnRequest()
        {
            Customer customer = Session[Constants.SESSION_USER] as Customer;
            List<Return> returnList = _orderRepository.GetReturnList(customer.CustomerName);
            returnList = returnList.Where(x => x.ReturnStatus == Constants.REQUESTING).ToList();

            ReturnRequestListViewModel returnRequestListViewModel = new ReturnRequestListViewModel();
            foreach (Return returnItem in returnList)
            {
                ReturnRequestViewModel returnRequestViewModel = new ReturnRequestViewModel();
                returnRequestViewModel.Ordrer = _readFromDb.Orders.Where(x => x.Id == returnItem.OrderId).First();
                returnRequestViewModel.OrderItem = _readFromDb.OrderItems.Where(x => x.Id == returnItem.OrderItemId).First();
                returnRequestViewModel.ReturnOrder = returnItem;
                returnRequestViewModel.Customer = _readFromDb.Customers.Where(x => x.CustomerName == returnItem.CustomerName).First();
                returnRequestListViewModel.ReturnRequestViewModelList.Add(returnRequestViewModel);
            }

            return View("ReturnRequest", returnRequestListViewModel);
        }
        public ActionResult CheckOrder(string cartItemStr, string totalAmount)
        {
            string[] cartItemsIdList = cartItemStr.Split(';');
            OrderConfirmViewModel orderConfirmViewModel = new OrderConfirmViewModel();

            List<OrderItem> orderItems = new List<OrderItem>();
            for (int i = 0; i < cartItemsIdList.Length-1; i++)
            {
                if (!string.IsNullOrEmpty(cartItemsIdList[i]))
                {
                    long cartItemsId = Convert.ToInt64(cartItemsIdList[i]);
                    CartItem cartItem = _readFromDb.CartItems.Where(x => x.Id == cartItemsId).FirstOrDefault();
                    OrderItem orderItem = new OrderItem();
                    orderItem.ProductId = cartItem.ProductId;
                    orderItem.Quantity = cartItem.Quantity;
                    orderItem.UnitPrice = cartItem.PricePerProduct;
                    orderItem.DiscountPrice = cartItem.PricePerProduct;
                    orderItems.Add(orderItem);

                    _cartItemRepository.UpdateCartItem(cartItem.Id);
                }
            }

            long customerId = (Session[Constants.SESSION_USER] as Customer).Id;
            Address address =  _readFromDb.Address.Where(x => x.CustomerId == customerId && x.IsDefault).FirstOrDefault();

            Order order = new Order();
            order.CustomerId = customerId;
            order.TotalAmount = Convert.ToDecimal(totalAmount);
            order.OrderStatus = Constants.OBLIGATION;
            order.OrderDate = DateTime.Now;
            order.DeliveryDate = Convert.ToDateTime("1970-01-01 00:00:00.000");
            order.OrderItems = orderItems;
            order.AddressId = address.Id;
            order.IsSpecialOrder = false;
            order.SpecialType = string.Empty;

            try
            {
                order = _orderService.AddOrder(order);
                order = _readFromDb.Orders.Where(x => x.Id == order.Id).FirstOrDefault();

                decimal actuallyAmount = 0;
                foreach (OrderItem orderItem in order.OrderItems)
                {
                    actuallyAmount += orderItem.Product.Price * orderItem.Quantity;
                }
                orderConfirmViewModel.ActuallyAmount = actuallyAmount;
                orderConfirmViewModel.DisCountAmount = actuallyAmount - order.TotalAmount;
                orderConfirmViewModel.order = order;
                orderConfirmViewModel.ProvinceList = _provinceRepository.GetProvince();
                orderConfirmViewModel.CityList = _cityRepository.GetCity();
                orderConfirmViewModel.AreaList = _areaRepository.GetArea();
            }
            catch (Exception ex)
            {

            }
            return View(orderConfirmViewModel);
        }
        public ActionResult SubmitOrder(long orderId)
        {
            Order order = new Order();
            try
            {
                order =  _readFromDb.Orders.Where(x => x.Id == orderId).First();
                //order.AddressId = addressId;  ,long addressId
                _orderRepository.UpdateOrder(order);
            }
            catch (Exception ex)
            {

            }
            return View("SubmitOrder",order);
        }

        public ActionResult CancelOrder(long orderId)
        {
            try
            {
                _orderRepository.CancelOrder(orderId);
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Index");
        }

        public ActionResult ReturnOrder(long orderId, long orderItemId, string returnReason)
        {
            Return returnOrder = new Return();
            returnOrder.CustomerName = (Session[Constants.SESSION_USER] as Customer).CustomerName;
            returnOrder.DeliveryDate = DateTime.Now;
            returnOrder.OrderId = orderId;
            returnOrder.OrderItemId = orderItemId;
            returnOrder.ReturnReason = returnReason;
            returnOrder.ReturnStatus = Constants.REQUESTING;
            try
            {
                _orderRepository.ReturnOrder(returnOrder);
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("GetReturnRequest");
        }

        public ActionResult ToPayment(long orderId)
        {
            try
            {
                _orderRepository.ToPayment(orderId);
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Index");
        }
    }
}