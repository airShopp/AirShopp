using System.Collections.Generic;

namespace AirShopp.Domain
{
    public interface IAddressService
    {
        void AddAddress(Address address);
        List<Address> GetAddresses(long customerId);
        Address GetAddress(long addressId);
        void UpdateAddress(Address address);
        void DeleteAddress(long addressId);
    }
}
