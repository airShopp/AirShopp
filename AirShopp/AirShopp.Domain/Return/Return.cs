using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Domain
{
    public class Return
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long OrderId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string ReturnReason { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public string CustomerName { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order order { get; set; }
    }
}
