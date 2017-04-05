using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AirShopp.Domain
{
    public class AdminService : IAdminService
    {

        public IAdminRepository _adminRepository;
        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }


        public Admin UserLogin(string account, string password)
        {
            return _adminRepository.GetUser(account, password);
        }
    }
}
