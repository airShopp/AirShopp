﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Domain
{
    public interface IDiscountRepository
    {
        void AddProductDiscount(Discount discount);
        void UpdateProductDiscount(long productId, decimal discounts);
    }
}
