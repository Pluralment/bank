using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;

namespace API.Interfaces
{
    public interface IUnitOfWork
    {
        IClientRepository ClientRepository { get; }
        ICityRepository CityRepository { get; }

        Task<bool> Complete();

        bool HasChanges();
    }
}