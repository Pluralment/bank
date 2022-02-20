using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class database1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountingRecordTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountingRecordTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountsReport",
                columns: table => new
                {
                    AccountingRecord = table.Column<int>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Debt = table.Column<double>(nullable: false),
                    Credit = table.Column<double>(nullable: false),
                    Saldo = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "BankDateTime",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankDateTime", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Ratio = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepositTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Interest = table.Column<double>(nullable: false),
                    IsFixedInterest = table.Column<bool>(nullable: false),
                    MinContribution = table.Column<double>(nullable: false),
                    MaxContribution = table.Column<double>(nullable: false),
                    IsRevocable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepositTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntriesReport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    FromAccountName = table.Column<string>(nullable: true),
                    ToAccountName = table.Column<string>(nullable: true),
                    FromDebt = table.Column<double>(nullable: false),
                    FromCredit = table.Column<double>(nullable: false),
                    ToDebt = table.Column<double>(nullable: false),
                    ToCredit = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "FamilyPositions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyPositions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invalidities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invalidities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountingRecords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RecordTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountingRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountingRecords_AccountingRecordTypes_RecordTypeId",
                        column: x => x.RecordTypeId,
                        principalTable: "AccountingRecordTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    Surname = table.Column<string>(maxLength: 80, nullable: false),
                    FatherName = table.Column<string>(maxLength: 80, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<bool>(nullable: false),
                    PassportSerial = table.Column<string>(maxLength: 80, nullable: false),
                    PassportNumber = table.Column<string>(maxLength: 80, nullable: false),
                    IssuedBy = table.Column<string>(maxLength: 80, nullable: false),
                    IssuedDate = table.Column<DateTime>(nullable: false),
                    IdentifyNumber = table.Column<string>(maxLength: 80, nullable: false),
                    CityOfResidenceId = table.Column<int>(nullable: true),
                    AddressOfResidence = table.Column<string>(maxLength: 80, nullable: false),
                    HomePhone = table.Column<string>(maxLength: 80, nullable: true),
                    CellPhone = table.Column<string>(maxLength: 80, nullable: true),
                    Email = table.Column<string>(maxLength: 80, nullable: true),
                    PlaceOfWork = table.Column<string>(maxLength: 80, nullable: true),
                    Position = table.Column<string>(maxLength: 80, nullable: true),
                    LivingCityId = table.Column<int>(nullable: true),
                    LivingAddress = table.Column<string>(maxLength: 80, nullable: false),
                    FamilyPositionId = table.Column<int>(nullable: true),
                    CitizenId = table.Column<int>(nullable: true),
                    InvalidityId = table.Column<int>(nullable: true),
                    Retired = table.Column<bool>(nullable: false),
                    MonthlyIncome = table.Column<double>(nullable: false),
                    Military = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Countries_CitizenId",
                        column: x => x.CitizenId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clients_Cities_CityOfResidenceId",
                        column: x => x.CityOfResidenceId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clients_FamilyPositions_FamilyPositionId",
                        column: x => x.FamilyPositionId,
                        principalTable: "FamilyPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clients_Invalidities_InvalidityId",
                        column: x => x.InvalidityId,
                        principalTable: "Invalidities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clients_Cities_LivingCityId",
                        column: x => x.LivingCityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountingEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(nullable: false),
                    FromId = table.Column<int>(nullable: true),
                    ToId = table.Column<int>(nullable: true),
                    Amount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountingEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountingEntries_AccountingRecords_FromId",
                        column: x => x.FromId,
                        principalTable: "AccountingRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountingEntries_AccountingRecords_ToId",
                        column: x => x.ToId,
                        principalTable: "AccountingRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DepositContracts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    IsClosed = table.Column<bool>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    DepositTypeId = table.Column<int>(nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepositContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepositContracts_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepositContracts_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepositContracts_DepositTypes_DepositTypeId",
                        column: x => x.DepositTypeId,
                        principalTable: "DepositTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepositRecords",
                columns: table => new
                {
                    DepositContractId = table.Column<int>(nullable: false),
                    RecordId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepositRecords", x => new { x.DepositContractId, x.RecordId });
                    table.ForeignKey(
                        name: "FK_DepositRecords_DepositContracts_DepositContractId",
                        column: x => x.DepositContractId,
                        principalTable: "DepositContracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepositRecords_AccountingRecords_RecordId",
                        column: x => x.RecordId,
                        principalTable: "AccountingRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountingEntries_FromId",
                table: "AccountingEntries",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountingEntries_ToId",
                table: "AccountingEntries",
                column: "ToId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountingRecords_RecordTypeId",
                table: "AccountingRecords",
                column: "RecordTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CitizenId",
                table: "Clients",
                column: "CitizenId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CityOfResidenceId",
                table: "Clients",
                column: "CityOfResidenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_FamilyPositionId",
                table: "Clients",
                column: "FamilyPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_InvalidityId",
                table: "Clients",
                column: "InvalidityId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_LivingCityId",
                table: "Clients",
                column: "LivingCityId");

            migrationBuilder.CreateIndex(
                name: "IX_DepositContracts_ClientId",
                table: "DepositContracts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_DepositContracts_CurrencyId",
                table: "DepositContracts",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_DepositContracts_DepositTypeId",
                table: "DepositContracts",
                column: "DepositTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DepositRecords_RecordId",
                table: "DepositRecords",
                column: "RecordId");


            // CREATE STORED PROCEDURE
            var sql = @"CREATE PROCEDURE [dbo].[GetAccountsReport] 
                        AS
                        BEGIN
                        SELECT [AccountingRecord],
							   [Number],
							   [Name],
	                           [Debt],
	                           [Credit],
	                           [Credit] - [Debt] AS Saldo
                        FROM
                        (SELECT [Hasaplar].[Id] AS AccountingRecord,
								[Hasaplar].[Number],
								[Hasaplar].[Name],
		                        CASE WHEN [Planlar].[IsActive] = 1 THEN
			                        (SELECT ISNULL(SUM([AccountingEntries].[Amount]), 0)
			                        FROM [AccountingEntries]
			                        WHERE [AccountingEntries].[ToId] = [Hasaplar].[Id])
		                        ELSE
			                        (SELECT ISNULL(SUM([AccountingEntries].[Amount]), 0)
			                        FROM [AccountingEntries]
			                        WHERE [AccountingEntries].[FromId] = [Hasaplar].[Id])
		                        END AS Debt,

		                        CASE WHEN [Planlar].[IsActive] = 1 THEN
			                        (SELECT ISNULL(SUM([AccountingEntries].[Amount]), 0)
			                        FROM [AccountingEntries]
			                        WHERE [AccountingEntries].[FromId] = [Hasaplar].[Id])
		                        ELSE
			                        (SELECT ISNULL(SUM([AccountingEntries].[Amount]), 0)
			                        FROM [AccountingEntries]
			                        WHERE [AccountingEntries].[ToId] = [Hasaplar].[Id])
		                        END AS Credit
                        FROM [AccountingRecords] AS Hasaplar
                        LEFT JOIN [AccountingRecordTypes] AS Planlar
                        ON [Hasaplar].RecordTypeId = [Planlar].Id) AS HasapInfos
                        END";

            migrationBuilder.Sql(sql);


            var sp = @"CREATE PROCEDURE GetEntries 
					AS
					SELECT [Oborot].[Id] AS [Id],
						   [Oborot].[DateTime] AS [DateTime],
						   [FromAccount].[Name] AS FromAccountName,
						   [ToAccount].[Name] As ToAccountName,
						   CASE WHEN [Oborot].[FromId] IS NULL THEN
								0
								WHEN [FromTypes].[IsActive] = 1 THEN
								0
								ELSE
								[Oborot].[Amount]
						   END AS FromDebt,
						   CASE WHEN [Oborot].[FromId] IS NULL THEN
								0	
								WHEN [FromTypes].[IsActive] = 1 THEN
								[Oborot].[Amount]
								ELSE
								0
						   END AS FromCredit,
	   
						   CASE WHEN [Oborot].[ToId] IS NULL THEN
								0
								WHEN [ToTypes].[IsActive] = 1 THEN
								[Oborot].[Amount]
								ELSE
								0
						   END AS ToDebt,
						   CASE WHEN [Oborot].[ToId] IS NULL THEN
								0
								WHEN [ToTypes].[IsActive] = 1 THEN
								0
								ELSE
								[Oborot].[Amount]
						   END AS ToCredit
					FROM [AccountingEntries] AS [Oborot]
					LEFT JOIN [AccountingRecords] AS [FromAccount]
					ON [Oborot].[FromId] = [FromAccount].[Id]
					LEFT JOIN [AccountingRecords] AS [ToAccount]
					ON [Oborot].[ToId] = [ToAccount].[Id]
					LEFT JOIN [AccountingRecordTypes] AS [FromTypes]
					ON [FromTypes].[Id] = [FromAccount].[RecordTypeId]
					LEFT JOIN [AccountingRecordTypes] AS [ToTypes]
					ON [ToTypes].[Id] = [ToAccount].[RecordTypeId]";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountingEntries");

            migrationBuilder.DropTable(
                name: "AccountsReport");

            migrationBuilder.DropTable(
                name: "BankDateTime");

            migrationBuilder.DropTable(
                name: "DepositRecords");

            migrationBuilder.DropTable(
                name: "EntriesReport");

            migrationBuilder.DropTable(
                name: "DepositContracts");

            migrationBuilder.DropTable(
                name: "AccountingRecords");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "DepositTypes");

            migrationBuilder.DropTable(
                name: "AccountingRecordTypes");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "FamilyPositions");

            migrationBuilder.DropTable(
                name: "Invalidities");
        }
    }
}
