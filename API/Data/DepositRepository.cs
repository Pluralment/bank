using API.Interfaces;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class DepositRepository : IDepositRepository
    {
        private readonly DataContext _context;
        public DepositRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<DepositContract> CreateDeposit(DepositContract deposit)
        {
            throw new NotImplementedException();
        }

        public async Task<DepositContract> CloseDeposit(DepositContract deposit)
        {
            throw new NotImplementedException();
        }
    }
}
