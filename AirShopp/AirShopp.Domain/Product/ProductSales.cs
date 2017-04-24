using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Domain
{
    public class ProductSales
    {
        public ProductSales()
        {

        }

        public long Id { get; set; }
        public long ProductId { get; set; }
        public int SalesAmount { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
