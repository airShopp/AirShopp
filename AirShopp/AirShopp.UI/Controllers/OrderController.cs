using AirShopp.Common;
using AirShopp.Domain;
using AirShopp.UI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirShopp.Common.Page;

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

        private IDeliveryOrderRepository _deliveryOrderRepository;
        private IDeliveryOrderItemRepository _deliveryOrderItemRepository;
        private IDeliveryNoteRepository _deliveryNoteRepository;

        public OrderController(ICartItemRepository cartItemRepository, IOrderservice orderService, IOrderRepository orderRepository, IReadFromDb readFromDb, IProvinceRepository provinceRepository, ICityRepository cityRepository, IAreaRepository areaRepository, IDeliveryOrderRepository deliveryOrderRepository, IDeliveryOrderItemRepository deliverOrderItemRepository, IDeliveryNoteRepository deliveryNoteRepository)
        {
            _orderService = orderService;
            _orderRepository = orderRepository;
            _readFromDb = readFromDb;
            _provinceRepository = provinceRepository;
            _cityRepository = cityRepository;
            _areaRepository = areaRepository;
            _cartItemRepository = cartItemRepository;
            _deliveryOrderRepository = deliveryOrderRepository;
            _deliveryOrderItemRepository = deliverOrderItemRepository;
            _deliveryNoteRepository = deliveryNoteRepository;
        }

        // GET: Order
        public ActionResult Index(int? currentTab = 1, int? indexNum = 1, int? pageSize = 4)
        {
            Customer customer = Session[Constants.SESSION_USER] as Customer;
            PendingDeliveryStatusViewModel pendingDeliveryStatusViewModel = new PendingDeliveryStatusViewModel();
            PendingPaymentStatusViewModel pendingPaymentStatusViewModel = new PendingPaymentStatusViewModel();
            PendingCommentStatusViewModel pendingCommentStatusViewModel = new PendingCommentStatusViewModel();
            PendingReceivedStatusViewModel pendingReceivedStatusViewModel = new PendingReceivedStatusViewModel();
            AllStatusViewModel allStatusViewModel = new AllStatusViewModel();

            #region getPendingPaymentOrderDataModel
            var pendingPaymentOrderDataModel = (from o in _readFromDb.Orders
                                  where o.CustomerId == customer.Id && o.OrderStatus == Constants.OBLIGATION
                                  select new OrderDataModel()
                                  {
                                      Id = o.Id,
                                      CustomerId = customer.Id,
                                      AddressId = o.AddressId,
                                      CustomerName = customer.CustomerName,
                                      TotalAmount = o.TotalAmount,
                                      OrderDate = o.OrderDate,
                                      OrderStatus = o.OrderStatus,
                                      DeliveryDate = o.DeliveryDate,
                                  }).OrderBy(x => x.DeliveryDate).ToPagedList(indexNum, pageSize);
            var pendingPaymentList = pendingPaymentOrderDataModel.ToList();

            List<Order> PendingPaymentList = new List<Order>();
            foreach (OrderDataModel order in pendingPaymentList)
            {
                PendingPaymentList.Add(_readFromDb.Orders.Where(x => x.Id == order.Id).First());
            }
            pendingPaymentStatusViewModel.pageBar = pendingPaymentOrderDataModel.getPageBar();
            pendingPaymentStatusViewModel.TotalCount = pendingPaymentOrderDataModel.TotalCount;
            pendingPaymentStatusViewModel.TotalPage = pendingPaymentOrderDataModel.TotalPage;
            pendingPaymentStatusViewModel.PageIndex = pendingPaymentOrderDataModel.PageIndex;
            #endregion
            #region getPendingDeliveryOrderDataModel
            var pendingDeliveryOrderDataModel = (from o in _readFromDb.Orders
                                                where o.CustomerId == customer.Id && o.OrderStatus == Constants.TRANSFER
                                                 select new OrderDataModel()
                                                {
                                                    Id = o.Id,
                                                    CustomerId = customer.Id,
                                                    AddressId = o.AddressId,
                                                    CustomerName = customer.CustomerName,
                                                    TotalAmount = o.TotalAmount,
                                                    OrderDate = o.OrderDate,
                                                    OrderStatus = o.OrderStatus,
                                                    DeliveryDate = o.DeliveryDate,
                                                }).OrderBy(x => x.DeliveryDate).ToPagedList(indexNum, pageSize);
            var pendingDeliveryList = pendingDeliveryOrderDataModel.ToList();

            List<Order> PendingDeliveryList = new List<Order>();
            foreach (OrderDataModel order in pendingDeliveryList)
            {
                PendingDeliveryList.Add(_readFromDb.Orders.Where(x => x.Id == order.Id).First());
            }
            pendingDeliveryStatusViewModel.pageBar = pendingDeliveryOrderDataModel.getPageBar();
            pendingDeliveryStatusViewModel.TotalCount = pendingDeliveryOrderDataModel.TotalCount;
            pendingDeliveryStatusViewModel.TotalPage = pendingDeliveryOrderDataModel.TotalPage;
            pendingDeliveryStatusViewModel.PageIndex = pendingDeliveryOrderDataModel.PageIndex;
            #endregion
            #region getPendingReceivedOrderDataModel
            var pendingReceivedOrderDataModel = (from o in _readFromDb.Orders
                                                 where o.CustomerId == customer.Id && o.OrderStatus == Constants.DELIVERY
                                                 select new OrderDataModel()
                                                 {
                                                     Id = o.Id,
                                                     CustomerId = customer.Id,
                                                     AddressId = o.AddressId,
                                                     CustomerName = customer.CustomerName,
                                                     TotalAmount = o.TotalAmount,
                                                     OrderDate = o.OrderDate,
                                                     OrderStatus = o.OrderStatus,
                                                     DeliveryDate = o.DeliveryDate,
                                                 }).OrderBy(x => x.DeliveryDate).ToPagedList(indexNum, pageSize);
            var pendingReceivedList = pendingReceivedOrderDataModel.ToList();

            List<Order> PendingReceivedList = new List<Order>();
            foreach (OrderDataModel order in pendingReceivedList)
            {
                PendingReceivedList.Add(_readFromDb.Orders.Where(x => x.Id == order.Id).First());
            }
            pendingReceivedStatusViewModel.pageBar = pendingReceivedOrderDataModel.getPageBar();
            pendingReceivedStatusViewModel.TotalCount = pendingReceivedOrderDataModel.TotalCount;
            pendingReceivedStatusViewModel.TotalPage = pendingReceivedOrderDataModel.TotalPage;
            pendingReceivedStatusViewModel.PageIndex = pendingReceivedOrderDataModel.PageIndex;
            #endregion
            #region getFinishedOrderDataModel
            var finishedOrderDataModel = (from o in _readFromDb.Orders
                                                 where o.CustomerId == customer.Id && o.OrderStatus == Constants.FINISHED
                                                 select new OrderDataModel()
                                                 {
                                                     Id = o.Id,
                                                     CustomerId = customer.Id,
                                                     AddressId = o.AddressId,
                                                     CustomerName = customer.CustomerName,
                                                     TotalAmount = o.TotalAmount,
                                                     OrderDate = o.OrderDate,
                                                     OrderStatus = o.OrderStatus,
                                                     DeliveryDate = o.DeliveryDate,
                                                 }).OrderBy(x => x.DeliveryDate).ToPagedList(indexNum, pageSize);
            var finishedList = finishedOrderDataModel.ToList();

            List<Order> FinishedList = new List<Order>();
            foreach (OrderDataModel order in finishedList)
            {
                FinishedList.Add(_readFromDb.Orders.Where(x => x.Id == order.Id).First());
            }
            pendingCommentStatusViewModel.pageBar = finishedOrderDataModel.getPageBar();
            pendingCommentStatusViewModel.TotalCount = finishedOrderDataModel.TotalCount;
            pendingCommentStatusViewModel.TotalPage = finishedOrderDataModel.TotalPage;
            pendingCommentStatusViewModel.PageIndex = finishedOrderDataModel.PageIndex;
            #endregion
            #region getAllOrderByCustomerId
            var allOrderDataModel = (from o in _readFromDb.Orders
                                                 where o.CustomerId == customer.Id
                                                 select new OrderDataModel()
                                                 {
                                                     Id = o.Id,
                                                     CustomerId = customer.Id,
                                                     AddressId = o.AddressId,
                                                     TotalAmount = o.TotalAmount,
                                                     OrderDate = o.OrderDate,
                                                     OrderStatus = o.OrderStatus,
                                                     DeliveryDate = o.DeliveryDate,
                                                 }).OrderByDescending(x => x.DeliveryDate).ToPagedList(indexNum, pageSize);
            var allList = allOrderDataModel.ToList();

            List<Order> AllList = new List<Order>();
            foreach (OrderDataModel order in allList)
            {
                AllList.Add(_readFromDb.Orders.Where(x => x.Id == order.Id).First());
            }
            allStatusViewModel.pageBar = allOrderDataModel.getPageBar();
            allStatusViewModel.TotalCount = allOrderDataModel.TotalCount;
            allStatusViewModel.TotalPage = allOrderDataModel.TotalPage;
            allStatusViewModel.PageIndex = allOrderDataModel.PageIndex;
            #endregion
            allStatusViewModel.AllOrder = AllList;
            pendingPaymentStatusViewModel.PendingPaymentOrder = PendingPaymentList;
            pendingDeliveryStatusViewModel.PendingDeliveryOrder = PendingDeliveryList;
            pendingReceivedStatusViewModel.PendingReceivedOrder = PendingReceivedList;
            pendingCommentStatusViewModel.PendingComment = FinishedList;

            OrderViewModel orderViewModel = new OrderViewModel();
            orderViewModel.CurrentTab = (int)currentTab;
            orderViewModel.AllStatusViewModel = allStatusViewModel;
            orderViewModel.PendingPaymentStatusViewModel = pendingPaymentStatusViewModel;
            orderViewModel.PendingDeliveryStatusViewModel = pendingDeliveryStatusViewModel;
            orderViewModel.PendingReceivedStatusViewModel = pendingReceivedStatusViewModel;
            orderViewModel.PendingCommentStatusViewModel = pendingCommentStatusViewModel;

            return View("OrderList", orderViewModel);
        }
        public ActionResult OrderDetail(long orderId)
        {
            Order order = _readFromDb.Orders.Where(x => x.Id == orderId).FirstOrDefault();
            return View("OrderDetail", order);
        }

        public ActionResult ReturnList(int? indexNum = 1, int? pageSize = 4)
        {
            Customer customer = Session[Constants.SESSION_USER] as Customer;

            var returnRequestDataModelList = (from r in _readFromDb.Returns
                                              where r.CustomerName == customer.CustomerName && r.ReturnStatus == Constants.FINISHED
                                              select new ReturnRequestDataModel()
                                              {
                                                  Id = r.Id,
                                                  CustomerName = r.CustomerName,
                                                  DeliveryDate = r.DeliveryDate,
                                                  ReturnStatus = r.ReturnStatus,
                                                  OrderId = r.OrderId,
                                                  OrderItemId = r.OrderItemId,
                                                  ReturnReason = r.ReturnReason
                                              }).OrderByDescending(x => x.DeliveryDate).ToPagedList(indexNum, pageSize);
            var returnList = returnRequestDataModelList.ToList();

            List<Order> orderList = new List<Order>();
            foreach (ReturnRequestDataModel returnItem in returnList)
            {
                orderList.Add(_readFromDb.Orders.Where(x => x.Id == returnItem.OrderId).First());
            }
            AllStatusViewModel orderViewModel = new AllStatusViewModel();
            orderViewModel.AllOrder = orderList;
            orderViewModel.PageIndex = returnRequestDataModelList.PageIndex;
            orderViewModel.pageBar = returnRequestDataModelList.getPageBar();
            orderViewModel.TotalCount = returnRequestDataModelList.TotalCount;
            orderViewModel.TotalPage = returnRequestDataModelList.TotalPage;
            return View("ReturnList", orderViewModel);
        }

        public ActionResult GetReturnRequest(int? indexNum = 1, int? pageSize = 2)
        {
            Customer customer = Session[Constants.SESSION_USER] as Customer;

            var returnRequestDataModelList = (from r in _readFromDb.Returns
                                              where r.CustomerName == customer.CustomerName && r.ReturnStatus == Constants.REQUESTING
                                              select new ReturnRequestDataModel()
                                              {
                                                  Id = r.Id,
                                                  CustomerName = r.CustomerName,
                                                  DeliveryDate = r.DeliveryDate,
                                                  ReturnStatus = r.ReturnStatus,
                                                  OrderId = r.OrderId,
                                                  OrderItemId = r.OrderItemId,
                                                  ReturnReason = r.ReturnReason
                                              }).OrderBy(x => x.DeliveryDate).ToPagedList(indexNum, pageSize);
            var returnList = returnRequestDataModelList.ToList();

            ReturnRequestListViewModel returnRequestListViewModel = new ReturnRequestListViewModel();
            foreach (ReturnRequestDataModel returnItem in returnList)
            {
                ReturnRequestViewModel returnRequestViewModel = new ReturnRequestViewModel();
                returnRequestViewModel.Ordrer = _readFromDb.Orders.Where(x => x.Id == returnItem.OrderId).First();
                returnRequestViewModel.OrderItem = _readFromDb.OrderItems.Where(x => x.Id == returnItem.OrderItemId).First();
                returnRequestViewModel.ReturnOrder = returnItem;
                returnRequestViewModel.Customer = _readFromDb.Customers.Where(x => x.CustomerName == returnItem.CustomerName).First();
                returnRequestListViewModel.ReturnRequestViewModelList.Add(returnRequestViewModel);
            }
            returnRequestListViewModel.TotalCount = returnRequestDataModelList.TotalCount;
            returnRequestListViewModel.TotalPage = returnRequestDataModelList.TotalPage;
            returnRequestListViewModel.pageBar = returnRequestDataModelList.getPageBar();
            returnRequestListViewModel.PageIndex = returnRequestDataModelList.PageIndex;
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
            Address address = _readFromDb.Address.Where(x => x.CustomerId == customerId && x.IsDefault).FirstOrDefault();

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
                order = _orderRepository.GetOrderByOrderId(orderId);
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

        public ActionResult OrderManageList(string num, int? currentTab = 1, int? indexNum = 1, int? pageSize = 4)
        {
            long id = 0;
            if (num != null)
            {
                try
                {
                    id = Convert.ToInt64(num);
                }
                catch (Exception ex)
                {
                    return Content("<script>alert('请输入正确的订单编号');location.href='/Order/OrderManageList'</script>");
                }
            }
            
            PendingDeliveryStatusViewModel pendingDeliveryStatusViewModel = new PendingDeliveryStatusViewModel();
            PendingPaymentStatusViewModel pendingPaymentStatusViewModel = new PendingPaymentStatusViewModel();
            PendingCommentStatusViewModel pendingCommentStatusViewModel = new PendingCommentStatusViewModel();
            PendingReceivedStatusViewModel pendingReceivedStatusViewModel = new PendingReceivedStatusViewModel();
            AllStatusViewModel allStatusViewModel = new AllStatusViewModel();

            #region getPendingPaymentOrderDataModel
            var pendingPaymentOrderDataModel = (from o in _readFromDb.Orders
                                                where o.OrderStatus == Constants.OBLIGATION && (o.Id == id|| id ==0 ) 
                                                select new OrderDataModel()
                                                {
                                                    Id = o.Id,
                                                    AddressId = o.AddressId,
                                                    TotalAmount = o.TotalAmount,
                                                    OrderDate = o.OrderDate,
                                                    OrderStatus = o.OrderStatus,
                                                    DeliveryDate = o.DeliveryDate,
                                                }).OrderBy(x => x.DeliveryDate).ToPagedList(indexNum, pageSize);
            var pendingPaymentList = pendingPaymentOrderDataModel.ToList();

            List<Order> PendingPaymentList = new List<Order>();
            foreach (OrderDataModel order in pendingPaymentList)
            {
                PendingPaymentList.Add(_readFromDb.Orders.Where(x => x.Id == order.Id).First());
            }
            pendingPaymentStatusViewModel.pageBar = pendingPaymentOrderDataModel.getPageBar();
            pendingPaymentStatusViewModel.TotalCount = pendingPaymentOrderDataModel.TotalCount;
            pendingPaymentStatusViewModel.TotalPage = pendingPaymentOrderDataModel.TotalPage;
            pendingPaymentStatusViewModel.PageIndex = pendingPaymentOrderDataModel.PageIndex;
            #endregion
            #region getPendingDeliveryOrderDataModel
            var pendingDeliveryOrderDataModel = (from o in _readFromDb.Orders
                                                 where o.OrderStatus == Constants.TRANSFER && (o.Id == id || id == 0)
                                                 select new OrderDataModel()
                                                 {
                                                     Id = o.Id,
                                                     AddressId = o.AddressId,
                                                     TotalAmount = o.TotalAmount,
                                                     OrderDate = o.OrderDate,
                                                     OrderStatus = o.OrderStatus,
                                                     DeliveryDate = o.DeliveryDate,
                                                 }).OrderBy(x => x.DeliveryDate).ToPagedList(indexNum, pageSize);
            var pendingDeliveryList = pendingPaymentOrderDataModel.ToList();

            List<Order> PendingDeliveryList = new List<Order>();
            foreach (OrderDataModel order in pendingDeliveryList)
            {
                PendingDeliveryList.Add(_readFromDb.Orders.Where(x => x.Id == order.Id).First());
            }
            pendingDeliveryStatusViewModel.pageBar = pendingDeliveryOrderDataModel.getPageBar();
            pendingDeliveryStatusViewModel.TotalCount = pendingDeliveryOrderDataModel.TotalCount;
            pendingDeliveryStatusViewModel.TotalPage = pendingDeliveryOrderDataModel.TotalPage;
            pendingDeliveryStatusViewModel.PageIndex = pendingDeliveryOrderDataModel.PageIndex;
            #endregion
            #region getPendingReceivedOrderDataModel
            var pendingReceivedOrderDataModel = (from o in _readFromDb.Orders
                                                 where o.OrderStatus == Constants.DELIVERY && (o.Id == id || id == 0)
                                                 select new OrderDataModel()
                                                 {
                                                     Id = o.Id,
                                                     AddressId = o.AddressId,
                                                     TotalAmount = o.TotalAmount,
                                                     OrderDate = o.OrderDate,
                                                     OrderStatus = o.OrderStatus,
                                                     DeliveryDate = o.DeliveryDate,
                                                 }).OrderBy(x => x.DeliveryDate).ToPagedList(indexNum, pageSize);
            var pendingReceivedList = pendingReceivedOrderDataModel.ToList();

            List<Order> PendingReceivedList = new List<Order>();
            foreach (OrderDataModel order in pendingReceivedList)
            {
                PendingReceivedList.Add(_readFromDb.Orders.Where(x => x.Id == order.Id).First());
            }
            pendingReceivedStatusViewModel.pageBar = pendingReceivedOrderDataModel.getPageBar();
            pendingReceivedStatusViewModel.TotalCount = pendingReceivedOrderDataModel.TotalCount;
            pendingReceivedStatusViewModel.TotalPage = pendingReceivedOrderDataModel.TotalPage;
            pendingReceivedStatusViewModel.PageIndex = pendingReceivedOrderDataModel.PageIndex;
            #endregion
            #region getFinishedOrderDataModel
            var finishedOrderDataModel = (from o in _readFromDb.Orders
                                          where o.OrderStatus == Constants.FINISHED && (o.Id == id || id == 0)
                                          select new OrderDataModel()
                                          {
                                              Id = o.Id,
                                              AddressId = o.AddressId,
                                              TotalAmount = o.TotalAmount,
                                              OrderDate = o.OrderDate,
                                              OrderStatus = o.OrderStatus,
                                              DeliveryDate = o.DeliveryDate,
                                          }).OrderBy(x => x.DeliveryDate).ToPagedList(indexNum, pageSize);
            var finishedList = finishedOrderDataModel.ToList();

            List<Order> FinishedList = new List<Order>();
            foreach (OrderDataModel order in finishedList)
            {
                FinishedList.Add(_readFromDb.Orders.Where(x => x.Id == order.Id).First());
            }
            pendingCommentStatusViewModel.pageBar = finishedOrderDataModel.getPageBar();
            pendingCommentStatusViewModel.TotalCount = finishedOrderDataModel.TotalCount;
            pendingCommentStatusViewModel.TotalPage = finishedOrderDataModel.TotalPage;
            pendingCommentStatusViewModel.PageIndex = finishedOrderDataModel.PageIndex;
            #endregion
            #region getAllOrderByCustomerId
            var allOrderDataModel = (from o in _readFromDb.Orders
                                     where  (o.Id == id || id == 0)
                                     select new OrderDataModel()
                                     {
                                         Id = o.Id,
                                         AddressId = o.AddressId,
                                         TotalAmount = o.TotalAmount,
                                         OrderDate = o.OrderDate,
                                         OrderStatus = o.OrderStatus,
                                         DeliveryDate = o.DeliveryDate,
                                     }).OrderBy(x => x.DeliveryDate).ToPagedList(indexNum, pageSize);
            var allList = allOrderDataModel.ToList();

            List<Order> AllList = new List<Order>();
            foreach (OrderDataModel order in allList)
            {
                AllList.Add(_readFromDb.Orders.Where(x => x.Id == order.Id).First());
            }
            allStatusViewModel.pageBar = allOrderDataModel.getPageBar();
            allStatusViewModel.TotalCount = allOrderDataModel.TotalCount;
            allStatusViewModel.TotalPage = allOrderDataModel.TotalPage;
            allStatusViewModel.PageIndex = allOrderDataModel.PageIndex;
            #endregion
            allStatusViewModel.AllOrder = AllList;
            pendingPaymentStatusViewModel.PendingPaymentOrder = PendingPaymentList;
            pendingDeliveryStatusViewModel.PendingDeliveryOrder = PendingDeliveryList;
            pendingReceivedStatusViewModel.PendingReceivedOrder = PendingReceivedList;
            pendingCommentStatusViewModel.PendingComment = FinishedList;

            OrderViewModel orderViewModel = new OrderViewModel();
            orderViewModel.CurrentTab = (int)currentTab;
            orderViewModel.AllStatusViewModel = allStatusViewModel;
            orderViewModel.PendingPaymentStatusViewModel = pendingPaymentStatusViewModel;
            orderViewModel.PendingDeliveryStatusViewModel = pendingDeliveryStatusViewModel;
            orderViewModel.PendingReceivedStatusViewModel = pendingReceivedStatusViewModel;
            orderViewModel.PendingCommentStatusViewModel = pendingCommentStatusViewModel;

            return View("OrderManage", orderViewModel);
        }
        public ActionResult ReturnManageList(string num, int? currentTab = 1, int? indexNum = 1, int? pageSize = 4)
        {
            long id = 0;
            if (num != null)
            {
                try
                {
                    id = Convert.ToInt64(num);
                }
                catch (Exception ex)
                {
                    return Content("<script>alert('请输入正确的订单编号');location.href='/Order/ReturnManageList'</script>");
                }
            }
            RequestingListViewModel requestingListViewModel = new RequestingListViewModel();
            ReturningListViewModel returningListViewModel = new ReturningListViewModel();
            ReturnFinishedListViewModel returnFinishedListViewModel = new ReturnFinishedListViewModel();

            var requestingListDataModel = (from o in _readFromDb.Orders
                                           where o.Returns.Count() > 0
                                           && o.Returns.Where(x => x.ReturnStatus == Constants.REQUESTING).Count() > 0 &&(o.Id ==id || id ==0)
                                                 select new OrderDataModel()
                                                 {
                                                     Id = o.Id,
                                                     AddressId = o.AddressId,
                                                     TotalAmount = o.TotalAmount,
                                                     OrderDate = o.OrderDate,
                                                     OrderStatus = o.OrderStatus,
                                                     DeliveryDate = o.DeliveryDate,
                                                 }).OrderBy(x => x.DeliveryDate).ToPagedList(indexNum, pageSize);
            var requestingList = requestingListDataModel.ToList();

            List<Order> RequestingList = new List<Order>();
            foreach (OrderDataModel order in requestingList)
            {
                RequestingList.Add(_readFromDb.Orders.Where(x => x.Id == order.Id).First());
            }
            requestingListViewModel.pageBar = requestingListDataModel.getPageBar();
            requestingListViewModel.TotalCount = requestingListDataModel.TotalCount;
            requestingListViewModel.TotalPage = requestingListDataModel.TotalPage;
            requestingListViewModel.PageIndex = requestingListDataModel.PageIndex;
            requestingListViewModel.RequestingList = RequestingList;

            var returningListDataModel = (from o in _readFromDb.Orders
                                          where o.Returns.Where(x => x.ReturnStatus == Constants.REQUESTING).Count() == 0
                                           && o.Returns.Where(x => x.ReturnStatus == Constants.RETURNING).Count() > 0 && (o.Id == id || id == 0)
                                          select new OrderDataModel()
                                           {
                                               Id = o.Id,
                                               AddressId = o.AddressId,
                                               TotalAmount = o.TotalAmount,
                                               OrderDate = o.OrderDate,
                                               OrderStatus = o.OrderStatus,
                                               DeliveryDate = o.DeliveryDate,
                                           }).OrderBy(x => x.DeliveryDate).ToPagedList(indexNum, pageSize);
            var returningList = returningListDataModel.ToList();
            List<Order> ReturningList = new List<Order>();
            foreach (OrderDataModel order in returningList)
            {
                ReturningList.Add(_readFromDb.Orders.Where(x => x.Id == order.Id).First());
            }
            returningListViewModel.pageBar = returningListDataModel.getPageBar();
            returningListViewModel.TotalCount = returningListDataModel.TotalCount;
            returningListViewModel.TotalPage = returningListDataModel.TotalPage;
            returningListViewModel.PageIndex = returningListDataModel.PageIndex;
            returningListViewModel.ReturningList = ReturningList;

            var returnFinishedListDataModel = (from o in _readFromDb.Orders
                                          where o.Returns.Where(x => x.ReturnStatus == Constants.REQUESTING).Count() == 0
                                                && o.Returns.Where(x => x.ReturnStatus == Constants.RETURNING).Count() == 0
                                                && o.Returns.Where(x => x.ReturnStatus == Constants.FINISHED).Count() > 0 && (o.Id == id || id == 0)
                                               select new OrderDataModel()
                                          {
                                              Id = o.Id,
                                              AddressId = o.AddressId,
                                              TotalAmount = o.TotalAmount,
                                              OrderDate = o.OrderDate,
                                              OrderStatus = o.OrderStatus,
                                              DeliveryDate = o.DeliveryDate,
                                          }).OrderBy(x => x.DeliveryDate).ToPagedList(indexNum, pageSize);
            var returnFinishedList = returnFinishedListDataModel.ToList();
            List<Order> ReturnFinishedList = new List<Order>();
            foreach (OrderDataModel order in returnFinishedList)
            {
                ReturnFinishedList.Add(_readFromDb.Orders.Where(x => x.Id == order.Id).First());
            }
            returnFinishedListViewModel.pageBar = returnFinishedListDataModel.getPageBar();
            returnFinishedListViewModel.TotalCount = returnFinishedListDataModel.TotalCount;
            returnFinishedListViewModel.TotalPage = returnFinishedListDataModel.TotalPage;
            returnFinishedListViewModel.PageIndex = returnFinishedListDataModel.PageIndex;
            returnFinishedListViewModel.ReturnFinishedList = ReturnFinishedList;

            ReturnManageListViewModel returnManageListViewModel = new ReturnManageListViewModel();
            returnManageListViewModel.RequestingListViewModel = requestingListViewModel;
            returnManageListViewModel.ReturningListViewModel = returningListViewModel;
            returnManageListViewModel.ReturnFinishedListViewModel  = returnFinishedListViewModel;
            returnManageListViewModel.CurrentTab = (int)currentTab;
            return View("ReturnManage", returnManageListViewModel);
        }

        public ActionResult AgreeRequest(long orderId, long orderItemId)
        {
            try
            {
                Order order = _orderRepository.GetOrderByOrderId(orderId);
                Return returnItem = _orderRepository.GetReturn(orderId, orderItemId);
                if (Constants.TRANSFER.Equals(order.OrderStatus))
                {
                    returnItem.ReturnStatus = Constants.FINISHED;
                    _orderRepository.UpdateReturn(returnItem);
                }
                else if (Constants.DELIVERY.Equals(order.OrderStatus))
                {
                    returnItem.ReturnStatus = Constants.RETURNING;
                    _orderRepository.UpdateReturn(returnItem);
                    //退货物流规划 结束后  returnItem.ReturnStatus = Constants.FINISHED;
                }

                if (_orderRepository.GetReturnListByOrderId(orderId).Where(x => x.ReturnStatus == Constants.FINISHED).Count() == order.OrderItems.Count())
                {
                    order.OrderStatus = Constants.FINISHED;
                    _orderRepository.UpdateOrder(order);
                }
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction("ReturnManageList");
        }
    }
}