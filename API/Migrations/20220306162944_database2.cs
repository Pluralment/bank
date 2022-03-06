using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class database2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreditTypes",
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
                    table.PrimaryKey("PK_CreditTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditContracts",
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
                    CreditTypeId = table.Column<int>(nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditContracts_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreditContracts_CreditTypes_CreditTypeId",
                        column: x => x.CreditTypeId,
                        principalTable: "CreditTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreditContracts_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreditRecords",
                columns: table => new
                {
                    CreditContractId = table.Column<int>(nullable: false),
                    RecordId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditRecords", x => new { x.CreditContractId, x.RecordId });
                    table.ForeignKey(
                        name: "FK_CreditRecords_CreditContracts_CreditContractId",
                        column: x => x.CreditContractId,
                        principalTable: "CreditContracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreditRecords_AccountingRecords_RecordId",
                        column: x => x.RecordId,
                        principalTable: "AccountingRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreditContracts_ClientId",
                table: "CreditContracts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditContracts_CreditTypeId",
                table: "CreditContracts",
                column: "CreditTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditContracts_CurrencyId",
                table: "CreditContracts",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditRecords_RecordId",
                table: "CreditRecords",
                column: "RecordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditRecords");

            migrationBuilder.DropTable(
                name: "CreditContracts");

            migrationBuilder.DropTable(
                name: "CreditTypes");
        }
    }
}
