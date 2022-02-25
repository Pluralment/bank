using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DepositTypeRepository : IDepositTypeRepository
    {
        private readonly DataContext _context;
        public DepositTypeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DepositType>> GetDepositTypes()
        {
            return await _context.DepositTypes.ToListAsync();
        }
    }
}