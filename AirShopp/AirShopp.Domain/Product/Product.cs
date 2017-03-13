using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Domain
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public virtual Category category { get; set; }

        [ForeignKey("ProviderId")]
        public virtual Provider provider { get; set; }
    }
}
