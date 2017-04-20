using System;
using System.Web.Mvc;
using AirShopp.DataAccess;
using AirShopp.Domain;

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
        public ActionResult Login(string account, string password, string userType)
        {

            try
            {
                Customer customer = _customerRepository.GetCustomer(account, password);
                Session.Add("customer", customer);
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
