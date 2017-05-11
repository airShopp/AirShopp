using AirShopp.Common;
using AirShopp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.DataAccess
{
    public class DeliveryOrderRepository : IDeliveryOrderRepository
    {
        private AirShoppContext _context = new AirShoppContext();

        public List<DeliveryOrder> GetDeliveryOrders()
        {
            return _context.DeliveryOrder.OrderBy(x => x.DeliveryDate).ToList();
        }

        public long AddDeliveryOrder(DeliveryOrder deliveryOrder)
        {
            _context.DeliveryOrder.Add(deliveryOrder);
            _context.SaveChanges();
            return deliveryOrder.Id;
        }

        public long GetMaxDeliveryOrderId()
        {
            long Id = 0;
            List<DeliveryOrder> deliveryOrder = _context.DeliveryOrder.OrderByDescending(x => x.Id).ToList();
            if (deliveryOrder == null || deliveryOrder.Count == 0)
            {
                Id = 1;
            }else
            {
                Id = deliveryOrder.FirstOrDefault().Id + 1;
            }
            return Id;
        }

        public string GetMaxDeliveryOrderNumber(string beginSerialNumber)
        {
            string maxDeliveryOrderNumberStr = null;

            List<DeliveryOrder> deliveryOrderList =  _context.DeliveryOrder.Where(x => x.DeliveryOrderNumber.Contains(beginSerialNumber)).OrderByDescending(x => x.DeliveryOrderNumber).ToList();

            if (deliveryOrderList == null || deliveryOrderList.Count == 0)
            {
                maxDeliveryOrderNumberStr = "0001";
            }
            else
            {
                int index = deliveryOrderList.FirstOrDefault().DeliveryOrderNumber.LastIndexOf('-');
                string currentDeliveryOrderNumberStr = deliveryOrderList.FirstOrDefault().DeliveryOrderNumber.Substring(index + 1);
                int maxDeliveryOrderNumber = int.Parse(currentDeliveryOrderNumberStr) + 1;
                maxDeliveryOrderNumberStr = MathHelper.PadLeft(4, maxDeliveryOrderNumber);
            }

            return maxDeliveryOrderNumberStr;
        }

        public DeliveryOrder GetDeliveryOrderByPK(long deliveryOrderId)
        {
            DeliveryOrder deliveryOrder = null;
            List<DeliveryOrder> deliverOrderList = _context.DeliveryOrder.Where(x => x.Id == deliveryOrderId).ToList();
            if (deliverOrderList.Count > 0)
            {
                deliveryOrder = deliverOrderList.FirstOrDefault();
            }
            return deliveryOrder;
        }
    }
}
