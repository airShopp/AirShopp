using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Domain
{
    public interface ICategoryService
    {
        IQueryable<Category> Categories();
    }
}
