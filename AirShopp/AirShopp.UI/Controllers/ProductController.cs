﻿using AirShopp.Common.Page;
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
        private readonly IReadFromDb _readFromDb;
        public ProductController(
            ICommentRepository commentRepository,
            IInventoryRepository inventoryRepository,
            IProductRepository productRepository,
            IOrderItemRepository orderItemRepository,
            IReadFromDb readFromDb
            )
        {
            _commentRepository = commentRepository;
            _inventoryRepository = inventoryRepository;
            _productRepository = productRepository;
            _orderItemRepository = orderItemRepository;
            _readFromDb = readFromDb;
        }
        // GET: ProductList
        public ActionResult GetProducts(int? indexNum, int? pageSize,int categoryId)
        {
            var products = GetProductList(indexNum,pageSize,categoryId);
            return View("ProductList", products);
        }

        //Get: Pagination/Ajax
        public ActionResult GetPageProduct(int? indexNum, int? pageSize, int categoryId)
        {
            var products = GetProductList(indexNum, pageSize, categoryId);
            return PartialView("ChildList",products);
        }
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
            List<CustomerCommentDataModel> commentList = new List<CustomerCommentDataModel>();
            foreach (var c in comment)
            {
                CustomerCommentDataModel customerComment = new CustomerCommentDataModel();
                customerComment.Comment = c;
            }
            ProductDetailViewModel detailViewModel = new ProductDetailViewModel
            {
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
        public ProductListViewModel GetProductList(int? indexNum, int? pageSize, int categoryId)
        {

            var productList = (from p in _readFromDb.Products
                               join d in _readFromDb.Discounts on p.Id equals d.ProductId
                               join c in _readFromDb.Categories on p.CategoryId equals c.Id
                               where c.Id == categoryId || c.ParentId == categoryId
                               let cm = _readFromDb.Comments.Where(c => c.ProductId == p.Id)
                               select new ProductListDataModel
                               {
                                   ProductId = p.Id,
                                   ProductName = p.ProductName,
                                   Price = Math.Round((double)p.Price, 2),
                                   Discounts = d.Discounts,
                                   DiscountPrice = Math.Round((double)((p.Price * d.Discounts) / 10), 2),
                                   CommentAmount = cm.Count(),
                                   ProductUrl = p.Url
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
                    ProductUrl = x.ProductUrl
                });
            });

            ProductListViewModel products = new ProductListViewModel()
            {
                PageIndex = paginationList.PageIndex,
                TotalPage = paginationList.TotalPage,
                CategoryId = categoryId,
                productList = pl,
                pageBar = paginationList.getPageBar()
            };
            return products;
        }
    }
}