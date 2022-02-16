using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<DepositContract> GetDepositById(int id)
        {
            return await _context.DepositContracts
                .Include(x => x.Currency)
                .Include(x => x.DepositType)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Currency> GetCurrencyById(int id)
        {
            return await _context.Currencies.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<DepositType> GetDepositTypeById(int id)
        {
            return await _context.DepositTypes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<DepositContract> CreateDeposit(DepositContract deposit)
        {
            // депозит
            var entry = await _context.DepositContracts.AddAsync(deposit);

            // открытие счетов (2)
            var mainAccount = new AccountingRecord()
            {
                RecordType = _context.AccountingRecordTypes.FirstOrDefault(x => x.Id == 1),
                Name = $"{deposit.Client.Name} {deposit.Client.Surname}: текущий",
                Number = Guid.NewGuid().ToString()
            };

            var percentAccount = new AccountingRecord()
            {
                RecordType = _context.AccountingRecordTypes.FirstOrDefault(x => x.Id == 2),
                Name = $"{deposit.Client.Name} {deposit.Client.Surname}: процентный",
                Number = Guid.NewGuid().ToString()
            };

            mainAccount = (await _context.AccountingRecords.AddAsync(mainAccount)).Entity;
            percentAccount = (await _context.AccountingRecords.AddAsync(percentAccount)).Entity;

            await _context.DepositRecords.AddAsync(new DepositRecord()
            {
                DepositContract = deposit,
                Record = mainAccount
            });
            await _context.DepositRecords.AddAsync(new DepositRecord()
            {
                DepositContract = deposit,
                Record = percentAccount
            });

            // Оборот
            var cash = _context.AccountingRecords.Include(x => x.RecordType).FirstOrDefault(x => x.RecordType.Id == 3);
            var bank = _context.AccountingRecords.Include(x => x.RecordType).FirstOrDefault(x => x.RecordType.Id == 4);

            await _context.AccountingEntries.AddAsync(new AccountingEntry()
            {
                Amount = deposit.Amount,
                DateTime = deposit.StartDate,
                From = null,
                To = cash
            });
            await _context.AccountingEntries.AddAsync(new AccountingEntry()
            {
                Amount = deposit.Amount,
                DateTime = deposit.StartDate,
                From = cash,
                To = mainAccount
            });
            await _context.AccountingEntries.AddAsync(new AccountingEntry()
            {
                Amount = deposit.Amount,
                DateTime = deposit.StartDate,
                From = mainAccount,
                To = bank
            });

            return entry.Entity;
        }

        public async Task<DepositContract> CloseDeposit(DepositContract deposit)
        {
            var mainAccount = await _context.AccountingRecords.Include(x => x.RecordType)
                .FirstOrDefaultAsync(x => x.Id == 
                    _context.DepositRecords.Include(x => x.DepositContract).Include(x => x.Record)
                    .FirstOrDefault(x => x.DepositContract == deposit && x.Record.RecordType.Id == 1).Record.Id);

            var percentAccount = await _context.AccountingRecords.Include(x => x.RecordType)
                .FirstOrDefaultAsync(x => x.Id ==
                    _context.DepositRecords.Include(x => x.DepositContract).Include(x => x.Record)
                    .FirstOrDefault(x => x.DepositContract == deposit && x.Record.RecordType.Id == 2).Record.Id);

            var cash = _context.AccountingRecords.Include(x => x.RecordType).FirstOrDefault(x => x.RecordType.Id == 3);
            var bank = _context.AccountingRecords.Include(x => x.RecordType).FirstOrDefault(x => x.RecordType.Id == 4);



            if (!deposit.DepositType.IsRevocable)
            {
                await _context.AccountingEntries.AddAsync(new AccountingEntry()
                {
                    DateTime = deposit.EndDate,
                    From = bank,
                    To = percentAccount,
                    Amount = deposit.Amount * deposit.DepositType.Interest * 0.01
                });
                await _context.AccountingEntries.AddAsync(new AccountingEntry()
                {
                    DateTime = deposit.EndDate,
                    From = bank,
                    To = mainAccount,
                    Amount = deposit.Amount
                });
                await _context.AccountingEntries.AddAsync(new AccountingEntry()
                {
                    DateTime = deposit.EndDate,
                    From = percentAccount,
                    To = cash,
                    Amount = deposit.Amount * deposit.DepositType.Interest * 0.01
                });
                await _context.AccountingEntries.AddAsync(new AccountingEntry()
                {
                    DateTime = deposit.EndDate,
                    From = mainAccount,
                    To = cash,
                    Amount = deposit.Amount
                });
                await _context.AccountingEntries.AddAsync(new AccountingEntry()
                {
                    DateTime = deposit.EndDate,
                    From = cash,
                    To = null,
                    Amount = deposit.Amount * deposit.DepositType.Interest * 0.01
                });
                await _context.AccountingEntries.AddAsync(new AccountingEntry()
                {
                    DateTime = deposit.EndDate,
                    From = cash,
                    To = null,
                    Amount = deposit.Amount
                });
            }

            return _context.DepositContracts.FirstOrDefault(x => x.Id == deposit.Id);
        }

        public async Task<IEnumerable<AccountReport>> GetAccountsReport()
        {
            return await _context.AccountsReport.FromSqlRaw($"GetAccountsReport").ToListAsync();
        }
    }
}
