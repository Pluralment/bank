using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Interfaces
{
    public interface IInvalidityRepository
    {
        Task<IEnumerable<Invalidity>> GetInvalidityTypes();

        Task<Invalidity> GetInvalidityByName(string name);
    }
}