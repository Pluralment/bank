using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IDepositRepository
    {
        Task<Deposit> CreateDeposit(Deposit deposit);

        Task<Deposit> CloseDeposit(Deposit deposit);

    }
}
