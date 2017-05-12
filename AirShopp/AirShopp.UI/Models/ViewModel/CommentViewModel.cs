using AirShopp.Domain;
using AirShopp.UI.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirShopp.UI.Models.ViewModel
{
    public class CommentViewModel : PageListBaseModel
    {
        public List<CommentDataModel> CommentList { get; set; }
        public OrderItem OrderItem { get; set; }
        public DateTime OrderDate { get; set; }
    }

    public class CommentDataModel
    {
        public long ProductId { get; set; }
        public string ProductUrl { get; set; }
        public string ProductName { get; set; }
        public string Comments { get; set; }
        public DateTime CommentDate { get; set; }
    }
}