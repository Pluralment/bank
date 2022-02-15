using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IDepositRepository
    {
        Task<DepositContract> CreateDeposit(DepositContract deposit);

        Task<DepositContract> CloseDeposit(DepositContract deposit);

        Task<DepositContract> GetDepositById(int id);


    }
}
