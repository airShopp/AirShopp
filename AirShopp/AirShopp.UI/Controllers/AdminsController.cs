using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AirShopp.DataAccess;
using AirShopp.Domain;

namespace AirShopp.UI.Controllers
{
    public class AdminsController : Controller
    {
        private AirShoppContext db = new AirShoppContext();
        private IAdminService _adminService;

        public AdminsController(
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
                ViewBag.Message = "Success！！";
                return RedirectToAction("Index","Home",admin);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
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
