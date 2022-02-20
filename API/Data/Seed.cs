using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Seed
    {

        public static async Task SeedClients(DataContext context)
        {
            if (await context.Clients.AnyAsync()) return;

            var clientsData = await System.IO.File.ReadAllTextAsync("Data/Seeds/ClientsSeedData.json");
            var clients = JsonSerializer.Deserialize<List<Client>>(clientsData);
            if (clients == null) return;

            foreach (var client in clients)
            {
                await context.Clients.AddAsync(client);
            }

            await context.SaveChangesAsync();
        }

        public static async Task SeedCities(DataContext context)
        {
            if (await context.Cities.AnyAsync()) return;

            var citiesData = await System.IO.File.ReadAllTextAsync("Data/Seeds/CitiesSeedData.json");
            var cities = JsonSerializer.Deserialize<List<City>>(citiesData);
            if (cities == null) return;

            foreach (var city in cities)
            {
                await context.Cities.AddAsync(city);
            }

            await context.SaveChangesAsync();
        }

        public static async Task SeedCountries(DataContext context)
        {
            if (await context.Countries.AnyAsync()) return;

            var countriesData = await System.IO.File.ReadAllTextAsync("Data/Seeds/CountriesSeedData.json");
            var countries = JsonSerializer.Deserialize<List<Country>>(countriesData);
            if (countries == null) return;

            foreach (var country in countries)
            {
                await context.Countries.AddAsync(country);
            }

            await context.SaveChangesAsync();
        }

        public static async Task SeedFamilyPositions(DataContext context)
        {
            if (await context.FamilyPositions.AnyAsync()) return;

            var familyPositionsData = await System.IO.File.ReadAllTextAsync("Data/Seeds/FamilyPositionsSeedData.json");
            var familyPositions = JsonSerializer.Deserialize<List<FamilyPosition>>(familyPositionsData);
            if (familyPositions == null) return;

            foreach (var familyPosition in familyPositions)
            {
                await context.FamilyPositions.AddAsync(familyPosition);
            }

            await context.SaveChangesAsync();
        }

        public static async Task SeedInvalidities(DataContext context)
        {
            if (await context.Invalidities.AnyAsync()) return;

            var invaliditiesData = await System.IO.File.ReadAllTextAsync("Data/Seeds/InvaliditiesSeedData.json");
            var invalidities = JsonSerializer.Deserialize<List<Invalidity>>(invaliditiesData);
            if (invalidities == null) return;

            foreach (var invalidity in invalidities)
            {
                await context.Invalidities.AddAsync(invalidity);
            }

            await context.SaveChangesAsync();
        }

        public static async Task SeedCurrencies(DataContext context)
        {
            if (await context.Currencies.AnyAsync()) return;

            var currenciesData = await System.IO.File.ReadAllTextAsync("Data/Seeds/CurrenciesSeedData.json");
            var currencies = JsonSerializer.Deserialize<List<Currency>>(currenciesData);
            if (currencies == null) return;

            foreach (var currency in currencies)
            {
                await context.Currencies.AddAsync(currency);
            }

            await context.SaveChangesAsync();
        }

        public static async Task SeedDepositTypes(DataContext context)
        {
            if (await context.DepositTypes.AnyAsync()) return;

            var depositTypesData = await System.IO.File.ReadAllTextAsync("Data/Seeds/DepositTypesSeedData.json");
            var depositTypes = JsonSerializer.Deserialize<List<DepositType>>(depositTypesData);
            if (depositTypes == null) return;

            foreach (var depositType in depositTypes)
            {
                await context.DepositTypes.AddAsync(depositType);
            }

            await context.SaveChangesAsync();
        }

        public static async Task SeedAccountingRecordTypes(DataContext context)
        {
            if (await context.AccountingRecordTypes.AnyAsync()) return;

            var accountingRecordTypesData = await System.IO.File.ReadAllTextAsync("Data/Seeds/AccountingRecordTypesSeedData.json");
            var accountingRecordTypes = JsonSerializer.Deserialize<List<AccountingRecordType>>(accountingRecordTypesData);
            if (accountingRecordTypes == null) return;

            foreach (var accountingRecordType in accountingRecordTypes)
            {
                await context.AccountingRecordTypes.AddAsync(accountingRecordType);
            }

            await context.SaveChangesAsync();
        }

        public static async Task SeedAccountingRecords(DataContext context)
        {
            if (await context.AccountingRecords.AnyAsync()) return;
            var cashBox = await context.AccountingRecordTypes.FirstOrDefaultAsync(x => x.Number == "1010");
            var bankFund = await context.AccountingRecordTypes.FirstOrDefaultAsync(x => x.Number == "7327");

            if (cashBox != null) await context.AccountingRecords.AddAsync(new AccountingRecord { RecordType = cashBox, Number = "1010562349658", Name = "Касса" });
            if (bankFund != null) await context.AccountingRecords.AddAsync(new AccountingRecord { RecordType = bankFund, Number = "7327796485223", Name = "Фонд развития банка" });
            await context.SaveChangesAsync();
        }

        public static async Task SeedBankDateTime(DataContext context)
        {
            if (await context.BankDateTime.AnyAsync())
            {
                return;
            }

            await context.BankDateTime.AddAsync(new BankDateTime()
            {
                DateTime = new DateTime(2000, 1, 1)
            });

            await context.SaveChangesAsync();
        }

        public static async Task SeedAccountingEntries(DataContext context)
        {
            if (await context.AccountingEntries.AnyAsync())
            {
                return;
            }

            await context.AccountingEntries.AddAsync(new AccountingEntry()
            {
                DateTime = context.BankDateTime.FirstOrDefault().DateTime
            });

            await context.SaveChangesAsync();
        }
    }
}