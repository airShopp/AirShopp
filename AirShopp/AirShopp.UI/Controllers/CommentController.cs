using AirShopp.Common;
using AirShopp.Domain;
using AirShopp.UI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirShopp.UI.Controllers
{
    public class CommentController : Controller
    {
        private ICommentService _commentService;
        private ICommentRepository _commentRepository;
        private IReadFromDb _readFromDb;

        public CommentController(ICommentService commentService, ICommentRepository commentRepository, IReadFromDb readFromDb)
        {
            _commentService = commentService;
            _commentRepository = commentRepository;
            _readFromDb = readFromDb;
        }
        // GET: Comment
        public ActionResult Index(long? orderId)
        {
            Customer customer = Session[Constants.SESSION_USER] as Customer;
            List<Comment> comments = _commentRepository.GetAllComment(customer.Id);
            CommentViewModel commentViewModel = new CommentViewModel();
            commentViewModel.CommentList = comments;
            OrderItem OrderItem = _readFromDb.OrderItems.Where(x => x.Id == orderId).FirstOrDefault();
            commentViewModel.OrderItem = OrderItem;
            if (OrderItem != null)
            {
                commentViewModel.OrderDate = _readFromDb.Orders.Where(x => x.Id == OrderItem.OrderId).First().OrderDate;
            }
            return View("AddComment", commentViewModel);
        }

        public ActionResult AddComment(long orderItemId, long productId, string commentStr)
        {
            Comment comment = new Comment();
            comment.OrderId = _readFromDb.OrderItems.Where(x => x.Id == orderItemId).First().OrderId;
            comment.ProductId = productId;
            comment.Comments = commentStr;
            comment.CommentDate = DateTime.Now;
            _commentRepository.AddComment(comment);
            return RedirectToAction("Index");
        }
    }
}