using System.Collections.Generic;

namespace AirShopp.Domain
{
    public interface IAddressRepository
    {
        void AddAddress(Address address);
        List<Address> GetAddresses(long customerId);
        Address GetAddress(long addressId);
        void UpdateAddress(Address address);
        void DeleteAddress(long addressId);
        void SetDefaultAddress(long addressId);
    }
}
