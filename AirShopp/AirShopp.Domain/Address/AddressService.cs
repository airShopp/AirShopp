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

        public List<Address> GetAddress(long customerId)
        {
            return _addressRepository.GetAddress(customerId);
        }

        public void UpdateAddress(Address address)
        {
            _addressRepository.UpdateAddress(address);
        }
    }
}
