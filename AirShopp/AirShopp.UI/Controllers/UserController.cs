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
            HttpCookie AccountCookie = WebClientHelper.GetCookie(Constants.USER_NAME);
            
            HttpCookie PwdCookie = WebClientHelper.GetCookie(Constants.PASSWORD);
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
                    WebClientHelper.SetCookie(Constants.USER_NAME, Constants.USER_NAME, customer.Account, DateTime.Now.AddDays(1));
                    WebClientHelper.SetCookie(Constants.PASSWORD, Constants.PASSWORD, MathHelper.SHA1(customer.Password), DateTime.Now.AddDays(1));
                }
                else
                {
                    WebClientHelper.RemoveCookie(Constants.USER_NAME, null);
                    WebClientHelper.RemoveCookie(Constants.PASSWORD, null);
                }

                // Clear password for security
                customer.Password = null;
                Session.Add(Constants.SESSION_USER, customer);

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
            bool isExist = _customerRepository.GetCustomer(user.UserName);
            bool isEquals = user.Password.Equals(user.ConfirmPassword);
            if (!isExist && isEquals)
            {
                user.Password = MathHelper.SHA1(user.Password);
                ViewBag.User = user;
                return View("UpdateUserInfo");
            }
            else
            {
                if (isExist)
                {
                    ViewBag.AccountMsg = MessageConstants.USER_NAME_EXIST;
                }
                if (!isEquals)
                {
                    ViewBag.PwdMsg = MessageConstants.PASSWORD_NOT_EQUALS;
                }
                return View();
            }
            
        }

        [HttpGet]
        public ActionResult UpdateUserInfo()
        {
            return View();
        }

        [HttpGet]
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
