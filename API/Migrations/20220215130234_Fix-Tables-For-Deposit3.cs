using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class FixTablesForDeposit3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepositContracts_Currency_CurrencyId",
                table: "DepositContracts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Currency",
                table: "Currency");

            migrationBuilder.RenameTable(
                name: "Currency",
                newName: "Currencies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies",
                column: "Id");

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
                name: "IX_DepositRecords_RecordId",
                table: "DepositRecords",
                column: "RecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_DepositContracts_Currencies_CurrencyId",
                table: "DepositContracts",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepositContracts_Currencies_CurrencyId",
                table: "DepositContracts");

            migrationBuilder.DropTable(
                name: "DepositRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies");

            migrationBuilder.RenameTable(
                name: "Currencies",
                newName: "Currency");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Currency",
                table: "Currency",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DepositContracts_Currency_CurrencyId",
                table: "DepositContracts",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
