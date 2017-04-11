using System;
using System.Collections;
using System.Collections.Generic;

namespace AirShopp.Domain
{
    public class Customer
    {
        public Customer()
        {
            Orders = new List<Order>();
            Carts = new List<Cart>();
        }

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

        public ICollection<Cart> Carts { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
