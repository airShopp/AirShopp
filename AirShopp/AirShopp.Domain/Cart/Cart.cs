using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Domain
{
    public class Cart
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public long ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public int Quantity { get; set; }
        public bool IsBuy { get; set; }
        public decimal ProductTotalAmount { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer customer { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product product { get; set; }
    }
}
