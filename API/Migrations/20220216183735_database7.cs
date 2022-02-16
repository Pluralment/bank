using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class database7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AccountingRecords",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "AccountingRecords",
                nullable: false,
                defaultValue: "");

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
            migrationBuilder.DropColumn(
                name: "Name",
                table: "AccountingRecords");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "AccountingRecords");
        }
    }
}
