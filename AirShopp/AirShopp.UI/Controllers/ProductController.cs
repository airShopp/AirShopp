using AirShopp.UI.Models;
using AirShopp.UI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirShopp.UI.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var Category = Session["Category"];
            return View("ProductList");
        }
        public ActionResult getProduct( )
        {
            return View("ProductDetail");
        }
        public ActionResult ShopCart()
        {
            return View();
        }
    }
}