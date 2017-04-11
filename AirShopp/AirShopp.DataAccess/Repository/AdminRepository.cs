using System;
using AirShopp.Domain;
using System.Linq;
using AirShopp.Common;

namespace AirShopp.DataAccess
{
    public class AdminRepository : IAdminRepository
    {
        public readonly AirShoppContext _context = new AirShoppContext();

        public Admin GetUser(string account, string password)
        {
            Admin admin = _context.Admin.FirstOrDefault(a => a.Account == account);
            if (admin == null)
            {
                throw new BaseException(MessageConstants.USER_NAME_ERROR);
            }
            if (admin.Password != password)
            {
                throw new BaseException(MessageConstants.PASSWORD_ERROR);
            }
            else
            {
                return _context.Admin.FirstOrDefault(a => a.Account == account && a.Password == password);
            }
        }
    }
}
