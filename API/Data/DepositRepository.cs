﻿using API.Interfaces;
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
            var deposit = await _context.DepositContracts
                .Include(x => x.Currency)
                .Include(x => x.DepositType)
                .FirstOrDefaultAsync(x => x.Id == id);
            return deposit;
        }

        public async Task<DepositContract> CreateDeposit(DepositContract deposit)
        {
            // депозит
            var entry = await _context.DepositContracts.AddAsync(deposit);

            // открытие счетов (2)
            var mainAccount = new AccountingRecord()
            {
                RecordType = _context.AccountingRecordTypes.FirstOrDefault(x => x.Id == 1)
            };

            var percentAccount = new AccountingRecord()
            {
                RecordType = _context.AccountingRecordTypes.FirstOrDefault(x => x.Id == 2)
            };

            await _context.AccountingRecords.AddRangeAsync(mainAccount, percentAccount);
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
            var cash = _context.AccountingRecords.FirstOrDefault(x => x.Id == 3);
            var bank = _context.AccountingRecords.FirstOrDefault(x => x.Id == 4);

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
            var mainAccount = _context.AccountingRecords
                .FirstOrDefault(x => x.Id == 
                    _context.DepositRecords
                    .FirstOrDefault(x => x.DepositContract == deposit && x.Record.RecordType.Id == 0).RecordId);

            var percentAccount = _context.AccountingRecords
                .FirstOrDefault(x => x.Id ==
                    _context.DepositRecords
                    .FirstOrDefault(x => x.DepositContract == deposit && x.Record.RecordType.Id == 1).RecordId);

            var cash = _context.AccountingRecords.FirstOrDefault(x => x.Id == 3);
            var bank = _context.AccountingRecords.FirstOrDefault(x => x.Id == 4);



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
    }
}
