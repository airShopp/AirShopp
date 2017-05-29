using AirShopp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirShopp.UI.Models.ViewModel
{
    public class OriginPointViewModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public OriginPointViewModel()
        {

        }

        public OriginPointViewModel(string name, string address, double longitude, double latitude)
        {
            Name = name;
            Address = address;
            Longitude = longitude;
            Latitude = latitude;
        }
    }

    public class DeliveryInfoViewModel
    {
        public string Description { get; set; }
        public DateTime UpdateTime { get; set; }
        public DeliveryInfoViewModel()
        {

        }
        public DeliveryInfoViewModel(string description, DateTime updateTime)
        {
            Description = description;
            UpdateTime = updateTime;
        }
    }

    public class BMapViewModel
    {
        public List<OriginPointViewModel> OriginPoints { get; set; }
        public List<DeliveryInfoViewModel> DeliveryInfos { get; set; }
        public Order Order { get; set; }
    }
}