using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class FixTablesForDeposit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Plans_PlanId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Deposits_Clients_ClientId",
                table: "Deposits");

            migrationBuilder.DropForeignKey(
                name: "FK_Deposits_DepositTypes_TypeId",
                table: "Deposits");

            migrationBuilder.DropIndex(
                name: "IX_Deposits_ClientId",
                table: "Deposits");

            migrationBuilder.DropIndex(
                name: "IX_Deposits_TypeId",
                table: "Deposits");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_PlanId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Managements");

            migrationBuilder.DropColumn(
                name: "Sum",
                table: "Managements");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "DepositTypes");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Deposits");

            migrationBuilder.DropColumn(
                name: "ContractExpiry",
                table: "Deposits");

            migrationBuilder.DropColumn(
                name: "ContractNumber",
                table: "Deposits");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Deposits");

            migrationBuilder.DropColumn(
                name: "Percentage",
                table: "Deposits");

            migrationBuilder.DropColumn(
                name: "Sum",
                table: "Deposits");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Deposits");

            migrationBuilder.DropColumn(
                name: "ContractNumber",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "PlanId",
                table: "Accounts");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Plans",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Plans",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Plans",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "Managements",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Managements",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "Interest",
                table: "DepositTypes",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "IsFixedInterest",
                table: "DepositTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "MaxContribution",
                table: "DepositTypes",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MinContribution",
                table: "DepositTypes",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DepositTypes",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "Deposits",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "Deposits",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepositTypeId",
                table: "Deposits",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Deposits",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Deposits",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RecordTypeId",
                table: "Accounts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Ratio = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deposits_CurrencyId",
                table: "Deposits",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Deposits_DepositTypeId",
                table: "Deposits",
                column: "DepositTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_RecordTypeId",
                table: "Accounts",
                column: "RecordTypeId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropIndex(
                name: "IX_Deposits_CurrencyId",
                table: "Deposits");

            migrationBuilder.DropIndex(
                name: "IX_Deposits_DepositTypeId",
                table: "Deposits");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_RecordTypeId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Managements");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Managements");

            migrationBuilder.DropColumn(
                name: "Interest",
                table: "DepositTypes");

            migrationBuilder.DropColumn(
                name: "IsFixedInterest",
                table: "DepositTypes");

            migrationBuilder.DropColumn(
                name: "MaxContribution",
                table: "DepositTypes");

            migrationBuilder.DropColumn(
                name: "MinContribution",
                table: "DepositTypes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "DepositTypes");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Deposits");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Deposits");

            migrationBuilder.DropColumn(
                name: "DepositTypeId",
                table: "Deposits");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Deposits");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Deposits");

            migrationBuilder.DropColumn(
                name: "RecordTypeId",
                table: "Accounts");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Plans",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Code",
                table: "Plans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Plans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Managements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "Sum",
                table: "Managements",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "DepositTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Deposits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ContractExpiry",
                table: "Deposits",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ContractNumber",
                table: "Deposits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Deposits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Percentage",
                table: "Deposits",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Sum",
                table: "Deposits",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Deposits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ContractNumber",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PlanId",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Deposits_ClientId",
                table: "Deposits",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Deposits_TypeId",
                table: "Deposits",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_PlanId",
                table: "Accounts",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Plans_PlanId",
                table: "Accounts",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Deposits_Clients_ClientId",
                table: "Deposits",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Deposits_DepositTypes_TypeId",
                table: "Deposits",
                column: "TypeId",
                principalTable: "DepositTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
