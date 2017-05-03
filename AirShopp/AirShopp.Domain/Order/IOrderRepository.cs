using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Domain
{
    public interface IOrderRepository
    {
        Order AddOrder(Order order);
        void DeleteOrder(long orderId);
        void UpdateOrder(Order order);
        List<Order> LoadOrderList(long customerId);
        Order GetOrderByOrderId(long orderId);
    }
}
