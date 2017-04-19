﻿using AirShopp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirShopp.UI.Models.ViewModel
{
    public class OriginPointsViewModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Remark { get; set; }

        public OriginPointsViewModel(string name, string address, double longitude, double latitude, string remark)
        {
            Name = name;
            Address = address;
            Longitude = longitude;
            Latitude = latitude;
            Remark = remark;
        }
    }
}