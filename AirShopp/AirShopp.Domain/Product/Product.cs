﻿using System;
using System.Collections.Generic;

namespace AirShopp.Domain
{
    public class Product
    {
        public long Id { get; set; }
        public string ProductName { get; set; }
        public long CategoryId { get; set; }
        public long ProviderId { get; set; }
        //public int InventoryId { get; set; }

        //public int Storage { get; set; }
        public DateTime ProductionDate { get; set; }
        public string KeepDate { get; set; }
        public decimal Price { get; set; }
        public int Supply { get; set; }

        public virtual Category Category { get; set; }
        public virtual Provider Provider { get; set; }
        //public virtual Inventory Inventory { get; set; }

        public ICollection<Cart> Carts { get; set; }
        public ICollection<Inventory> Inventories { get; set; }

    }
}