using System;
using AirShopp.Domain;
using AirShopp.Common;
using System.Linq;

namespace AirShopp.DataAccess
{
    public class CustomerRepository : ICustomerRepository
    {
        public readonly AirShoppContext _context = new AirShoppContext();
        public Customer GetCustomer(string account, string password)
        {
            Customer customer = _context.Customer.FirstOrDefault(a => a.Account == account);
            if (customer == null)
            {
                throw new BaseException(MessageConstants.USER_NAME_ERROR);
            }
            if (customer.Password != password)
            {
                throw new BaseException(MessageConstants.PASSWORD_ERROR);
            }
            else
            {
                return _context.Customer.FirstOrDefault(a => a.Account == account && a.Password == password);
            }
        }
    }
}
