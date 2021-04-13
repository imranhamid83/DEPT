using DEPT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEPT.DAL.Interfaces
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAllCountries();

        Task<Country> GetCountryByCode(string code);
    }
}
