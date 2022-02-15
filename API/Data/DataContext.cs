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
        }
    }
}