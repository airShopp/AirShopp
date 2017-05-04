using AirShopp.Common;
using AirShopp.Domain;
using AirShopp.UI.Models;
using AirShopp.UI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirShopp.UI.Controllers
{
    public class AddressController : FliterController
    {
        private IAddressService _addressService;
        private IAddressRepository _addressRepository;
        private IProvinceRepository _provinceRepository;
        private ICityRepository _cityRepository;
        private IAreaRepository _areaRepository;

        public AddressController(IAddressService addressService, IAddressRepository addressRepository, IProvinceRepository provinceRepository, ICityRepository cityRepository, IAreaRepository areaRepository)
        {
            _addressService = addressService;
            _provinceRepository = provinceRepository;
            _cityRepository = cityRepository;
            _areaRepository = areaRepository;
            _addressRepository = addressRepository;
        }

        // GET: Address
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddAddress(string areaId, string address, string receiverName, string receiverPhone, bool isDefault)
        {

            Area area = _areaRepository.GetAreaById(int.Parse(areaId));
            City city = _cityRepository.GetCityById(area.CityId);
            Province province = _provinceRepository.GetProvinceById(city.ProvinceId);

            long customerId = (Session[Constants.SESSION_USER] as Customer).Id;

            if (isDefault)
            {
                List<Address> addressList = _addressService.GetAddress(customerId);
                Address defaultAddress = addressList.Where(x => x.IsDefault == isDefault).ToList().FirstOrDefault();
                if (defaultAddress != null)
                {
                    defaultAddress.IsDefault = false;
                    _addressService.UpdateAddress(defaultAddress);
                }
            }

            string fullAddress = province.ProvinceName + city.CityName + area.AreaName + address;
            string addressParam = "&address=" + fullAddress;

            string ak = "&ak=" + Constants.BMAP_AK;

            LocationDataModel locationDataModel = JsonHelper.DeserializeJsonToObject<LocationDataModel>(WebAPIHelper.Get(Constants.BMAP_GEOCODER_BASE_URL + Constants.BMAP_OUTPUT_TYPE + addressParam + ak));

            Address DeliveryAddress = new Address()
            {
                ReceiverName = receiverName,
                ReceiverPhone = receiverPhone,
                DeliveryAddress = fullAddress,
                IsDefault = isDefault,
                Latitude = locationDataModel.Result.Location.Lat,
                Longitude = locationDataModel.Result.Location.Lng,
                AreaId = int.Parse(areaId),
                CustomerId = customerId
            };

            _addressService.AddAddress(DeliveryAddress);

            return RedirectToAction("GetAddress");
        }

        public ActionResult GetAddress()
        {
            Customer customer = Session[Constants.SESSION_USER] as Customer;
            List<Address> addressList = _addressService.GetAddress(customer.Id);
            AddressListViewModel addressListViewModel = new AddressListViewModel();
            addressListViewModel.ProvinceList = _provinceRepository.GetProvince();
            addressListViewModel.CityList = _cityRepository.GetCity();
            addressListViewModel.AreaList = _areaRepository.GetArea();
            addressListViewModel.AddressList = addressList;
            return View("AddressList", addressListViewModel);
        }

        public ActionResult UpdateAddress(Address address)
        {
            _addressService.UpdateAddress(address);
            return View();
        }

        public ActionResult DeleteAddress(long addressId)
        {
            try
            {
                _addressService.DeleteAddress(addressId);
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("GetAddress");
        }

        public ActionResult SetDefaultAddress(long addressId)
        {
            _addressRepository.SetDefaultAddress(addressId);
            return RedirectToAction("GetAddress");
        }
    }
}