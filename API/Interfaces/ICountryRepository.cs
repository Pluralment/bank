using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Interfaces
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetCountries();
        
        Task<Country> GetCountryByName(string name);

        Task<Country> GetCountryById(int id);
    }
}