using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<FamilyPosition> FamilyPositions { get; set; }
        public DbSet<Invalidity> Invalidities { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<AccountingRecordType> AccountingRecordTypes { get; set; }
        public DbSet<AccountingRecord> AccountingRecords { get; set; }
        public DbSet<DepositContract> DepositContracts { get; set; }
        public DbSet<AccountingEntry> AccountingEntries { get; set; }
        public DbSet<DepositType> DepositTypes { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<DepositRecord> DepositRecords { get; set; }
        public DbSet<AccountReport> AccountsReport { get; set; }
        public DbSet<EntryReport> EntriesReport { get; set; }
        public DbSet<BankDateTime> BankDateTime { get; set; }

        public DbSet<CreditContract> CreditContracts { get; set; }
        public DbSet<CreditRecord> CreditRecords { get; set; }
        public DbSet<CreditType> CreditTypes { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DepositRecord>()
                .HasKey(x => new { x.DepositContractId, x.RecordId });

            builder.Entity<DepositRecord>()
                .HasOne(x => x.DepositContract)
                .WithMany(x => x.DepositRecords)
                .HasForeignKey(x => x.DepositContractId);

            builder.Entity<DepositRecord>()
                .HasOne(x => x.Record)
                .WithMany(x => x.DepositRecords)
                .HasForeignKey(x => x.RecordId);

            builder.Entity<CreditRecord>()
                .HasKey(x => new { x.CreditContractId, x.RecordId });

            builder.Entity<CreditRecord>()
                .HasOne(x => x.CreditContract)
                .WithMany(x => x.CreditRecords)
                .HasForeignKey(x => x.CreditContractId);

            builder.Entity<CreditRecord>()
                .HasOne(x => x.Record)
                .WithMany(x => x.CreditRecords)
                .HasForeignKey(x => x.RecordId);

            builder.Entity<AccountReport>()
                .HasNoKey();

            builder.Entity<EntryReport>()
                .HasNoKey();
        }
    }
}