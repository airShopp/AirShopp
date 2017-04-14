using AirShopp.Domain;
using AirShopp.UI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirShopp.UI.Controllers
{
    public class HomeController : Controller
    {
        public readonly ICategoryRepository _categoryRepository;
        public readonly IProductRepository _productRepository;

        public HomeController(
            ICategoryRepository categoryRepository,
            IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public ActionResult Index(Admin admin)
         {
            string path = HttpRuntime.AppDomainAppPath.ToString()+$"/Content/HomePage/p4.jpg";
            string path1 = Server.MapPath("~/Content/Images/HomePage");
            string imgPath = path1.Substring(path1.IndexOf("Content"));
            HomeViewModel homeViewModel = new HomeViewModel()
            {
                Admin = admin,
                Categories = _categoryRepository.GetCategories(),
                Products = _productRepository.Products()

            };
            return View(homeViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}