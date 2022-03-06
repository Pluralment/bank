using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class CreditRepository : ICreditRepository
    {
        private readonly DataContext _context;
        public CreditRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<CreditContract> CloseCredit(CreditContract credit)
        {
            var mainAccount = await _context.AccountingRecords.Include(x => x.RecordType)
                .FirstOrDefaultAsync(x => x.Id ==
                    _context.CreditRecords.Include(x => x.CreditContract).Include(x => x.Record)
                    .FirstOrDefault(x => x.CreditContract == credit && x.Record.RecordType.Number == "3014").Record.Id);

            var percentAccount = await _context.AccountingRecords.Include(x => x.RecordType)
                .FirstOrDefaultAsync(x => x.Id ==
                    _context.CreditRecords.Include(x => x.CreditContract).Include(x => x.Record)
                    .FirstOrDefault(x => x.CreditContract == credit && x.Record.RecordType.Number == "2400").Record.Id);

            var cash = _context.AccountingRecords.Include(x => x.RecordType).FirstOrDefault(x => x.RecordType.Number == "1010");
            var bank = _context.AccountingRecords.Include(x => x.RecordType).FirstOrDefault(x => x.RecordType.Number == "7327");
            var dateTime = _context.BankDateTime.FirstOrDefault().DateTime;

            if (credit.CreditType.IsRevocable && !credit.IsClosed)
            {
                await _context.AccountingEntries.AddAsync(new AccountingEntry()
                {
                    DateTime = dateTime,
                    From = null,
                    To = cash,
                    Amount = credit.Amount
                });
                await _context.AccountingEntries.AddAsync(new AccountingEntry()
                {
                    DateTime = dateTime,
                    From = cash,
                    To = mainAccount,
                    Amount = credit.Amount
                });
                await _context.AccountingEntries.AddAsync(new AccountingEntry()
                {
                    DateTime = dateTime,
                    From = mainAccount,
                    To = bank,
                    Amount = credit.Amount
                });

                credit.IsClosed = true;
            }

            return _context.CreditContracts.FirstOrDefault(x => x.Id == credit.Id);
        }

        public async Task<CreditContract> CreateCredit(CreditContract credit)
        {
            // кредит
            var entry = await _context.CreditContracts.AddAsync(credit);

            // открытие счетов (2)
            var mainAccount = new AccountingRecord()
            {
                RecordType = _context.AccountingRecordTypes.FirstOrDefault(x => x.Number == "3014"),
                Name = $"{credit.Client.Name} {credit.Client.Surname}: текущий",
                Number = ""
            };

            var percentAccount = new AccountingRecord()
            {
                RecordType = _context.AccountingRecordTypes.FirstOrDefault(x => x.Number == "2400"),
                Name = $"{credit.Client.Name} {credit.Client.Surname}: процентный",
                Number = ""
            };

            await _context.AccountingRecords.AddAsync(mainAccount);
            await _context.AccountingRecords.AddAsync(percentAccount);
            await _context.SaveChangesAsync();

            mainAccount.Number = $"3014{mainAccount.Id.ToString().PadLeft(9, '0')}";
            percentAccount.Number = $"2400{percentAccount.Id.ToString().PadLeft(9, '0')}";

            await _context.CreditRecords.AddAsync(new CreditRecord()
            {
                CreditContract = credit,
                Record = mainAccount
            });
            await _context.CreditRecords.AddAsync(new CreditRecord()
            {
                CreditContract = credit,
                Record = percentAccount
            });

            // Оборот
            var cash = _context.AccountingRecords.Include(x => x.RecordType).FirstOrDefault(x => x.RecordType.Number == "1010");
            var bank = _context.AccountingRecords.Include(x => x.RecordType).FirstOrDefault(x => x.RecordType.Number == "7327");

            await _context.AccountingEntries.AddAsync(new AccountingEntry()
            {
                Amount = credit.Amount,
                DateTime = credit.StartDate,
                From = bank,
                To = mainAccount
            });
            await _context.AccountingEntries.AddAsync(new AccountingEntry()
            {
                Amount = credit.Amount,
                DateTime = credit.StartDate,
                From = mainAccount,
                To = cash
            });
            await _context.AccountingEntries.AddAsync(new AccountingEntry()
            {
                Amount = credit.Amount,
                DateTime = credit.StartDate,
                From = cash,
                To = null
            });

            return entry.Entity;
        }

        public async Task<CreditContract> GetCreditById(int id)
        {
            return await _context.CreditContracts
                .Include(x => x.Currency)
                .Include(x => x.CreditType)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<CreditContract>> GetCreditList()
        {
            return await _context.CreditContracts
                .Include(x => x.Client)
                .Include(x => x.Currency)
                .Include(x => x.CreditType)
                .ToListAsync();
        }

        public async Task<IEnumerable<CreditContract>> GetCreditsByClientId(int id)
        {
            return await _context.CreditContracts
                .Include(x => x.Currency)
                .Include(x => x.CreditType)
                .Where(x => x.Client.Id == id).ToListAsync();
        }

        public async Task<CreditType> GetCreditTypeById(int id)
        {
            return await _context.CreditTypes.FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}
