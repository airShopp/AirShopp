using AirShopp.Domain;
using AirShopp.UI.Models;
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
        public readonly ICategoryService _categoryService;

        public HomeController(
            ICategoryRepository categoryRepository,
            IProductRepository productRepository,
            ICategoryService categoryService)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _categoryService = categoryService;
        }

        public ActionResult Index(Admin admin)
         {
            var secondCategories = (from category in _categoryService.Categories()
                                    where category.ParentId > 0
                                    select new CategoryModel
                                    {
                                        Id = category.Id,
                                        CategoryName = category.CategoryName,
                                        ParentId = category.ParentId
                                    }).ToList();
            HomeViewModel homeViewModel = new HomeViewModel()
            {
                Categories = _categoryRepository.GetCategories().ToList(),
                Products = _productRepository.Products(),
                SecondCategories = secondCategories

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