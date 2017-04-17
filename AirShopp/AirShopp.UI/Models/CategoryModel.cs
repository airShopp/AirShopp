using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirShopp.UI.Models
{
    public class CategoryModel
    {
        public long Id { get; set; }
        public string CategoryName { get; set; }
        public long ParentId { get; set; }
    }
}