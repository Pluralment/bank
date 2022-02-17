using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class database8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntriesReport");
        }
    }
}
