using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirShopp.Domain
{
    public class ProductIn
    {
        public int Id { get; set; }
        public long ProductId { get; set; }
        public int Amount { get; set; }
        public string Price { get; set; }
        public DateTime InDate { get; set; }

        [ForeignKey("ProductId")]
        [Required()]
        public Product Product { get; set; }
    }
}
