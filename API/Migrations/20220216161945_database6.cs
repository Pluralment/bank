using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class database6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountsReport",
                columns: table => new
                {
                    AccountingRecord = table.Column<int>(nullable: false),
                    Debt = table.Column<double>(nullable: false),
                    Credit = table.Column<double>(nullable: false),
                    Saldo = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                });

            var sp = @"CREATE PROCEDURE [dbo].[GetAccountsReport] 
                        AS
                        BEGIN
                        SELECT [AccountingRecord],
	                           [Debt],
	                           [Credit],
	                           [Credit] - [Debt] AS Saldo
                        FROM
                        (SELECT [Hasaplar].[Id] AS AccountingRecord,
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

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountsReport");
        }
    }
}
