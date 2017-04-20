using AirShopp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.DataAccess
{
    public class DeliveryInfoRepository : IDeliveryInfoRepository
    {
        public AirShoppContext _context = new AirShoppContext();

        public void AddDeliverInfo(DeliveryInfo deliveryInfo)
        {
            _context.DeliveryInfo.Add(deliveryInfo);
            _context.SaveChanges();
        }

        public List<DeliveryInfo> GetDeliveryInfo(long orderId)
        {
            return _context.DeliveryInfo.Where(x => x.OrderId == orderId).OrderBy(y => y.Index).ToList();
        }

        public int GetMaxIndex(long orderId)
        {
            int index = 0;
            List<DeliveryInfo> deliveryInfoList = _context.DeliveryInfo.Where(x => x.OrderId == orderId).OrderByDescending(y => y.Index).ToList();

            if (deliveryInfoList.Count > 0){
                index = deliveryInfoList.FirstOrDefault().Index;
            }
            return index;   
        }
        /*
        public void UpdateAddress(Address address)
        {
            _context.Entry<Address>(address).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteAddress(long addressId)
        {
            var address = _context.Address.Find(addressId);
            _context.Entry<Address>(address).State = EntityState.Deleted;
            _context.SaveChanges();
        }
         * */
    }
}
