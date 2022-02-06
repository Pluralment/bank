using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class FamilyPositionRepository : IFamilyPositionRepository
    {
        private readonly DataContext _context;

        public FamilyPositionRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<FamilyPosition> GetFamilyPositionByName(string name)
        {
            return await _context.FamilyPositions.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<IEnumerable<FamilyPosition>> GetFamilyPositions()
        {
            return await _context.FamilyPositions.ToListAsync();
        }

        public async Task<FamilyPosition> GetFamilyPositionById(int id)
        {
            return await _context.FamilyPositions.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}