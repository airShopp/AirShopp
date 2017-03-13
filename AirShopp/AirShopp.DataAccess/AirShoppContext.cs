using AirShopp.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.DataAccess
{
    public class AirShoppContext :DbContext
    {
        public AirShoppContext() : base("name = AirContext")
        {
        }
        public DbSet<User> User { get; set; }
    }
}
