using AirShopp.Domain;
using System.Web.Mvc;
using System.Linq;
using AirShopp.UI.Models;
using AirShopp.Common.Page;
using AirShopp.UI.Models.ViewModel;
using System.Collections.Generic;
using AirShopp.UI.Controllers;
using System.Collections;
using AirShopp.UI.Models.request;
using System.Web;
using System;
using System.IO;
using AirShopp.Common;

namespace AirShopp.UI.Controllers
{
    public class InventoryController : FliterController
    {
        private readonly IReadFromDb _readFromDb;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryService _categoryService;
        private readonly IProviderRepository _providerRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IProductRepository _productRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IDiscountRepository _discountRepository;

        public InventoryController(
            IReadFromDb readFromDb,
            ICategoryRepository categoryRepository,
            ICategoryService categoryService,
            IProviderRepository providerRepository,
            IWarehouseRepository warehouseRepository,
            IProductRepository productRepository,
            IInventoryRepository inventoryRepository,
            IDiscountRepository discountRepository)
        {
            _readFromDb = readFromDb;
            _categoryRepository = categoryRepository;
            _categoryService = categoryService;
            _providerRepository = providerRepository;
            _warehouseRepository = warehouseRepository;
            _productRepository = productRepository;
            _inventoryRepository = inventoryRepository;
            _discountRepository = discountRepository;
        }
        //Get product out factory
        public ActionResult GetProductOutList(int? indexNum, int? pageSize = 6)
        {
            var productOutList = (from ia in _readFromDb.InventoryActions
                                  join i in _readFromDb.Inventories on ia.InventoryId equals i.Id
                                  join pof in _readFromDb.ProductOutFactories on ia.ProductOutFactoryId equals pof.Id
                                  join p in _readFromDb.Products on i.ProductId equals p.Id
                                  join c in _readFromDb.Customers on pof.CustomerId equals c.Id
                                  select new ProductOutDataModel()
                                  {
                                      ProductId = p.Id,
                                      ProductName = p.ProductName,
                                      CustomerId = c.Id,
                                      CustomerName = c.CustomerName,
                                      OutDate = pof.OutDate,
                                      PictureUrl = p.Url,
                                      SaleCount = pof.Amount,
                                      ProductCount = i.Amount,
                                      SalePrice = pof.UnitPrice
                                  }).OrderBy(x => x.OutDate).ToPagedList(indexNum,pageSize);

            List<ProductOutDataModel> outDataList = new List<ProductOutDataModel>();

            productOutList.ForEach(x => {
                outDataList.Add(new ProductOutDataModel() {
                    ProductName = x.ProductName,
                    CustomerId = x.CustomerId,
                    CustomerName = x.CustomerName,
                    OutDate = x.OutDate,
                    PictureUrl = x.PictureUrl,
                    ProductId = x.ProductId,
                    ProductCount =x.ProductCount,
                    SaleCount = x.SaleCount,
                    SalePrice = x.SalePrice
                });
            });
            ProductOutFactoryViewModel outFactoryViewModel = new ProductOutFactoryViewModel()
            {
                PageIndex = productOutList.PageIndex,
                TotalCount = productOutList.TotalCount,
                TotalPage = productOutList.TotalPage,
                outList = outDataList,
                pageBar = productOutList.getPageBar()
            };

            return View("ProductOut", outFactoryViewModel);
        }
        //Get product in factory
        public ActionResult GetProductInList(int? indexNum, int? pageSize)
        {
            var productInList = (from ia in _readFromDb.InventoryActions
                                  join i in _readFromDb.Inventories on ia.InventoryId equals i.Id
                                  join pif in _readFromDb.ProductInFactories on ia.ProductInFactoryId equals pif.Id
                                  join p in _readFromDb.Products on i.ProductId equals p.Id
                                  join w in _readFromDb.Warehouses on i.WarehouseId equals w.Id
                                  select new ProductInDataModel()
                                  {
                                      Amount = pif.Amount,
                                      Price = p.Price,
                                      ProductId = p.Id,
                                      ProductInDate = pif.InDate,
                                      ProductName = p.ProductName,
                                      warehouseName = w.Name,
                                      ProductUrl = p.Url
                                  }).OrderBy(x => x.ProductInDate).ToPagedList(indexNum, pageSize);
            List<ProductInDataModel> productDataList = new List<ProductInDataModel>();
            productInList.ForEach(x => {
                productDataList.Add(new ProductInDataModel()
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    warehouseName = x.warehouseName,
                    ProductInDate = x.ProductInDate,
                    Price = x.Price,
                    Amount = x.Amount,
                    ProductUrl = x.ProductUrl
                });
            });
            ProductInViewModel productInViewModel = new ProductInViewModel()
            {
                ProductDataList = productDataList,
                pageBar = productInList.getPageBar(),
                PageIndex = productInList.PageIndex,
                TotalCount = productInList.TotalCount,
                TotalPage = productInList.TotalPage
            };
            return View("ProductIn", productInViewModel);
        }

        public ActionResult getAllInventoryProduct(int? indexNum, int? pageSize = 6)
        {

            InventoryProductListViewModel productViewModel = GetInventoryProducts(indexNum, pageSize);

            return View("InventoryProductList", productViewModel);
        }
       
        [HttpPost]
        public ActionResult AddNewProduct(ProductRequestModel product, HttpPostedFileBase image)
        {
            var path = Request.MapPath("~/Content/" + product.categoryId);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var filePath = Path.Combine(path, Path.GetFileName(image.FileName));

            try
            {
                image.SaveAs(filePath);
            }
            catch
            {
                throw new Exception();
            }
            string imgPath = filePath.Substring(path.IndexOf("\\Content"));
            string RealPath = imgPath.Replace("\\", "/");
            Product p = new Product()
            {
                CategoryId = product.categoryId,
                IsOnSale = false,
                ProductionDate = product.productionTime,
                ProviderId = product.provider,
                Url = RealPath,
                KeepDate = product.keepTime,
                Price = product.price,
                ProductName = product.productName
            };
            long productId = _productRepository.AddProduct(p);

            //Add to ProductInFactory table
            ProductInFactory productInFactory = new ProductInFactory()
            {
                Amount = product.productCount,
                InDate = DateTime.UtcNow,
                Price = Convert.ToString(p.Price),
            };
            long productInFactoryId = _inventoryRepository.AddProductInFactory(productInFactory);

            //Add to Inventory table 
            Inventory inventory = new Inventory()
            {
                Amount = product.productCount,
                ProductId = productId,
                WarehouseId = product.warehouse,

            };
            long inventoryId = _inventoryRepository.AddInventory(inventory);


            //Add InventoryAction
            InventoryAction inventoryAction = new InventoryAction()
            {
                InventoryId = inventoryId,
                ProductInFactoryId = productInFactoryId
            };
            _inventoryRepository.AddInventoryAction(inventoryAction); 


            //Add to Discount table
            Discount discount = new Discount()
            {
                Discounts = Constants.DEFAULTDISCOUNT,
                IsUsed = false,
                ProductId = productId,
                StartTime = DateTime.UtcNow,
                EndTime = DateTime.UtcNow
            };
            
            _discountRepository.AddProductDiscount(discount);
            //InventoryProductListViewModel productViewModel = GetInventoryProducts(null,null);
            return RedirectToAction("getAllInventoryProduct","Inventory");
        }

        //Get Inventory Product View Data
        public InventoryProductListViewModel GetInventoryProducts(int? indexNum, int? pageSize = 6)
        {
            var inventoryProductList = (from i in _readFromDb.Inventories
                                        join w in _readFromDb.Warehouses on i.WarehouseId equals w.Id
                                        join p in _readFromDb.Products on i.ProductId equals p.Id
                                        join d in _readFromDb.Discounts on p.Id equals d.ProductId
                                        join pd in _readFromDb.Providers on p.ProviderId equals pd.Id
                                        join c in _readFromDb.Categories on p.CategoryId equals c.Id
                                        select new InventoryProductListDataModel()
                                        {
                                            ProductId = p.Id,
                                            ProductName = p.ProductName,
                                            ProductUrl = p.Url,
                                            Price = p.Price,
                                            IsOnSale = p.IsOnSale,
                                            KeepDate = p.KeepDate,
                                            ProductionDate = p.ProductionDate,
                                            Discount = d.Discounts,
                                            ProviderName = pd.ProviderName,
                                            WarehouseName = w.Name
                                        }).OrderBy(x => x.ProductionDate).ToPagedList(indexNum, pageSize);

            List<InventoryProductListDataModel> productListDataModel = new List<InventoryProductListDataModel>();
            inventoryProductList.ForEach(x =>
            {
                productListDataModel.Add(new InventoryProductListDataModel()
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    Discount = x.Discount,
                    IsOnSale = x.IsOnSale,
                    Price = x.Price,
                    KeepDate = x.KeepDate,
                    ProductionDate = x.ProductionDate,
                    ProductUrl = x.ProductUrl,
                    ProviderName = x.ProviderName,
                    WarehouseName = x.WarehouseName
                });
            });
            return new InventoryProductListViewModel()
            {
                PageIndex = inventoryProductList.PageIndex,
                TotalCount = inventoryProductList.TotalCount,
                TotalPage = inventoryProductList.TotalPage,
                pageBar = inventoryProductList.getPageBar(),
                productList = productListDataModel,
                categoryList = getCategoryList(),
                providerList = _providerRepository.getProvider(),
                warehouseList = _warehouseRepository.getWarehouseList()

            };
        }
        //Get Category
        public List<CategoryModel> getCategoryList()
        {
            var secondCategories = (from category in _categoryService.Categories()
                                    where category.ParentId > 0
                                    select new CategoryModel
                                    {
                                        Id = category.Id,
                                        CategoryName = category.CategoryName,
                                        ParentId = category.ParentId
                                    }).ToList();
            return secondCategories;
        }

        //Get InventoryProductDetail
        [HttpGet]
        public ActionResult GetInventoryProductDetail(long productId)
        {
            var inventoryProduct = (from d in _readFromDb.Discounts
                                    join p in _readFromDb.Products on d.ProductId equals p.Id
                                    where p.Id == productId
                                    select new InventoryProductDataModel()
                                    {
                                        ProductId = p.Id,
                                        ProductName = p.ProductName,
                                        Price = p.Price,
                                        ProductUrl = p.Url,
                                        IsOnSale = p.IsOnSale,
                                        Discounts = d.Discounts
                                    });
            InventoryProductViewModel productViewModel = new InventoryProductViewModel();
            productViewModel.productDataModel = inventoryProduct.FirstOrDefault();
            return Json(productViewModel, JsonRequestBehavior.AllowGet);
        }

        //POST Update product
        [HttpPost]
        public ActionResult UpdateProduct(ModifyProductRequestModel product, HttpPostedFileBase image)
        {
            string realPath = null;
            if (image != null)
            {
                var path = Request.MapPath("~/Content/" + product.productId);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var filePath = Path.Combine(path, Path.GetFileName(image.FileName));

                try
                {
                    image.SaveAs(filePath);
                }
                catch
                {
                    throw new Exception();
                }
                string imgPath = filePath.Substring(path.IndexOf("\\Content"));
                realPath = imgPath.Replace("\\", "/");
            }
            try
            {
                _discountRepository.UpdateProductDiscount(product.productId, product.discounts);
                _productRepository.UpdateProductInfo(product.productId, product.productName, realPath, product.isOnSale, product.price);
                var msg = "更新成功";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                var msg = "更新失败";
                return Json(msg, JsonRequestBehavior.AllowGet);
                throw;
            }
        }

        [HttpGet]
        public ActionResult DeleteProdct(long productId)
        {
            try
            {
                _productRepository.DeleteProduct(productId);
                return RedirectToAction("getAllInventoryProduct", "Inventory");
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}