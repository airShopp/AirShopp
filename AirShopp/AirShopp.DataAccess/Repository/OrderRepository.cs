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

        public void CancelOrder(long orderId)
        {
            var order = _context.Order.Find(orderId);
            order.OrderStatus = "CANCELED";
            _context.Entry<Order>(order).State = EntityState.Modified;
            _context.SaveChanges();
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

        public List<Return> GetReturnList(string customerName)
        {
            return _context.Return.Where(x => x.CustomerName == customerName).ToList();
        }

        public List<Order> LoadOrderList(long customerId)
        {
            return _context.Order.Where(x => x.CustomerId == customerId).OrderBy(y => y.DeliveryDate).ToList();
        }

        public void ReturnOrder(Return returnOrder)
        {
            _context.Return.Add(returnOrder);
            _context.SaveChanges();
        }

<<<<<<< HEAD
        public void ToPayment(long orderId)
        {
            var order = _context.Order.Find(orderId);
            order.OrderStatus = "TRANSFER";
            _context.Entry<Order>(order).State = EntityState.Modified;
            _context.SaveChanges();
=======
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
                    DeliveryInfos = deliveryInfoList,
                    Comments = order.Comments,
                    OrderItems = order.OrderItems,
                });
            });
            return orders;
>>>>>>> 8eb6f1c8d3618036271db6133d5a59ffb12d8916
        }

        public void UpdateOrder(Order order)
        {
            _context.Entry<Order>(order).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
