using System;
using System.Web.Mvc;
using AirShopp.DataAccess;
using AirShopp.Domain;
using AirShopp.UI.Models.ViewModel;
using AirShopp.Common;
using System.Web;
using System.Web.Routing;

namespace AirShopp.UI.Controllers
{
    public class UserController : Controller
    {
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
            string skipAction = string.Empty;
            string skipController = string.Empty;
            HttpCookie AccountCookie = WebClientHelper.GetCookie(Constants.USER_NAME);
            HttpCookie PwdCookie = WebClientHelper.GetCookie(Constants.PASSWORD);
            if (AccountCookie != null && PwdCookie != null && user.Password.Equals(PwdCookie.Value))
            {
                user.UserName = AccountCookie.Value;
                user.Password = PwdCookie.Value;
            }
            else
            {
                user.Password = MathHelper.MD5(user.Password);
            }
            try
            {
                Customer customer = _customerRepository.GetCustomer(user.UserName, user.Password);
                if (user.RememberPwd)
                {
                    WebClientHelper.SetCookie(Constants.USER_NAME, Constants.USER_NAME, customer.Account, DateTime.Now.AddDays(1));
                    WebClientHelper.SetCookie(Constants.PASSWORD, Constants.PASSWORD, customer.Password, DateTime.Now.AddDays(1));
                }
                else
                {
                    WebClientHelper.RemoveCookie(Constants.USER_NAME, null);
                    WebClientHelper.RemoveCookie(Constants.PASSWORD, null);
                }
                customer.Password = null;
                Session.Add(Constants.SESSION_USER, customer);

                skipAction = "Index";
                skipController = "Home";
                // Clear password for security
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                try
                {
                    var admin = _adminService.UserLogin(user.UserName, user.Password);
                    if (user.RememberPwd)
                    {
                        WebClientHelper.SetCookie(Constants.USER_NAME, Constants.USER_NAME, admin.Account, DateTime.Now.AddDays(1));
                        WebClientHelper.SetCookie(Constants.PASSWORD, Constants.PASSWORD, admin.Password, DateTime.Now.AddDays(1));
                    }
                    else
                    {
                        WebClientHelper.RemoveCookie(Constants.USER_NAME, null);
                        WebClientHelper.RemoveCookie(Constants.PASSWORD, null);
                    }
                    admin.Password = null;
                    Session.Add(Constants.SESSION_ADMIN, admin);
                    return RedirectToAction("Index", "Inventory" );
                }
                catch (Exception e)
                {
                    TempData["ErrMsg"] = Constants.ERROR_MSG;
                    return View();
                    throw;
                }
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
                TempData[Constants.USER_NAME] = user.UserName;
                TempData[Constants.PASSWORD] = MathHelper.MD5(user.Password);
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

        [HttpPost]
        public ActionResult UpdateUserInfo(UserViewModel user)
        {
            Customer customer = user.toCustomer();
            customer.LastSignInIpAddr = WebClientHelper.GetHostAddress();
            _customerRepository.AddCustomer(customer);

            customer.Password = null;
            Session.Add(Constants.SESSION_USER, customer);

            return RedirectToAction("UserInfo");
        }

        [HttpGet]
        public ActionResult UserInfo()
        {
            var customer = Session[Constants.SESSION_USER] as Customer;

            try
            {
                customer.TelephoneNo = customer.TelephoneNo.Substring(0, 3) + "****" + customer.TelephoneNo.Substring(7, 4);
                Session.Add(Constants.SESSION_USER, customer);
            }
            catch
            {
            }

            Session.Add(Constants.IP, WebClientHelper.GetHostAddress());
            Session.Add(Constants.TIME, DateTimeHelper.GetDate(DateTime.Now));
            return View();
        }

        [HttpPost]
        public ActionResult UpdateUserPwd()
        {
            return Content("");
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

    }
}
