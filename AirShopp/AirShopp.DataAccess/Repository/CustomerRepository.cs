using System;
using AirShopp.Domain;
using AirShopp.Common;
using System.Linq;
using System.Data.Entity;

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
            if (!MathHelper.SHA1(customer.Password).Equals(password))
            {
                throw new BaseException(MessageConstants.PASSWORD_ERROR);
            }
            else
            {
                return customer;
            }
        }

        public void AddCustomer(Customer customer)
        {
            _context.Customer.Add(customer);
            _context.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Entry<Customer>(customer).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public bool GetCustomer(string account)
        {
            bool isExist = false;
            if (_context.Customer.Where(x => x.Account == account).ToList().Count > 0)
            {
                isExist = true;
            }
            return isExist;
        }
    }
}
