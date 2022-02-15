using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class database5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "DepositContracts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DepositContracts_ClientId",
                table: "DepositContracts",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_DepositContracts_Clients_ClientId",
                table: "DepositContracts",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepositContracts_Clients_ClientId",
                table: "DepositContracts");

            migrationBuilder.DropIndex(
                name: "IX_DepositContracts_ClientId",
                table: "DepositContracts");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "DepositContracts");
        }
    }
}
