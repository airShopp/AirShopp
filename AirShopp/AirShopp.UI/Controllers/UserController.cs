using System;
using System.Web.Mvc;
using AirShopp.DataAccess;
using AirShopp.Domain;
using AirShopp.UI.Models.ViewModel;
using AirShopp.Common;
using System.Web;

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
            HttpCookie AccountCookie = CookieHelper.GetCookie("UserName");
            HttpCookie PwdCookie = CookieHelper.GetCookie("Password");
            if (AccountCookie != null && PwdCookie != null && user.Password.Equals(PwdCookie.Value))
            {
                user.UserName = AccountCookie.Value;
                user.Password = AccountCookie.Value;
            }
            else
            {
                user.Password = MathHelper.SHA1(user.Password);
            }

            try
            {
                Customer customer = _customerRepository.GetCustomer(user.UserName, user.Password);

                if (user.RememberPwd)
                {
                    CookieHelper.SetCookie("UserName", "UserName", customer.Account, DateTime.Now.AddDays(1));
                    CookieHelper.SetCookie("Password", "Password", MathHelper.SHA1(customer.Password), DateTime.Now.AddDays(1));
                }
                else
                {
                    CookieHelper.RemoveCookie("UserName", null);
                    CookieHelper.RemoveCookie("Password", null);
                }

                // Clear password for security
                customer.Password = null;
                Session.Add("customer", customer);

                return RedirectToAction("Index", "Home",customer);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        [HttpGet]
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

        [HttpGet]
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
