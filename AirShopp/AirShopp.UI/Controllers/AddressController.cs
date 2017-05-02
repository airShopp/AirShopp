using AirShopp.Domain;
using AirShopp.UI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirShopp.UI.Controllers
{
    public class AddressController : Controller
    {
        private IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        // GET: Address
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddAddress(Address address)
        {
            _addressService.AddAddress(address);
            return View();
        }

        public ActionResult GetAddress(long customerId)
        {
            List<Address> addressList = _addressService.GetAddress(customerId);
            AddressListViewModel addressListViewModel = new AddressListViewModel();
            addressListViewModel.ProvinceList = null;
            addressListViewModel.CityList = null;
            addressListViewModel.AreaList = null;
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
            _addressService.DeleteAddress(addressId);
            return View();
        }
    }
}