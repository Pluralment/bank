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
        IFamilyPositionRepository FamilyPositionRepository { get; }
        ICountryRepository CountryRepository { get; }
        IInvalidityRepository InvalidityRepository { get; }
        IDepositRepository DepositRepository { get; }
        Task<bool> Complete();

        bool HasChanges();
    }
}