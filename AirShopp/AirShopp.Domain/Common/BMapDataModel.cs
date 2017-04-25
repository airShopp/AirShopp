using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirShopp.Domain
{
    public class BMapDataModel
    {
        public int Status { get; set; }
        public List<Result> Result { get; set; }
        public string Message { get; set; }
    }

    public class Result
    {
        public Distance Distance { get; set; }
        public Duration Duration { get; set; }
    }

    public class Distance
    {
        public string Text { get; set; }
        public int Value { get; set; }
    }

    public class Duration
    {
        public string Text { get; set; }
        public int Value { get; set; }
    }
}