using System;

namespace AirShopp.Domain
{
    public class Customer
    {
        public long Id { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string CustomerCode { get; set; }
        public string Address { get; set; }
        public DateTime RegisterDate { get; set; }
        public string ZipCode { get; set; }
        public string TelephoneNo { get; set; }
        public bool Gender { get; set; }
        public string CustomerName { get; set; }
        public string CustomerLevel { get; set; }
        public int CustomerScore { get; set; }
    }
}
