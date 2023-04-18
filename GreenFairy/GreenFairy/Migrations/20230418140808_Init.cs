using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenFairy.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Surname = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<int>(type: "INTEGER", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlantEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Species = table.Column<string>(type: "TEXT", nullable: false),
                    Group = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Photo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    DeliveryKind = table.Column<int>(type: "INTEGER", nullable: false),
                    PaymentKind = table.Column<int>(type: "INTEGER", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: false),
                    AddressOfDelivery = table.Column<string>(type: "TEXT", nullable: false),
                    PlantsCount = table.Column<int>(type: "INTEGER", nullable: false),
                    DateAndTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderEntities_ClientEntities_ClientId",
                        column: x => x.ClientId,
                        principalTable: "ClientEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderedPlantEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlantId = table.Column<int>(type: "INTEGER", nullable: true),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderingKind = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderedPlantEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderedPlantEntities_OrderEntities_OrderId",
                        column: x => x.OrderId,
                        principalTable: "OrderEntities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderedPlantEntities_PlantEntities_PlantId",
                        column: x => x.PlantId,
                        principalTable: "PlantEntities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderedPlantEntities_OrderId",
                table: "OrderedPlantEntities",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedPlantEntities_PlantId",
                table: "OrderedPlantEntities",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderEntities_ClientId",
                table: "OrderEntities",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminEntities");

            migrationBuilder.DropTable(
                name: "OrderedPlantEntities");

            migrationBuilder.DropTable(
                name: "OrderEntities");

            migrationBuilder.DropTable(
                name: "PlantEntities");

            migrationBuilder.DropTable(
                name: "ClientEntities");
        }
    }
}
