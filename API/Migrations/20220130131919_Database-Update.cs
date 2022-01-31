using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class DatabaseUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamilyPositions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyPositions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invalidities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invalidities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    Surname = table.Column<string>(maxLength: 80, nullable: false),
                    FatherName = table.Column<string>(maxLength: 80, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<bool>(maxLength: 80, nullable: false),
                    PassportSerial = table.Column<string>(maxLength: 80, nullable: false),
                    PassportNumber = table.Column<string>(maxLength: 80, nullable: false),
                    IssuedBy = table.Column<string>(maxLength: 80, nullable: false),
                    IssuedDate = table.Column<DateTime>(nullable: false),
                    IdentifyNumber = table.Column<string>(maxLength: 80, nullable: false),
                    CityOfResidenceId = table.Column<int>(nullable: true),
                    AddressOfResidence = table.Column<string>(maxLength: 80, nullable: false),
                    HomePhone = table.Column<string>(maxLength: 80, nullable: true),
                    CellPhone = table.Column<string>(maxLength: 80, nullable: true),
                    Email = table.Column<string>(maxLength: 80, nullable: true),
                    PlaceOfWork = table.Column<string>(maxLength: 80, nullable: true),
                    Position = table.Column<string>(maxLength: 80, nullable: true),
                    LivingCityId = table.Column<int>(nullable: true),
                    LivingAddress = table.Column<string>(maxLength: 80, nullable: false),
                    FamilyPositionId = table.Column<int>(nullable: true),
                    CitizenId = table.Column<int>(nullable: true),
                    InvalidityId = table.Column<int>(nullable: true),
                    Retired = table.Column<bool>(maxLength: 80, nullable: false),
                    MonthlyIncome = table.Column<decimal>(maxLength: 80, nullable: false),
                    Military = table.Column<bool>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Countries_CitizenId",
                        column: x => x.CitizenId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clients_Cities_CityOfResidenceId",
                        column: x => x.CityOfResidenceId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clients_FamilyPositions_FamilyPositionId",
                        column: x => x.FamilyPositionId,
                        principalTable: "FamilyPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clients_Invalidities_InvalidityId",
                        column: x => x.InvalidityId,
                        principalTable: "Invalidities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clients_Cities_LivingCityId",
                        column: x => x.LivingCityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CitizenId",
                table: "Clients",
                column: "CitizenId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CityOfResidenceId",
                table: "Clients",
                column: "CityOfResidenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_FamilyPositionId",
                table: "Clients",
                column: "FamilyPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_InvalidityId",
                table: "Clients",
                column: "InvalidityId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_LivingCityId",
                table: "Clients",
                column: "LivingCityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "FamilyPositions");

            migrationBuilder.DropTable(
                name: "Invalidities");
        }
    }
}
