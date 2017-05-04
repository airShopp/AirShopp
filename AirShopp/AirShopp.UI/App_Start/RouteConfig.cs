using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AirShopp.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "ToOrderList",
                url: "{controller}/{action}/{customerId}",
                defaults: new { controller = "Order", action = "Index", customerId = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "ToAddressList",
                url: "{controller}/{action}/{customerId}",
                defaults: new { controller = "Address", action = "GetAddress", customerId = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "ToCommentList",
                url: "{controller}/{action}/{customerId}",
                defaults: new { controller = "Comment", action = "Index", customerId = UrlParameter.Optional }
            );
            //routes.MapRoute(
            //    name: "ToReturnRequest",
            //    url: "{controller}/{action}/{customerId}",
            //    defaults: new { controller = "Order", action = "GetReturnRequest", customerId = UrlParameter.Optional }
            //);
            //routes.MapRoute(
            //    name: "ToReturnList",
            //    url: "{controller}/{action}/{customerId}",
            //    defaults: new { controller = "Order", action = "ReturnList", customerId = UrlParameter.Optional }
            //);
            //routes.MapRoute(
            //    name: "ToReturnHistoryList",
            //    url: "{controller}/{action}/{customerId}",
            //    defaults: new { controller = "Order", action = "ReturnHistory", customerId = UrlParameter.Optional }
            //);
            routes.MapRoute(
               name: "Default1",
               url: "{controller}/{action}/{admin}",
               defaults: new { controller = "Cart", action = "LoadCartList", admin = UrlParameter.Optional }
           );
            //routes.MapRoute(
            //   name: "DeleteAddress",
            //   url: "{controller}/{action}/{orderId}",
            //   defaults: new { controller = "Address", action = "DeleteAddress", orderId = UrlParameter.Optional }
            //);
        }
    }
}
