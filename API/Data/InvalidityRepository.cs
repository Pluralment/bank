using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class InvalidityRepository : IInvalidityRepository
    {
        private readonly DataContext _context;

        public InvalidityRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Invalidity> GetInvalidityById(int id)
        {
            return await _context.Invalidities.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Invalidity> GetInvalidityByName(string name)
        {
            return await _context.Invalidities.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<IEnumerable<Invalidity>> GetInvalidityTypes()
        {
            return await _context.Invalidities.ToListAsync();
        }
    }
}