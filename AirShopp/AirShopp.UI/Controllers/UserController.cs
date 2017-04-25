using System;
using System.Web.Mvc;
using AirShopp.DataAccess;
using AirShopp.Domain;
using AirShopp.UI.Models.ViewModel;
using AirShopp.Common;

namespace AirShopp.UI.Controllers
{
    public class UserController : Controller
    {
        private AirShoppContext db = new AirShoppContext();
        private IAdminService _adminService;
        private ICustomerRepository _customerRepository;

        public UserController(
            IAdminService adminService,
            ICustomerRepository customerRepository
            )
        {
            _adminService = adminService;
            _customerRepository = customerRepository;
        }

        // GET: Admins
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserViewModel user)
        {
            try
            {
                Customer customer = _customerRepository.GetCustomer(user.UserName, user.Password);
                Session.Add("customer", customer);
                if (user.RememberPwd)
                {
                    CookieHelper.SetCookie("UserName", "UserName", user.UserName, DateTime.Now.AddDays(2));
                    CookieHelper.SetCookie("Password", "Password", user.Password, DateTime.Now.AddDays(2));
                }
                else
                {
                    CookieHelper.RemoveCookie("UserName", null);
                    CookieHelper.RemoveCookie("Password", null);
                }
                return RedirectToAction("Index", "Home",customer);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Index");
            }
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserViewModel user)
        {
            Customer customer = new Customer();
            customer.Account = user.UserName;
            customer.Password = user.Password;
            _customerRepository.AddCustomer(customer);
            // Return null not empty string
            Customer customer1 = _customerRepository.GetCustomer(user.UserName, user.Password);
            return View();
        }

        public ActionResult CheckAccount(string account)
        {
            return Content(_customerRepository.GetCustomer(account).ToString());
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
