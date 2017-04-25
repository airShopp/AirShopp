using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Domain
{
    public class Comment
    {
        public Comment()
        {

        }

        public long Id { get; set; }
        public string Comments { get; set; }
        public DateTime CommentDate { get; set; }

        public long OrderId { get; set; }
        public virtual Order Order { get; set; }

        public long ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
