using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interfaces;

namespace API.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IClientRepository ClientRepository => new ClientRepository(_context);

        public ICityRepository CityRepository => new CityRepository(_context);

        public IFamilyPositionRepository FamilyPositionRepository => new FamilyPositionRepository(_context);

        public ICountryRepository CountryRepository => new CountryRepository(_context);

        public IInvalidityRepository InvalidityRepository => new InvalidityRepository(_context);

        public IDepositRepository DepositRepository => new DepositRepository(_context);

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }
    }
}