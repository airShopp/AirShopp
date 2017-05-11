using AirShopp.Domain;
using System.Web.Mvc;
using System.Linq;
using AirShopp.UI.Models;
using AirShopp.Common.Page;
using AirShopp.UI.Models.ViewModel;
using System.Collections.Generic;

namespace AirShopp.UI.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IReadFromDb _readFromDb;
        private readonly ICategoryRepository _categoryRepository;

        public InventoryController(
            IReadFromDb readFromDb,
            ICategoryRepository categoryRepository)
        {
            _readFromDb = readFromDb;
            _categoryRepository = categoryRepository;
        }
        // GET: Inventory
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetProductOutList(int? indexNum, int? pageSize)
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
                outList = outDataList
            };

            return View("ProductOut", outFactoryViewModel);
        }

        public ActionResult getAllInventoryProduct(int? indexNum, int? pageSize = 10)
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
            InventoryProductListViewModel productViewModel = new InventoryProductListViewModel()
            {
                PageIndex = inventoryProductList.PageIndex,
                TotalCount = inventoryProductList.TotalCount,
                TotalPage = inventoryProductList.TotalPage,
                pageBar = inventoryProductList.getPageBar(),
                productList = productListDataModel
                
            };

            return View("InventoryProductList", productViewModel);
        }
    }
}