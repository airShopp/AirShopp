using AirShopp.Domain;
using AirShopp.UI.Models.ViewModel;
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
        // GET: Product
        public ActionResult Index()
        {
            var Category = Session["Category"];
            return View("ProductList");
        }
        public ActionResult getProduct(long productId)
        {

            var productSales = _readFromDb.ProductSales
                .Where(ps => ps.ProductId == productId).FirstOrDefault();
            var product = _productRepository.GetProductById(productId);
            var comment = _commentRepository.GetCommentsByProductId(productId);

            ProductDetailViewModel detailViewModel = new ProductDetailViewModel
            {
                ProductId = product.Id,
                ProductName = product.ProductName,
                Description = product.Description,
                Sales = productSales.SalesAmount,
                ProductUrl = product.url.Split(',').ToList(),
                CommentAmount = comment.Count(),
                ProductAmount = _inventoryRepository.GetProductAmountByProductId(productId),
                BuyTime = _orderItemRepository.GetBuyTimeByProductId(productId),
            };
            return View("ProductDetail", detailViewModel);
        }
        public ActionResult ShopCart()
        {
            return View();
        }
    }
}