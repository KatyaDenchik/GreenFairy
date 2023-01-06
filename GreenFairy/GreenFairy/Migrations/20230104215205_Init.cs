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
                name: "OrderHistoryEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHistoryEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderHistoryEntities_ClientEntities_ClientId",
                        column: x => x.ClientId,
                        principalTable: "ClientEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    OrderHistoryEntityId = table.Column<int>(type: "INTEGER", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_OrderEntities_OrderHistoryEntities_OrderHistoryEntityId",
                        column: x => x.OrderHistoryEntityId,
                        principalTable: "OrderHistoryEntities",
                        principalColumn: "Id");
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
                    Photo = table.Column<byte[]>(type: "BLOB", nullable: false),
                    OrderEntityId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantEntities_OrderEntities_OrderEntityId",
                        column: x => x.OrderEntityId,
                        principalTable: "OrderEntities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderEntities_ClientId",
                table: "OrderEntities",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderEntities_OrderHistoryEntityId",
                table: "OrderEntities",
                column: "OrderHistoryEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHistoryEntities_ClientId",
                table: "OrderHistoryEntities",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantEntities_OrderEntityId",
                table: "PlantEntities",
                column: "OrderEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminEntities");

            migrationBuilder.DropTable(
                name: "PlantEntities");

            migrationBuilder.DropTable(
                name: "OrderEntities");

            migrationBuilder.DropTable(
                name: "OrderHistoryEntities");

            migrationBuilder.DropTable(
                name: "ClientEntities");
        }
    }
}
