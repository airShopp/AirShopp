using AirShopp.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AirShopp.DataAccess
{
    public class AddressRepository : IAddressRepository
    {
        public AirShoppContext _context = new AirShoppContext();
        public void AddAddress(Address address)
        {
            _context.Address.Add(address);
            _context.SaveChanges();
        }

        public List<Address> GetAddress(long customerId)
        {
            List<Address> addressList = new List<Address>();
            _context.Address.Where(x => x.CustomerId == customerId).ToList().ForEach(address => {
                addressList.Add(new Address() {
                    Id = address.Id,
                    ReceiverName = address.ReceiverName,
                    ReceiverPhone = address.ReceiverPhone,
                    DeliveryAddress = address.DeliveryAddress,
                    IsDefault = address.IsDefault,
                    //Customer = address.Customer,
                });
            });

            return addressList;
        }

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
    }
}
