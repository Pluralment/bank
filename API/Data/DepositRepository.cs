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
                RecordType = _context.AccountingRecordTypes.FirstOrDefault(x => x.Number == "3014"),
                Name = $"{deposit.Client.Name} {deposit.Client.Surname}: текущий",
                Number = ""
            };

            var percentAccount = new AccountingRecord()
            {
                RecordType = _context.AccountingRecordTypes.FirstOrDefault(x => x.Number == "2400"),
                Name = $"{deposit.Client.Name} {deposit.Client.Surname}: процентный",
                Number = ""
            };

            await _context.AccountingRecords.AddAsync(mainAccount);
            await _context.AccountingRecords.AddAsync(percentAccount);
            await _context.SaveChangesAsync();
            
            mainAccount.Number = $"3014{mainAccount.Id.ToString().PadLeft(9, '0')}";
            percentAccount.Number = $"2400{percentAccount.Id.ToString().PadLeft(9, '0')}";

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
            var cash = _context.AccountingRecords.Include(x => x.RecordType).FirstOrDefault(x => x.RecordType.Number == "1010");
            var bank = _context.AccountingRecords.Include(x => x.RecordType).FirstOrDefault(x => x.RecordType.Number == "7327");

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
                    .FirstOrDefault(x => x.DepositContract == deposit && x.Record.RecordType.Number == "3014").Record.Id);

            var percentAccount = await _context.AccountingRecords.Include(x => x.RecordType)
                .FirstOrDefaultAsync(x => x.Id ==
                    _context.DepositRecords.Include(x => x.DepositContract).Include(x => x.Record)
                    .FirstOrDefault(x => x.DepositContract == deposit && x.Record.RecordType.Number == "2400").Record.Id);

            var cash = _context.AccountingRecords.Include(x => x.RecordType).FirstOrDefault(x => x.RecordType.Number == "1010");
            var bank = _context.AccountingRecords.Include(x => x.RecordType).FirstOrDefault(x => x.RecordType.Number == "7327");
            var dateTime = _context.BankDateTime.FirstOrDefault().DateTime;

            if (deposit.DepositType.IsRevocable && !deposit.IsClosed)
            {
                await _context.AccountingEntries.AddAsync(new AccountingEntry()
                {
                    DateTime = dateTime,
                    From = bank,
                    To = mainAccount,
                    Amount = deposit.Amount
                });

                deposit.IsClosed = true;
            }

            return _context.DepositContracts.FirstOrDefault(x => x.Id == deposit.Id);
        }

        public async Task<IEnumerable<AccountReport>> GetAccountsReport()
        {
            return await _context.AccountsReport.FromSqlRaw($"GetAccountsReport").ToListAsync();
        }

        public async Task<IEnumerable<EntryReport>> GetEntriesReport()
        {
            return await _context.EntriesReport.FromSqlRaw($"GetEntries").ToListAsync();
        }

        public async Task CloseBankDay()
        {
            var bank = await _context.AccountingRecords.FirstOrDefaultAsync(x => x.RecordType.Number == "7327");
            var cash = await _context.AccountingRecords.FirstOrDefaultAsync(x => x.RecordType.Number == "1010");
            var dateTime = (await _context.BankDateTime.FirstOrDefaultAsync()).DateTime;

            // Зачислить проценты
            await _context.DepositContracts.ForEachAsync(async contract =>
            {
                if (contract.IsClosed)
                {
                    return;
                }

                var mainAccount = _context.AccountingRecords
                    .FirstOrDefault(rec => rec == rec.DepositRecords.FirstOrDefault(d => d.Record.RecordType.Number == "3014").Record);
                var percentAccount = _context.AccountingRecords
                    .FirstOrDefault(rec => rec == rec.DepositRecords.FirstOrDefault(d => d.Record.RecordType.Number == "2400").Record);
                var interest = contract.DepositType.Interest;

                if (contract.StartDate >= dateTime && contract.EndDate <= dateTime)
                {
                    await _context.AccountingEntries.AddAsync(new AccountingEntry()
                    {
                        DateTime = dateTime,
                        Amount = (contract.Amount * (interest / 100)) / (DateTime.IsLeapYear(dateTime.Year) ? 366 : 365),
                        From = bank,
                        To = percentAccount,
                    });
                }
                else
                {
                    contract.IsClosed = true;
                    await _context.AccountingEntries.AddAsync(new AccountingEntry()
                    {
                        DateTime = dateTime,
                        Amount = contract.Amount,
                        From = bank,
                        To = mainAccount
                    });
                }
            });

            (await _context.BankDateTime.FirstOrDefaultAsync()).DateTime = dateTime.AddDays(1);
        }
    }
}
