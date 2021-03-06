﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Domain
{
    public interface ICustomerRepository
    {
        Customer GetCustomer(string account, string password);
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        bool GetCustomer(string account);
    }
}
