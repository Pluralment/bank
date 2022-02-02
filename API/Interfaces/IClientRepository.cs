using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Interfaces
{
    public interface IClientRepository
    {
        Task<Client> CreateClient(Client client);

        Task<IEnumerable<Client>> GetClientsAsync();

        Task<Client> GetClientByIdAsync(int id);

        void Update(Client client);

        void DeleteClient(Client client);
    }
}