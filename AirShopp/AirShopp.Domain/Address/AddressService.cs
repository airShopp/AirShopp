using System.Collections.Generic;

namespace AirShopp.Domain
{
    public class AddressService : IAddressService
    {
        public IAddressRepository _addressRepository;
        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public void AddAddress(Address address)
        {
            _addressRepository.AddAddress(address);
        }

        public void DeleteAddress(long addressId)
        {
            _addressRepository.DeleteAddress(addressId);
        }

        public List<Address> GetAddresses(long customerId)
        {
            return _addressRepository.GetAddresses(customerId);
        }

        public Address GetAddress(long addressId)
        {
            return _addressRepository.GetAddress(addressId);
        }

        public void UpdateAddress(Address address)
        {
            _addressRepository.UpdateAddress(address);
        }
    }
}
