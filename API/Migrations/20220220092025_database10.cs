using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class database10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BankDateTime",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BankDateTime",
                table: "BankDateTime",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BankDateTime",
                table: "BankDateTime");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BankDateTime");
        }
    }
}
