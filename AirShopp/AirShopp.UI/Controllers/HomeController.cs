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
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryService _categoryService;
        private readonly ICartService _cartService;
        private readonly IReadFromDb _readFromDb;

        public HomeController(
            ICategoryRepository categoryRepository,
            IProductRepository productRepository,
            ICategoryService categoryService,
            ICartService cartService,
            IReadFromDb readFromDb)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _categoryService = categoryService;
            _cartService = cartService;
            _readFromDb = readFromDb;
        }
        //
        public ActionResult Index(Customer customer)
         {
            var secondCategories = (from category in _categoryService.Categories()
                                    where category.ParentId > 0
                                    select new CategoryModel
                                    {
                                        Id = category.Id,
                                        CategoryName = category.CategoryName,
                                        ParentId = category.ParentId
                                    }).ToList();

            var hotProducts = (from P in _readFromDb.Products
                              join PS in _readFromDb.ProductSales on P.Id equals PS.ProductId
                              join D in _readFromDb.Discounts on P.Id equals D.ProductId
                              select new ProductDataModel
                              {
                                  ProductId = P.Id,
                                  ProductName = P.ProductName,
                                  Price = Math.Round((double)P.Price,2),
                                  DiscountPrice = Math.Round((double)((P.Price * D.Discounts) / 10), 2),
                                  Discounts = (double)D.Discounts,
                                  Sales = PS.SalesAmount,
                                  PictureUrl = P.url
                              }).OrderBy(hp => hp.Sales).Take(20).OrderBy(x => Guid.NewGuid()).Take(6).ToList();

            HomeViewModel homeViewModel = new HomeViewModel()
            {
                CartProductAccount = _cartService.GetProductAmoutByUser(customer.Id),
                Categories = _categoryRepository.GetCategories().ToList(),
                HotProducts = hotProducts,
                SecondCategories = secondCategories,
                TimeLimitProduct = GetTimeLimitProduct().OrderBy(x => Guid.NewGuid()).Take(8).ToList()
            };
            Session["Category"] = homeViewModel.Categories;
            return View(homeViewModel);
        }

        //Get
        public ActionResult GetHotProduct()
        {
            var hotProducts = (from P in _readFromDb.Products
                               join PS in _readFromDb.ProductSales on P.Id equals PS.ProductId
                               join D in _readFromDb.Discounts on P.Id equals D.ProductId
                               select new ProductDataModel
                               {
                                   ProductId = P.Id,
                                   ProductName = P.ProductName,
                                   Price = Math.Round((double)P.Price, 2),
                                   DiscountPrice = Math.Round((double)((P.Price * D.Discounts) / 10), 2),
                                   Discounts = (double)D.Discounts,
                                   Sales = PS.SalesAmount,
                                   PictureUrl = P.url
                               }).OrderBy(hp => hp.Sales).Take(20).OrderBy(x => Guid.NewGuid()).Take(6).ToList();

            HomeViewModel homeViewModel = new HomeViewModel()
            {
                HotProducts = hotProducts

            };
            return PartialView("HotProduct", homeViewModel);
        }

        //GetTimeLimitProduct
        public List<ProductDataModel> GetTimeLimitProduct()
        {
            var products = (from P in _readFromDb.Products
                            join D in _readFromDb.Discounts on P.Id equals D.ProductId
                            where P.url != "待定项" && D.Discounts < 10 && D.EndTime > DateTime.Now 
                            select new ProductDataModel
                            {
                                ProductId = P.Id,
                                ProductName = P.ProductName,
                                Price = Math.Round((double)P.Price, 2),
                                DiscountPrice = Math.Round((double)((P.Price * D.Discounts) / 10), 2),
                                Discounts = (double)D.Discounts,
                                DiscountStartTime = D.StartTime,
                                DiscountEndTime = D.EndTime,
                                PictureUrl = P.url
                            }).ToList(); ;
            return products;
        }
    }
}