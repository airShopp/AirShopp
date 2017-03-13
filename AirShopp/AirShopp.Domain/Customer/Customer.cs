using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Domain
{
    public class Customer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
    }
}
