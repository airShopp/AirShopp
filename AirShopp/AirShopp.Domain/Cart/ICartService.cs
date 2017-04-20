﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Domain
{
    public interface ICartService
    {
        List<Cart> LoadCartList(long CustomerId);
        int GetProductAmoutByUser(long customerId);
    }
}
