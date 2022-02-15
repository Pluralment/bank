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

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}