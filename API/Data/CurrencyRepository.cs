using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly DataContext _context;
        public CurrencyRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Currency>> GetCurrencies()
        {
            return await _context.Currencies.ToListAsync();
        }
    }
}