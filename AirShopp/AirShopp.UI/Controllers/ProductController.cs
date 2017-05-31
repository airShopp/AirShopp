using AirShopp.Common.Page;
using AirShopp.Domain;
using AirShopp.UI.Models;
using AirShopp.UI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AirShopp.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IReadFromDb _readFromDb;
        public ProductController(
            ICommentRepository commentRepository,
            IInventoryRepository inventoryRepository,
            IProductRepository productRepository,
            IOrderItemRepository orderItemRepository,
            ICategoryRepository categoryRepository,
            IReadFromDb readFromDb
            )
        {
            _commentRepository = commentRepository;
            _inventoryRepository = inventoryRepository;
            _productRepository = productRepository;
            _orderItemRepository = orderItemRepository;
            _categoryRepository = categoryRepository;
            _readFromDb = readFromDb;
        }
        // GET: ProductList
        public ActionResult GetProducts(string queryStr,int? categoryId, int? indexNum, int? pageSize = 8)
        {
            if (queryStr == null)
            {
                queryStr = string.Empty;
            }
            var products = GetProductList(queryStr,categoryId, indexNum, pageSize );
            return View("ProductList", products);
        }

        //Get: Pagination/Ajax
        //public ActionResult GetPageProduct(int? indexNum, int? pageSize, int categoryId)
        //{
        //    var products = GetProductList(indexNum, pageSize, categoryId);
        //    return PartialView("ChildList", products);
        //}
        public ActionResult getProduct(long productId)
        {
            int salesAmount = 0;
            var productSales = _readFromDb.ProductSales
                .Where(ps => ps.ProductId == productId).FirstOrDefault();
            if (productSales != null)
            {
                salesAmount = productSales.SalesAmount;
            }

            var product = _productRepository.GetProductById(productId);
            var comment = _commentRepository.GetCommentsByProductId(productId);
            string categoryName = _categoryRepository.GetCategoryNameByProductId(productId);

            List<CustomerCommentDataModel> commentList = new List<CustomerCommentDataModel>();
            foreach (var c in comment)
            {
                CustomerCommentDataModel customerComment = new CustomerCommentDataModel();
                customerComment.Comment = c;
                commentList.Add(customerComment);
            }

            ProductDetailViewModel detailViewModel = new ProductDetailViewModel
            {
                CategoryName = categoryName,
                comments = commentList,
                ProductId = product.Id,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = Convert.ToDouble(product.Price),
                Sales = salesAmount,
                ProductUrl = product.Url.Split(',').ToList(),
                CommentAmount = comment.Count(),
                ProductAmount = _inventoryRepository.GetProductAmountByProductId(productId),
                BuyTime = _orderItemRepository.GetBuyTimeByProductId(productId),
            };
            return View("ProductDetail", detailViewModel);
        }
        public ProductListViewModel GetProductList(string queryStr, int? categoryId, int? indexNum, int? pageSize)
        {

            var productList = (from p in _readFromDb.Products
                               join d in _readFromDb.Discounts on p.Id equals d.ProductId
                               join c in _readFromDb.Categories on p.CategoryId equals c.Id
                               where p.IsOnSale == true
                               let cm = _readFromDb.Comments.Where(c => c.ProductId == p.Id)
                               select new ProductListDataModel
                               {
                                   ParentId = c.ParentId,
                                   CategoryId = c.Id,
                                   ProductId = p.Id,
                                   ProductName = p.ProductName,
                                   Price = Math.Round((double)p.Price, 2),
                                   Discounts = d.Discounts,
                                   DiscountPrice = Math.Round((double)((p.Price * d.Discounts) / 10), 2),
                                   CommentAmount = cm.Count(),
                                   ProductUrl = p.Url
                               });
            if (categoryId != null)
            {
                productList = productList.Where(c => (c.CategoryId == categoryId || c.ParentId == categoryId));
            }
            if (!string.IsNullOrEmpty(queryStr))
            {
                productList = productList.Where(plt => plt.ProductName.Contains(queryStr));
            }
            
            List<ProductListDataModel> pl = new List<ProductListDataModel>();
            var paginationList = productList.OrderBy(x => x.ProductId).ToPagedList(indexNum, pageSize);

            paginationList.ForEach(x => {
                pl.Add(new ProductListDataModel
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    Price = x.Price,
                    DiscountPrice = x.DiscountPrice,
                    Discounts = x.Discounts,
                    CommentAmount = x.CommentAmount,
                    ProductUrl = x.ProductUrl
                });
            });

            ProductListViewModel products = new ProductListViewModel()
            {
                queryStr = queryStr,
                PageIndex = paginationList.PageIndex,
                TotalPage = paginationList.TotalPage,
                CategoryId = categoryId,
                productList = pl,
                pageBar = paginationList.getPageBar()
            };
            return products;
        }


        public ActionResult FuzzyQuery(string queryStr,int? indexNum, int? pageSize = 8)
        {
            var productList = (from p in _readFromDb.Products
                               join d in _readFromDb.Discounts on p.Id equals d.ProductId
                               join c in _readFromDb.Categories on p.CategoryId equals c.Id
                               where p.ProductName.Contains(queryStr) && p.IsOnSale == true
                               let cm = _readFromDb.Comments.Where(c => c.ProductId == p.Id)
                               select new ProductListDataModel
                               {
                                   ProductId = p.Id,
                                   ProductName = p.ProductName,
                                   Price = Math.Round((double)p.Price, 2),
                                   Discounts = d.Discounts,
                                   DiscountPrice = Math.Round((double)((p.Price * d.Discounts) / 10), 2),
                                   CommentAmount = cm.Count(),
                                   ProductUrl = p.Url,
                                   CategoryId = c.Id
                               });

            List<ProductListDataModel> pl = new List<ProductListDataModel>();
            var paginationList = productList.OrderBy(x => x.ProductId).ToPagedList(indexNum, pageSize);

            paginationList.ForEach(x => {
                pl.Add(new ProductListDataModel
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    Price = x.Price,
                    DiscountPrice = x.DiscountPrice,
                    Discounts = x.Discounts,
                    CommentAmount = x.CommentAmount,
                    ProductUrl = x.ProductUrl,
                    CategoryId = x.CategoryId
                });
            });
            ProductListViewModel products = new ProductListViewModel()
            {
                PageIndex = paginationList.PageIndex,
                TotalPage = paginationList.TotalPage,
                productList = pl,
                pageBar = paginationList.getPageBar()
            };
            return View("ProductList", products);
        }
    }
}