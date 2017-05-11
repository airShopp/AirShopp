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

        public Return GetReturn(long orderId, long orderItemId)
        {
            return _context.Return.Where(x => x.OrderId == orderId && x.OrderItemId == orderItemId).FirstOrDefault();
        }

        public List<Return> GetReturnList(string customerName)
        {
            return _context.Return.Where(x => x.CustomerName == customerName).ToList();
        }

        public List<Return> GetReturnListByOrderId(long orderId)
        {
            return _context.Return.Where(x => x.OrderId == orderId).ToList();
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

        public void ToPayment(long orderId)
        {
            var order = _context.Order.Find(orderId);
            order.OrderStatus = "TRANSFER";
            _context.Entry<Order>(order).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            _context.Entry<Order>(order).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void UpdateReturn(Return returnItem)
        {
            _context.Entry<Return>(returnItem).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
