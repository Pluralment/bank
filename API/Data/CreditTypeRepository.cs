using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class CreditTypeRepository : ICreditTypeRepository
    {
        private readonly DataContext _context;
        public CreditTypeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CreditType>> GetCreditTypes()
        {
            return await _context.CreditTypes.ToListAsync();
        }
    }
}