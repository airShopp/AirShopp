using AirShopp.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AirShopp.DataAccess
{
    public class OrderRepository : IOrderRepository
    {
        public AirShoppContext _context = new AirShoppContext();
        public Order AddOrder(Order order)
        {
            order = _context.Order.Add(order);
            _context.SaveChanges();
            return order;
        }

        public void DeleteOrder(long orderId)
        {
            var order = _context.Order.Find(orderId);
            _context.Entry<Order>(order).State = EntityState.Deleted;
        }

        public Order GetOrderByOrderId(long orderId)
        {
            return _context.Order.Find(orderId); 
        }

        public List<Order> LoadOrderList(long customerId)
        {
            List<Order> orders = new List<Order>();
            #region just for mock delivery info
            List<DeliveryInfo> deliveryInfoList = new List<DeliveryInfo>()
            {
                new DeliveryInfo() {
                    Id = 1,
                    Index = 1,
                    OrderId = 1,
                    Description = "卖家已发货",
                    UpdateTime = DateTime.Now.AddHours(-5),
                },
                new DeliveryInfo() {
                    Id = 2,
                    Index = 2,
                    OrderId = 1,
                    Description = "洛阳市已揽件",
                    UpdateTime = DateTime.Now.AddHours(-3),

                },
                new DeliveryInfo() {
                    Id = 3,
                    Index = 3,
                    OrderId = 1,
                    Description = "洛阳已发出",
                    UpdateTime = DateTime.Now.AddHours(-1),
                },
                new DeliveryInfo() {
                    Id = 4,
                    Index = 4,
                    OrderId = 1,
                    Description = "正在派送",
                    UpdateTime = DateTime.Now.AddHours(2),
                },
            };
            #endregion
            _context.Order.Where(x => x.CustomerId == customerId).OrderBy(y  => y.DeliveryDate).ToList().ForEach(order => {
                orders.Add(new Order()
                {
                    Id = order.Id,
                    TotalAmount = order.TotalAmount,
                    OrderDate = order.OrderDate,
                    OrderStatus = order.OrderStatus,
                    DeliveryDate = order.DeliveryDate,
                    IsSpecialOrder = order.IsSpecialOrder,
                    SpecialType = order.SpecialType,
                    Customer = order.Customer,
                    Address = order.Address,
                    DeliveryOrder = order.DeliveryOrder,
                    DeliveryNote = order.DeliveryNote,
                    //DeliveryInfos = order.DeliveryInfos,
                    DeliveryInfos = deliveryInfoList,
                    Comments = order.Comments,
                    OrderItems = order.OrderItems,
                });
            });
            return orders;
        }

        public void UpdateOrder(Order order)
        {
            _context.Entry<Order>(order).State = EntityState.Modified;
        }
    }
}
