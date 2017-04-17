using AirShopp.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AirShopp.DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public AirShoppContext _context = new AirShoppContext();
        public void AddOrder(Order order)
        {
            _context.Order.Add(order);
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

        public List<Order> LoadOrderList(long customerId)
        {
            return _context.Order.Where(x => x.CustomerId == customerId).ToList();
        }

        public void UpdateOrder(Order order)
        {
            _context.Entry<Order>(order).State = EntityState.Modified;
        }
    }
}
