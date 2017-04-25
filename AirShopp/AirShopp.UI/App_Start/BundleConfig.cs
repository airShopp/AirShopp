using System.Web;
using System.Web.Optimization;

namespace AirShopp.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/AirShopp/js").Include(
                "~/Scripts/js/index.js",
                "~/Scripts/js/jcarousellite.js",
                "~/Scripts/js/jquery.js",
                "~/Scripts/js/js-tab.js",
                "~/Scripts/js/MSClass.js",
                "~/Scripts/js/top.js",
                "~/Scripts/jquery.unobtrusive-ajax.js",
                "~/Scripts/jquery.validate.unobtrusive.js"
                ));
            bundles.Add(new StyleBundle("~/bundles/AirShopp/Css").Include(
                "~/Content/base.css",
                "~/Content/home.css",
                "~/Content/login.css",
                "~/Content/member.css"));
            //Layout
            bundles.Add(new StyleBundle("~/bundles/AirShopp/Layout").Include(
                "~/Content/base.css",
                "~/Content/home.css"
                ));
            //login
            bundles.Add(new StyleBundle("~/bundles/AirShopp/Login/Css").Include(
                "~/Content/base.css",
                "~/Content/login.css"
                ));
            bundles.Add(new ScriptBundle("~/bundles/AirShopp/Login/js").Include(
                "~/Scripts/js/jquery-3.1.1.min.js",
                "~/Scripts/js/checkcode.js"
                ));
            //Inventory page
            bundles.Add(new StyleBundle("~/bundles/AirShopp/Inventory/Css").Include(
                "~/Content/member.css"
                ));
            bundles.Add(new ScriptBundle("~/bundles/AirShopp/Inventory/js").Include(
                "~/Scripts/js/jquery"
                ));

            //Delivery
            bundles.Add(new StyleBundle("~/bundles/AirShopp/Delivery/Css").Include(
                "~/Content/TimeLine.css"
                ));
            bundles.Add(new ScriptBundle("~/bundles/AirShopp/Delivery/js").Include(
                "~/Scripts/js/LuShu.js",
                "~/Scripts/js/TimeLine.js",
                "~/Scripts/js/jquery.js",
                "~/Scripts/js/jquery.easing.js",
                "~/Scripts/js/jquery.mousewheel.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/AirShopp/Cart/js").Include(
                "~/Scripts/js/myCart.js"
                ));
            bundles.Add(new StyleBundle("~/bundles/AirShopp/Cart/Css").Include(
                "~/Content/myCart.css"
                ));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}