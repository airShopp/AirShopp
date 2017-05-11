using AirShopp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirShopp.UI.Models.ViewModel
{
    public class CommentViewModel
    {
        public List<Comment> CommentList { get; set; }
        public OrderItem OrderItem { get; set; }

        public DateTime OrderDate { get; set; }
    }
}