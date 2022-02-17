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
