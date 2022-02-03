using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class CityRepository : ICityRepository
    {
        private readonly DataContext _context;
        public CityRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<City> CreateCity(City city)
        {
            var entry = await _context.Cities.AddAsync(city);
            return entry.Entity;
        }

        public void DeleteCity(City city)
        {
            _context.Cities.Remove(city);
        }

        public async Task<IEnumerable<City>> GetCities()
        {
            return await _context.Cities.ToListAsync();
        }

        public async Task<City> GetCity(int id)
        {
            return await _context.Cities.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(City city)
        {
            _context.Cities.Update(city);
        }
    }
}