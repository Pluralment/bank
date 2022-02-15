using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class database4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRevocable",
                table: "DepositTypes",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRevocable",
                table: "DepositTypes");
        }
    }
}
