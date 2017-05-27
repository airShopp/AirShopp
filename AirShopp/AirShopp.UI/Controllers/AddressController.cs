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

        public ActionResult AddAddress(string areaId, string address, string receiverName, string receiverPhone, bool isDefault, long? OrderId)
        {

            Area area = _areaRepository.GetAreaById(int.Parse(areaId));
            City city = _cityRepository.GetCityById(area.CityId);
            Province province = _provinceRepository.GetProvinceById(city.ProvinceId);

            long customerId = (Session[Constants.SESSION_USER] as Customer).Id;
            if (OrderId!=0)
            {
                isDefault = true;
            }

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

            if (OrderId == 0)
            {
                return RedirectToAction("GetAddress");
            }
            else
            {
                return RedirectToRoute(new { controller = "Order", action = "CheckOrder", orderId = OrderId });
            }
        }

        [HttpGet]
        public ActionResult GetAddress(long? OrderId)
        {
            Customer customer = Session[Constants.SESSION_USER] as Customer;
            List<Address> addressList = _addressService.GetAddress(customer.Id);
            AddressListViewModel addressListViewModel = new AddressListViewModel();
            addressListViewModel.ProvinceList = _provinceRepository.GetProvince();
            addressListViewModel.CityList = _cityRepository.GetCity();
            addressListViewModel.AreaList = _areaRepository.GetArea();
            addressListViewModel.AddressList = addressList;
            if (OrderId != null)
            {
                addressListViewModel.OrderId = (long)OrderId;
            }
            return View("AddressList", addressListViewModel);
        }

        public ActionResult UpdateAddress(long Id, string address, string receiverName, string receiverPhone)
        {
            Address editAddress = new Address()
            {
                Id = Id,
                DeliveryAddress = address,
                ReceiverName = receiverName,
                ReceiverPhone = receiverPhone
            };
            _addressRepository.UpdateAddress(editAddress);
            return RedirectToAction("GetAddress");
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

        public ActionResult SetDefaultAddress(long addressId, long OrderId)
        {
            _addressRepository.SetDefaultAddress(addressId);
            if (OrderId != 0)
            {
                return RedirectToRoute(new { controller = "Order", action = "CheckOrder", orderId = OrderId });
            }
            else
            {
                return RedirectToAction("GetAddress");
            }
        }
    }
}