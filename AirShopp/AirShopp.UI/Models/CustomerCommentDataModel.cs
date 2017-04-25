using AirShopp.Domain;
using System.Collections.Generic;

namespace AirShopp.UI.Models
{
    public class CustomerCommentDataModel
    {
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public Comment Comment { get; set; }
    }
}