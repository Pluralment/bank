﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220215130234_Fix-Tables-For-Deposit3")]
    partial class FixTablesForDeposit3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API.Models.AccountingEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FromId")
                        .HasColumnType("int");

                    b.Property<int?>("ToId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FromId");

                    b.HasIndex("ToId");

                    b.ToTable("AccountingEntries");
                });

            modelBuilder.Entity("API.Models.AccountingRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RecordTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecordTypeId");

                    b.ToTable("AccountingRecords");
                });

            modelBuilder.Entity("API.Models.AccountingRecordType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AccountingRecordTypes");
                });

            modelBuilder.Entity("API.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("API.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressOfResidence")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<string>("CellPhone")
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<int?>("CitizenId")
                        .HasColumnType("int");

                    b.Property<int?>("CityOfResidenceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<int?>("FamilyPositionId")
                        .HasColumnType("int");

                    b.Property<string>("FatherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("HomePhone")
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<string>("IdentifyNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<int?>("InvalidityId")
                        .HasColumnType("int");

                    b.Property<string>("IssuedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<DateTime>("IssuedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LivingAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<int?>("LivingCityId")
                        .HasColumnType("int");

                    b.Property<bool>("Military")
                        .HasColumnType("bit");

                    b.Property<decimal>("MonthlyIncome")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<string>("PassportNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<string>("PassportSerial")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<string>("PlaceOfWork")
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<bool>("Retired")
                        .HasColumnType("bit");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.HasKey("Id");

                    b.HasIndex("CitizenId");

                    b.HasIndex("CityOfResidenceId");

                    b.HasIndex("FamilyPositionId");

                    b.HasIndex("InvalidityId");

                    b.HasIndex("LivingCityId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("API.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("API.Models.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Ratio")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("API.Models.DepositContract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<int>("DepositTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("DepositTypeId");

                    b.ToTable("DepositContracts");
                });

            modelBuilder.Entity("API.Models.DepositRecord", b =>
                {
                    b.Property<int>("DepositContractId")
                        .HasColumnType("int");

                    b.Property<int>("RecordId")
                        .HasColumnType("int");

                    b.HasKey("DepositContractId", "RecordId");

                    b.HasIndex("RecordId");

                    b.ToTable("DepositRecords");
                });

            modelBuilder.Entity("API.Models.DepositType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Interest")
                        .HasColumnType("float");

                    b.Property<bool>("IsFixedInterest")
                        .HasColumnType("bit");

                    b.Property<double>("MaxContribution")
                        .HasColumnType("float");

                    b.Property<double>("MinContribution")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DepositTypes");
                });

            modelBuilder.Entity("API.Models.FamilyPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.HasKey("Id");

                    b.ToTable("FamilyPositions");
                });

            modelBuilder.Entity("API.Models.Invalidity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.HasKey("Id");

                    b.ToTable("Invalidities");
                });

            modelBuilder.Entity("API.Models.AccountingEntry", b =>
                {
                    b.HasOne("API.Models.AccountingRecord", "From")
                        .WithMany()
                        .HasForeignKey("FromId");

                    b.HasOne("API.Models.AccountingRecord", "To")
                        .WithMany()
                        .HasForeignKey("ToId");
                });

            modelBuilder.Entity("API.Models.AccountingRecord", b =>
                {
                    b.HasOne("API.Models.AccountingRecordType", "RecordType")
                        .WithMany()
                        .HasForeignKey("RecordTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.Models.Client", b =>
                {
                    b.HasOne("API.Models.Country", "Citizen")
                        .WithMany()
                        .HasForeignKey("CitizenId");

                    b.HasOne("API.Models.City", "CityOfResidence")
                        .WithMany()
                        .HasForeignKey("CityOfResidenceId");

                    b.HasOne("API.Models.FamilyPosition", "FamilyPosition")
                        .WithMany()
                        .HasForeignKey("FamilyPositionId");

                    b.HasOne("API.Models.Invalidity", "Invalidity")
                        .WithMany()
                        .HasForeignKey("InvalidityId");

                    b.HasOne("API.Models.City", "LivingCity")
                        .WithMany()
                        .HasForeignKey("LivingCityId");
                });

            modelBuilder.Entity("API.Models.DepositContract", b =>
                {
                    b.HasOne("API.Models.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.DepositType", "DepositType")
                        .WithMany()
                        .HasForeignKey("DepositTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.Models.DepositRecord", b =>
                {
                    b.HasOne("API.Models.DepositContract", "DepositContract")
                        .WithMany("DepositRecords")
                        .HasForeignKey("DepositContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.AccountingRecord", "Record")
                        .WithMany("DepositRecords")
                        .HasForeignKey("RecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}