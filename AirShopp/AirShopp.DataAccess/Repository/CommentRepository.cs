using AirShopp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.DataAccess
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AirShoppContext _context = new AirShoppContext();
        public void AddComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetCommentsByProductId(long productId)
        {
            var comments = _context.Comments.Where(c => c.ProductId == productId).ToList();
            return comments;
        }
    }
}
