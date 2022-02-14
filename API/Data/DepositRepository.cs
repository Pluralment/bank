using API.Interfaces;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class DepositRepository : IDepositRepository
    {
        private readonly DataContext _context;
        public DepositRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Deposit> CreateDeposit(Deposit deposit)
        {
            // Deposit
            var entry = await _context.Deposits.AddAsync(deposit);

            // Create Accounts
            await _context.Accounts.AddAsync(new Account()
            {
                ContractNumber = deposit.ContractNumber,
                Number = Guid.NewGuid().ToString(),
                Plan = _context.Plans.FirstOrDefault(x => x.Code == 11)
            });
            await _context.Accounts.AddAsync(new Account()
            {
                ContractNumber = deposit.ContractNumber,
                Number = Guid.NewGuid().ToString(),
                Plan = _context.Plans.FirstOrDefault(x => x.Code == 12)
            });

            // Management
            await _context.Managements.AddAsync(new Management()
            {
                Date = deposit.StartDate,
                From = null,
                To = _context.Accounts.FirstOrDefault(x => x.Number == "5000"),
                Sum = deposit.Sum
            });
            await _context.Managements.AddAsync(new Management()
            {
                Date = deposit.StartDate,
                From = _context.Accounts.FirstOrDefault(x => x.Number == "5000"),
                To = _context.Accounts.FirstOrDefault(x => x.ContractNumber == deposit.ContractNumber && x.Plan.Code == 11),
                Sum = deposit.Sum
            });
            await _context.Managements.AddAsync(new Management()
            {
                Date = deposit.StartDate,
                From = _context.Accounts.FirstOrDefault(x => x.ContractNumber == deposit.ContractNumber && x.Plan.Code == 11),
                To = _context.Accounts.FirstOrDefault(x => x.Number == "9000"),
                Sum = deposit.Sum
            });


            return entry.Entity;
        }

        public async Task<Deposit> CloseDeposit(Deposit deposit)
        {
            await _context.Managements.AddAsync(new Management()
            {
                Date = deposit.StartDate,
                From = _context.Accounts.FirstOrDefault(x => x.Number == "9000"),
                To = _context.Accounts.FirstOrDefault(x => x.ContractNumber == deposit.ContractNumber && x.Plan.Code == 12),
                Sum = deposit.Sum * deposit.Percentage * (deposit.EndDate - deposit.StartDate).TotalDays
            });
            await _context.Managements.AddAsync(new Management()
            {
                Date = deposit.StartDate,
                From = _context.Accounts.FirstOrDefault(x => x.Number == "9000"),
                To = _context.Accounts.FirstOrDefault(x => x.ContractNumber == deposit.ContractNumber && x.Plan.Code == 11),
                Sum = deposit.Sum
            });
            await _context.Managements.AddAsync(new Management()
            {
                Date = deposit.StartDate,
                From = _context.Accounts.FirstOrDefault(x => x.ContractNumber == deposit.ContractNumber && x.Plan.Code == 12),
                To = _context.Accounts.FirstOrDefault(x => x.Number == "5000"),
                Sum = deposit.Sum * deposit.Percentage * (deposit.EndDate - deposit.StartDate).TotalDays
            });
            await _context.Managements.AddAsync(new Management()
            {
                Date = deposit.StartDate,
                From = _context.Accounts.FirstOrDefault(x => x.ContractNumber == deposit.ContractNumber && x.Plan.Code == 11),
                To = _context.Accounts.FirstOrDefault(x => x.Number == "5000"),
                Sum = deposit.Sum
            });
            await _context.Managements.AddAsync(new Management()
            {
                Date = deposit.StartDate,
                From = _context.Accounts.FirstOrDefault(x => x.Number == "5000"),
                To = null,
                Sum = deposit.Sum * deposit.Percentage * (deposit.EndDate - deposit.StartDate).TotalDays
            });
            await _context.Managements.AddAsync(new Management()
            {
                Date = deposit.StartDate,
                From = _context.Accounts.FirstOrDefault(x => x.Number == "5000"),
                To = null,
                Sum = deposit.Sum,
            });

            return deposit;
        }
    }
}
