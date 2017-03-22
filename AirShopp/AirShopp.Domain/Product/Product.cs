using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirShopp.Domain
{
    public class Product
    {
        public long Id { get; set; }
        public string ProductName { get; set; }
        public long CategoryId { get; set; }
        public long ProviderId { get; set; }
        public int Storage { get; set; }
        public DateTime ProductionDate { get; set; }
        public string KeepDate { get; set; }
        public decimal Price { get; set; }
        public int Supply { get; set; }

        [ForeignKey("CategoryId")]
        [Required()]
        public virtual Category category { get; set; }

        [ForeignKey("ProviderId")]
        [Required()]
        public virtual Provider provider { get; set; }
    }
}
