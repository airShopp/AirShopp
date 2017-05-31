using AirShopp.Common;
using AirShopp.DataAccess;
using AirShopp.Domain;
using AirShopp.UI.Models;
using AirShopp.UI.Models.ViewModel;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System;
using AirShopp.Common.Page;

namespace AirShopp.UI.Controllers
{
    public class CartController : FliterController
    {
        private AirShoppContext db = new AirShoppContext();
        private ICartService _cartService;
        private ICartRepository _cartRepository;
        private ICartItemRepository _cartItemRepository;
        private IReadFromDb _readFromDb;
        public CartController(
            ICartService cartService,
            ICartRepository cartRepository,
            ICartItemRepository cartItemRepository,
            IReadFromDb readFromDb
            )
        {
            _cartService = cartService;
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _readFromDb = readFromDb;
        }

        public ActionResult LoadCartList(int? indexNum, int? pageSize = 6)
        {
           
            ShopCartViewModel shopCartViewModel = GetCartPageViewData(indexNum, pageSize);
            return View("ShopCart", shopCartViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [CheckLogin]
        [HttpPost]
        public ActionResult AddCart(long productId, int quanlity, decimal pricePerProduct)
        {
            var customer = Session["CUSTOMER"] as Customer;
            Cart cart = new Cart
            {
                CustomerId = customer.Id
            };
            try
            {
                var cartId = _cartRepository.AddCart(cart);
                CartItem cartItem = new CartItem()
                {
                    CartId = cartId,
                    ItemStatus = Constants.PENDING,
                    PricePerProduct = pricePerProduct,
                    Quantity = quanlity,
                    ProductId = productId
                };
                _cartItemRepository.AddCartItem(cartItem);
                return RedirectToAction("LoadCartList", "Cart");
                //ShopCartViewModel shopCartViewModel = GetCartPageViewData(null, null);
                //return View("ShopCart", shopCartViewModel);
            }
            catch (System.Exception)
            {
                throw;
            }
            
        }

        public ShopCartViewModel GetCartPageViewData(int? indexNum, int? pageSize)
        {
            var customer = Session["CUSTOMER"] as Customer;
            var cartProductList = (from ci in _readFromDb.CartItems
                                   join c in _readFromDb.Carts on ci.CartId equals c.Id
                                   join ct in _readFromDb.Customers on c.CustomerId equals ct.Id
                                   join p in _readFromDb.Products on ci.ProductId equals p.Id
                                   join d in _readFromDb.Discounts on p.Id equals d.ProductId
                                   where ct.Id == customer.Id && ci.ItemStatus == Constants.PENDING
                                   select new ShopCartDataModel()
                                   {
                                       Id = ci.Id,
                                       ProductId = p.Id,
                                       ProductName = p.ProductName,
                                       PictureUrl = p.Url,
                                       Price = p.Price * (d.Discounts/10),
                                       ProductAmount = ci.Quantity,
                                       ProductCredit = (int)Math.Floor(p.Price / 10),
                                       TotalPrice = (int)(p.Price * ci.Quantity)
                                   });
            var cartPagination = cartProductList.OrderBy(p => p.ProductId).ToPagedList(indexNum, pageSize);
            List<ShopCartDataModel> shopCartList = new List<ShopCartDataModel>();
            cartPagination.ForEach(cart => {
                shopCartList.Add(new ShopCartDataModel()
                {
                    PictureUrl = cart.PictureUrl,
                    Price = cart.Price,
                    ProductAmount = cart.ProductAmount,
                    ProductCredit = cart.ProductCredit,
                    ProductId = cart.ProductId,
                    ProductName = cart.ProductName,
                    TotalPrice = cart.TotalPrice,
                    Id = cart.Id
                });
            });
            return new ShopCartViewModel()
            {
                TotalPage = cartPagination.TotalPage,
                TotalCount = cartPagination.TotalCount,
                PageIndex = cartPagination.PageIndex,
                ShopCart = shopCartList,
                pageBar = cartPagination.getPageBar()
            };
        }
        public ActionResult DeleteCarts(string cartIdStr)
        {
            var CartIdArr = cartIdStr.Split(',');
            foreach (var cartId in CartIdArr)
            {
                _cartRepository.DeleteCartProduct(long.Parse(cartId));
            }
            return RedirectToAction("LoadCartList", "Cart");
            //ShopCartViewModel shopCartViewModel = GetCartPageViewData(null, null);
            //return View("ShopCart", shopCartViewModel);
        }
    }
}