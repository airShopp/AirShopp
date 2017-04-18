using AirShopp.DataAccess;
using AirShopp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirShopp.UI.Controllers
{
    public class CartController : Controller
    {
        private AirShoppContext db = new AirShoppContext();
        private ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
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

        public ActionResult LoadCartList(Admin admin)
        {
            if (admin != null)
            {
                List<Cart> cartList = _cartService.LoadCartList(admin.Id);
                return RedirectToAction("Index", "Home", cartList);
            }
            else 
            {
                return View("/Views/Admins/Login.cshtml");
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