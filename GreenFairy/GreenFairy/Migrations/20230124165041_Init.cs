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
                    Address = table.Column<string>(type: "TEXT", nullable: false),
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
                    Amount = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Photo = table.Column<byte[]>(type: "BLOB", nullable: false)
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
                name: "OrderEntityPlantEntity",
                columns: table => new
                {
                    OrdersId = table.Column<int>(type: "INTEGER", nullable: false),
                    PlantsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderEntityPlantEntity", x => new { x.OrdersId, x.PlantsId });
                    table.ForeignKey(
                        name: "FK_OrderEntityPlantEntity_OrderEntities_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "OrderEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderEntityPlantEntity_PlantEntities_PlantsId",
                        column: x => x.PlantsId,
                        principalTable: "PlantEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderEntities_ClientId",
                table: "OrderEntities",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderEntityPlantEntity_PlantsId",
                table: "OrderEntityPlantEntity",
                column: "PlantsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminEntities");

            migrationBuilder.DropTable(
                name: "OrderEntityPlantEntity");

            migrationBuilder.DropTable(
                name: "OrderEntities");

            migrationBuilder.DropTable(
                name: "PlantEntities");

            migrationBuilder.DropTable(
                name: "ClientEntities");
        }
    }
}
