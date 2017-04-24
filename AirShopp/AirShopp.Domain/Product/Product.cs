using System;
using System.Collections.Generic;

namespace AirShopp.Domain
{
    public class Product
    {
        public Product()
        {
            Comments = new List<Comment>();
            OrderItems = new List<OrderItem>();
            CartItems = new List<CartItem>();
            Inventories = new List<Inventory>();
            Discounts = new List<Discount>();
        }

        public long Id { get; set; }
        public string ProductName { get; set; }
        public DateTime ProductionDate { get; set; }
        public string KeepDate { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public bool IsOnSale { get; set; }

        public long CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public long ProviderId { get; set; }
        public virtual Provider Provider { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
        public ICollection<Inventory> Inventories { get; set; }
        public ICollection<Discount> Discounts { get; set; }
    }
}
