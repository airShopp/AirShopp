using AirShopp.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System;

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
            return _context.Address.Where(x => x.CustomerId == customerId).ToList();
        }

        public void UpdateAddress(Address address)
        {
            Address addressFromDb  = _context.Address.Find(address.Id);
            addressFromDb.DeliveryAddress = address.DeliveryAddress;
            addressFromDb.ReceiverName = address.ReceiverName;
            addressFromDb.ReceiverPhone = address.ReceiverPhone;
            _context.Entry<Address>(addressFromDb).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteAddress(long addressId)
        {
            var address = _context.Address.Find(addressId);
            if (address.IsDefault)
            {
                Address addressFirst = _context.Address.Where(x => x.CustomerId == address.CustomerId&& x.Id!=address.Id).OrderByDescending(x => x.Id).FirstOrDefault();
                addressFirst.IsDefault = true;
                _context.Entry<Address>(addressFirst).State = EntityState.Modified;
                _context.SaveChanges();
            }
            _context.Entry<Address>(address).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void SetDefaultAddress(long addressId)
        {
            var address = _context.Address.Find(addressId);
            Address addressDefault = _context.Address.Where
                (x => x.CustomerId == address.CustomerId && x.IsDefault).FirstOrDefault();
            if (addressDefault != null)
            {
                addressDefault.IsDefault = false;
                _context.Entry<Address>(addressDefault).State = EntityState.Modified;
                _context.SaveChanges();
            }
            address.IsDefault = true;
            _context.Entry<Address>(address).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
