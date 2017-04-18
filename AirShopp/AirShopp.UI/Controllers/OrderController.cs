using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirShopp.UI.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View("OrderList", null);
        }
        public ActionResult OrderDetail()
        {
            return View("OrderDetail", null);
        }
    }
}