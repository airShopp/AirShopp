using AirShopp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirShopp.UI.Models.ViewModel
{
    public class HomeViewModel
    {
        public Admin Admin { get; set; }
        public List<Category> Categories { get; set; }
    }
}