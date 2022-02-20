using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class database9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "MonthlyIncome",
                table: "Clients",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            var sql = @"ALTER PROCEDURE [dbo].[GetAccountsReport] 
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "MonthlyIncome",
                table: "Clients",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
