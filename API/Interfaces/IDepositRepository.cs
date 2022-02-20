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

        Task<Currency> GetCurrencyById(int id);

        Task<DepositType> GetDepositTypeById(int id);

        Task<IEnumerable<AccountReport>> GetAccountsReport();

        Task<IEnumerable<EntryReport>> GetEntriesReport();

        Task CloseBankDay();

        Task DeliverSaldoToClients();

    }
}
