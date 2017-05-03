using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirShopp.UI.Models
{
    public class LocationDataModel
    {
        public int status { get; set; }
        public Result Result { get; set; }
    }

    public class Result
    {
        public Location Location { get; set; }
        public int Precise { get; set; }
        public int Confidence { get; set; }
        public string Level { get; set; }
    }

    public class Location
    {
        public float Lng { get; set; }
        public float Lat { get; set; }
    }
}