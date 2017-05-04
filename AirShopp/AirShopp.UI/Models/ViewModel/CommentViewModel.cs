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
        public Order Order { get; set; }
    }
}