using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _context;

        public ClientRepository(DataContext context) 
        {
            _context = context;
        }

        public async Task<Client> CreateClient(Client client)
        {
            var entry = await _context.Clients.AddAsync(client);
            return entry.Entity;
        }

        public void DeleteClient(Client client)
        {
            _context.Clients.Remove(client);
        }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            var client = await _context.Clients
                .Include(x => x.CityOfResidence).Include(x => x.LivingCity)
                .Include(x => x.FamilyPosition).Include(x => x.Citizen)
                .Include(x => x.Invalidity).FirstOrDefaultAsync(x => x.Id == id);
            return client;
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public void Update(Client client)
        {
            _context.Clients.Update(client);
        }
    }
}