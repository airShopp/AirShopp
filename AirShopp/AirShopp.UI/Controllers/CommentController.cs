using AirShopp.Domain;
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

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddComment(Comment comment)
        {
            _commentService.AddComment(comment);
            return View();
        }
    }
}