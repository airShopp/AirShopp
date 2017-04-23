using System;
using System.Collections;
using System.Collections.Generic;

namespace AirShopp.Domain
{
    public class Customer
    {
        public Customer()
        {
            RegisterDate = DateTime.Now;
            Orders = new List<Order>();
            Carts = new List<Cart>();
            Address = new List<Address>();
        }

        public long Id { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
        public string ZipCode { get; set; }
        public string TelephoneNo { get; set; }
        public bool Gender { get; set; }
        public string CustomerName { get; set; }
        public int CustomerScore { get; set; }

        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
