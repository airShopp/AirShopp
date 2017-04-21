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

            var hotProducts = (from IA in _readFromDb.InventoryActions
                              join POF in _readFromDb.ProductOutFactories on IA.ProductOutFactoryId equals POF.Id
                              join I in _readFromDb.Inventories on IA.InventoryId equals I.Id
                              join P in _readFromDb.Products on I.ProductId equals P.Id
                              join D in _readFromDb.Discounts on P.Id equals D.ProductId
                              select new ProductDataModel
                              {
                                  ProductId = P.Id,
                                  ProductName = P.ProductName,
                                  Price = Math.Round((double)P.Price,2),
                                  DiscountPrice = Math.Round((double)((P.Price * D.Discounts) / 10), 2),
                                  Discounts = (double)D.Discounts,
                                  Sales = POF.Amount,
                                  PictureUrl = P.url
                              }).OrderBy(hp => hp.Sales).Take(20).OrderBy(x => Guid.NewGuid()).Take(6).ToList();

            HomeViewModel homeViewModel = new HomeViewModel()
            {
                CartProductAccount = _cartService.GetProductAmoutByUser(customer.Id),
                Categories = _categoryRepository.GetCategories().ToList(),
                HotProducts = hotProducts,
                SecondCategories = secondCategories,
                TimeLimitProduct = GetTimeLimitProduct()
            };
            Session["Category"] = homeViewModel.Categories;
            return View(homeViewModel);
        }

        //Get
        public ActionResult GetHotProduct()
        {
            var hotProducts = (from IA in _readFromDb.InventoryActions
                               join POF in _readFromDb.ProductOutFactories on IA.ProductOutFactoryId equals POF.Id
                               join I in _readFromDb.Inventories on IA.InventoryId equals I.Id
                               join P in _readFromDb.Products on I.ProductId equals P.Id
                               join D in _readFromDb.Discounts on P.Id equals D.ProductId
                               select new ProductDataModel
                               {
                                   ProductId = P.Id,
                                   ProductName = P.ProductName,
                                   Price = Math.Round((double)P.Price, 2),
                                   DiscountPrice = Math.Round((double)((P.Price * D.Discounts) / 10), 2),
                                   Discounts = (double)D.Discounts,
                                   Sales = POF.Amount,
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
            var products = (from IA in _readFromDb.InventoryActions
                            join POF in _readFromDb.ProductOutFactories on IA.ProductOutFactoryId equals POF.Id
                            join I in _readFromDb.Inventories on IA.InventoryId equals I.Id
                            join P in _readFromDb.Products on I.ProductId equals P.Id
                            join D in _readFromDb.Discounts on P.Id equals D.ProductId
                            where D.EndTime > DateTime.Now && D.StartTime < DateTime.Now
                            select new ProductDataModel
                            {
                                ProductId = P.Id,
                                ProductName = P.ProductName,
                                Price = Math.Round((double)P.Price, 2),
                                DiscountPrice = Math.Round((double)((P.Price * D.Discounts) / 10), 2),
                                Discounts = (double)D.Discounts,
                                Sales = POF.Amount,
                                DiscountStartTime = D.StartTime,
                                DiscountEndTime = D.EndTime,
                                PictureUrl = P.url
                            }).ToList();
            return products;
        }
    }
}