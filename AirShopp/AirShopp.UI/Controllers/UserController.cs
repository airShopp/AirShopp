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

        public UserController(
            IAdminService adminService
            )
        {
            _adminService = adminService;
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
        public ActionResult Login(string account, string password)
        {
            
            try
            {
                Admin admin = _adminService.UserLogin(account, password);
                Session.Add("User",admin);
                return RedirectToAction("Index","Home");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Index");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Test()
        {
            return View();
        }
    }
}
