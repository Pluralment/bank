using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class FixTablesForDeposit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Plans_RecordTypeId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Deposits_Currency_CurrencyId",
                table: "Deposits");

            migrationBuilder.DropForeignKey(
                name: "FK_Deposits_DepositTypes_DepositTypeId",
                table: "Deposits");

            migrationBuilder.DropForeignKey(
                name: "FK_Managements_Accounts_FromId",
                table: "Managements");

            migrationBuilder.DropForeignKey(
                name: "FK_Managements_Accounts_ToId",
                table: "Managements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plans",
                table: "Plans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Managements",
                table: "Managements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Deposits",
                table: "Deposits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.RenameTable(
                name: "Plans",
                newName: "AccountingRecordTypes");

            migrationBuilder.RenameTable(
                name: "Managements",
                newName: "AccountingEntries");

            migrationBuilder.RenameTable(
                name: "Deposits",
                newName: "DepositContracts");

            migrationBuilder.RenameTable(
                name: "Accounts",
                newName: "AccountingRecords");

            migrationBuilder.RenameIndex(
                name: "IX_Managements_ToId",
                table: "AccountingEntries",
                newName: "IX_AccountingEntries_ToId");

            migrationBuilder.RenameIndex(
                name: "IX_Managements_FromId",
                table: "AccountingEntries",
                newName: "IX_AccountingEntries_FromId");

            migrationBuilder.RenameIndex(
                name: "IX_Deposits_DepositTypeId",
                table: "DepositContracts",
                newName: "IX_DepositContracts_DepositTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Deposits_CurrencyId",
                table: "DepositContracts",
                newName: "IX_DepositContracts_CurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_RecordTypeId",
                table: "AccountingRecords",
                newName: "IX_AccountingRecords_RecordTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountingRecordTypes",
                table: "AccountingRecordTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountingEntries",
                table: "AccountingEntries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepositContracts",
                table: "DepositContracts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountingRecords",
                table: "AccountingRecords",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountingEntries_AccountingRecords_FromId",
                table: "AccountingEntries",
                column: "FromId",
                principalTable: "AccountingRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountingEntries_AccountingRecords_ToId",
                table: "AccountingEntries",
                column: "ToId",
                principalTable: "AccountingRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountingRecords_AccountingRecordTypes_RecordTypeId",
                table: "AccountingRecords",
                column: "RecordTypeId",
                principalTable: "AccountingRecordTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepositContracts_Currency_CurrencyId",
                table: "DepositContracts",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepositContracts_DepositTypes_DepositTypeId",
                table: "DepositContracts",
                column: "DepositTypeId",
                principalTable: "DepositTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountingEntries_AccountingRecords_FromId",
                table: "AccountingEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountingEntries_AccountingRecords_ToId",
                table: "AccountingEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountingRecords_AccountingRecordTypes_RecordTypeId",
                table: "AccountingRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_DepositContracts_Currency_CurrencyId",
                table: "DepositContracts");

            migrationBuilder.DropForeignKey(
                name: "FK_DepositContracts_DepositTypes_DepositTypeId",
                table: "DepositContracts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepositContracts",
                table: "DepositContracts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountingRecordTypes",
                table: "AccountingRecordTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountingRecords",
                table: "AccountingRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountingEntries",
                table: "AccountingEntries");

            migrationBuilder.RenameTable(
                name: "DepositContracts",
                newName: "Deposits");

            migrationBuilder.RenameTable(
                name: "AccountingRecordTypes",
                newName: "Plans");

            migrationBuilder.RenameTable(
                name: "AccountingRecords",
                newName: "Accounts");

            migrationBuilder.RenameTable(
                name: "AccountingEntries",
                newName: "Managements");

            migrationBuilder.RenameIndex(
                name: "IX_DepositContracts_DepositTypeId",
                table: "Deposits",
                newName: "IX_Deposits_DepositTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_DepositContracts_CurrencyId",
                table: "Deposits",
                newName: "IX_Deposits_CurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountingRecords_RecordTypeId",
                table: "Accounts",
                newName: "IX_Accounts_RecordTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountingEntries_ToId",
                table: "Managements",
                newName: "IX_Managements_ToId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountingEntries_FromId",
                table: "Managements",
                newName: "IX_Managements_FromId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Deposits",
                table: "Deposits",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plans",
                table: "Plans",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Managements",
                table: "Managements",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Plans_RecordTypeId",
                table: "Accounts",
                column: "RecordTypeId",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Deposits_Currency_CurrencyId",
                table: "Deposits",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Deposits_DepositTypes_DepositTypeId",
                table: "Deposits",
                column: "DepositTypeId",
                principalTable: "DepositTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Managements_Accounts_FromId",
                table: "Managements",
                column: "FromId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Managements_Accounts_ToId",
                table: "Managements",
                column: "ToId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
