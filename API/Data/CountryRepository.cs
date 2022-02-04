using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _context;
        public CountryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> GetCountries()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Country> GetCountryByName(string name)
        {
            return await _context.Countries.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}