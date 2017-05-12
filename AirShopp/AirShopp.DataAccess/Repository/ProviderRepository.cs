using System;
using System.Collections.Generic;
using AirShopp.Domain;
using System.Linq;

namespace AirShopp.DataAccess
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly AirShoppContext _context = new AirShoppContext();

        public List<Provider> getProvider()
        {
            var providerList = _context.Provider.ToList();
            return providerList;
        }
    }
}
