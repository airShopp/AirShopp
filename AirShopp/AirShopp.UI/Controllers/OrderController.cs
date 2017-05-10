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
        private IDeliveryOrderRepository _deliveryOrderRepository;
        private IDeliveryOrderItemRepository _deliveryOrderItemRepository;
        private IDeliveryNoteRepository _deliveryNoteRepository;

        public OrderController(IOrderservice orderService, IOrderRepository orderRepository, IReadFromDb readFromDb, IProvinceRepository provinceRepository, ICityRepository cityRepository, IAreaRepository areaRepository, IDeliveryOrderRepository deliveryOrderRepository, IDeliveryOrderItemRepository deliverOrderItemRepository, IDeliveryNoteRepository deliveryNoteRepository)
        {
            _orderService = orderService;
            _orderRepository = orderRepository;
            _readFromDb = readFromDb;
            _provinceRepository = provinceRepository;
            _cityRepository = cityRepository;
            _areaRepository = areaRepository;
            _deliveryOrderRepository = deliveryOrderRepository;
            _deliveryOrderItemRepository = deliverOrderItemRepository;
            _deliveryNoteRepository = deliveryNoteRepository;
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
            orderViewModel.PendingComment.AddRange(orderList.Where(x => x.OrderStatus == "FINISHED" && x.Comments.Count() == 0).ToList());
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
            return View("ReturnList", null);
        }

        public ActionResult GetReturnRequest()
        {
            Customer customer = Session[Constants.SESSION_USER] as Customer;
            return View("ReturnRequest", null);
        }
        public ActionResult CheckOrder()
        {
            string cartItemStr = "1;2;3;";
            int totalAmount = 126;
            string[] cartItemsIdList = cartItemStr.Split(';');
            OrderConfirmViewModel orderConfirmViewModel = new OrderConfirmViewModel();

            List<CartItem> CartItems = new List<CartItem>()
            {
                new CartItem() {
                    Id = 1,
                    ProductId = 1,
                    Quantity = 1,
                    PricePerProduct = 22,
                },
                new CartItem() {
                    Id = 2,
                    ProductId = 2,
                    Quantity = 1,
                    PricePerProduct = 42,
                },
                new CartItem() {
                    Id = 3,
                    ProductId = 3,
                    Quantity = 1,
                    PricePerProduct = 62,
                },
            };

            List<OrderItem> orderItems = new List<OrderItem>();
            for (int i = 0; i < cartItemsIdList.Length; i++)
            {
                if (!string.IsNullOrEmpty(cartItemsIdList[i]))
                {
                    //CartItem cartItem = _readFromDb.CartItems.Where(x => x.Id == long.Parse(cartItemsIdList[i])).FirstOrDefault();
                    CartItem cartItem = CartItems.Where(x => x.Id == long.Parse(cartItemsIdList[i])).FirstOrDefault();
                    OrderItem orderItem = new OrderItem();
                    orderItem.ProductId = cartItem.ProductId;
                    orderItem.Quantity = cartItem.Quantity;
                    orderItem.UnitPrice = cartItem.PricePerProduct;
                    orderItem.DiscountPrice = cartItem.PricePerProduct;
                    orderItems.Add(orderItem);
                }
            }

            long customerId = (Session[Constants.SESSION_USER] as Customer).Id;
            Address address = _readFromDb.Address.Where(x => x.CustomerId == customerId && x.IsDefault).FirstOrDefault();

            Order order = new Order();
            order.CustomerId = customerId;
            order.TotalAmount = totalAmount;
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
                order = _readFromDb.Orders.Where(x => x.Id == orderId).First();
                order = _orderRepository.GetOrderByOrderId(orderId);
                //order.AddressId = addressId;  ,long addressId
                _orderRepository.UpdateOrder(order);

                //Generate delivery order
                string beginSerialNumber = "CK-" + DateTime.Now.ToString("yyyyMMdd");
                string maxDeliveryNumberStr = _deliveryOrderRepository.GetMaxDeliveryOrderNumber(beginSerialNumber);

                DeliveryOrder deliveryOrder = new DeliveryOrder();
                deliveryOrder.DeliveryOrderNumber = beginSerialNumber + "-" + maxDeliveryNumberStr;
                deliveryOrder.DeliveryDate = DateTime.Now;
                deliveryOrder.TotalRMBInChinese = MathHelper.ConvertToChinese((Double)order.TotalAmount);
                deliveryOrder.TotalRMBInNumberic = order.TotalAmount.ToString();
                deliveryOrder.OrderId = order.Id;

                long currentDeliveryOrderId = _deliveryOrderRepository.AddDeliveryOrder(deliveryOrder);
                List<OrderItem> orderItems = order.OrderItems.ToList();
                foreach (var item in orderItems)
                {
                    DeliveryOrderItem deliveryOrderItem = new DeliveryOrderItem();
                    deliveryOrderItem.ProductName = item.Product.ProductName;
                    deliveryOrderItem.Unit = "件";
                    deliveryOrderItem.OutNumber = item.Quantity;
                    deliveryOrderItem.PricePerProduct = item.UnitPrice;
                    deliveryOrderItem.TotalPrice = item.Quantity * item.UnitPrice;
                    deliveryOrderItem.DeliveryOrderId = currentDeliveryOrderId;

                    _deliveryOrderItemRepository.AddDeliveryOrderItem(deliveryOrderItem);
                }

                //Generate delivery note
                DeliveryNote deliveryNote = new DeliveryNote();
                deliveryNote.DeliveryNoteNumber = "PS-" + DateTime.Now.ToString("yyyyMMdd") + "-" + maxDeliveryNumberStr;
                //Generate QR Code
                deliveryNote.QRCodeImgURL = QRCodeHelper.GetQRImage(deliveryNote.DeliveryNoteNumber);
                deliveryNote.OrderId = order.Id;

                _deliveryNoteRepository.AddDeliveryNote(deliveryNote);
            }
            catch (Exception ex)
            {


            }
            return View("SubmitOrder", order);
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

    }
}