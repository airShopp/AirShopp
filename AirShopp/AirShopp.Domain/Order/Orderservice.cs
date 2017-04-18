using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Domain
{
    public class Orderservice : IOrderservice
    {
        public IOrderRepository _orderRepository;
        public Orderservice(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public void AddOrder(Order order)
        {
            _orderRepository.AddOrder(order);
        }
        public void DeleteOrder(long orderId)
        {
            _orderRepository.DeleteOrder(orderId);
        }

        public Order GetOrderByOrderId(long orderId)
        {
            return _orderRepository.GetOrderByOrderId(orderId);
        }

        public List<Order> LoadOrderList(long customerId)
        {
            return _orderRepository.LoadOrderList(customerId);
        }

        public void UpdateOrder(Order order)
        {
            _orderRepository.UpdateOrder(order);
        }
    }
}
