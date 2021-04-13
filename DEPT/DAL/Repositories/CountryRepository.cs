using DEPT.DAL.Interfaces;
using DEPT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEPT.Services;
using Microsoft.Extensions.Options;

namespace DEPT.DAL.Repositories
{

    public class CountryRepository : ICountryRepository
    {
        CountryService service = new CountryService();
        public async Task<List<Country>> GetAllCountries()
        {
            return await Task.Run(() => service.GetAllCountries());
        }
        public async Task<Country> GetCountryByCode(string code)
        {
            return await Task.Run(() => service.GetCountryByCode(code));
        }
    }
}
