using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Domain
{
    public class Comment
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public string Comments { get; set; }
        public DateTime CommentDate { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
