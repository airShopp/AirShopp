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

            bundles.Add(new ScriptBundle("~/bundles/AirShopp/JS").Include(
                "~/Scripts/knockout-3.4.2.js",
                "~/Scripts/Init/test.js",
                "~/Scripts/MainJS/jquery-1.8.2.min.js",
                "~/Scripts/MainJS/scripts.js",
                "~/Scripts/MainJS/supersized-init.js",
                "~/Scripts/MainJS/supersized.3.2.7.min.js"

                ));
            bundles.Add(new StyleBundle("~/bundles/AirShopp/Css").Include(
                "~/Content/Css/reset.css",
                "~/Content/Css/style.css",
                "~/Content/Css/supersized.css"

                ));
            bundles.Add(new StyleBundle("~/bundles/HomePage/Css").Include(
                "~/Content/Css/HomePage/bootstrap.css",
                "~/Content/Css/HomePage/style.css",
                "~/Content/Css/HomePage/megamenu.css"
                ));
            bundles.Add(new ScriptBundle("~/bundles/HomePage").Include(
                "~/Scripts/MainJS/HomePage/jquery-1.11.1.min.js",
                "~/Scripts/MainJS/HomePage/menu_jquery.js",
                "~/Scripts/MainJS/HomePage/megamenu.js",
                "~/Scripts/MainJS/HomePage/simpleCart.min.js",
                "~/Scripts/MainJS/HomePage/scripts.js",
                "~/Scripts/MainJS/HomePage/modernizr.custom.js",
                "~/Scripts/MainJS/HomePage/move-top.js",
                "~/Scripts/MainJS/HomePage/easing.js",
                "~/Scripts/MainJS/HomePage/jquery.flexisel.js"
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