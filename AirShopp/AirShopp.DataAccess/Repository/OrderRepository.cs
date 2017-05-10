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
    }
}
