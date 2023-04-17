using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenFairy.Migrations
{
    /// <inheritdoc />
    public partial class FourdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderEntityPlantEntity");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "PlantEntities");

            migrationBuilder.AddColumn<int>(
                name: "PlantEntityId",
                table: "OrderEntities",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderedPlantEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlantId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderingKind = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderEntityId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderedPlantEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderedPlantEntities_OrderEntities_OrderEntityId",
                        column: x => x.OrderEntityId,
                        principalTable: "OrderEntities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderedPlantEntities_PlantEntities_PlantId",
                        column: x => x.PlantId,
                        principalTable: "PlantEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderEntities_PlantEntityId",
                table: "OrderEntities",
                column: "PlantEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedPlantEntities_OrderEntityId",
                table: "OrderedPlantEntities",
                column: "OrderEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedPlantEntities_PlantId",
                table: "OrderedPlantEntities",
                column: "PlantId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderEntities_PlantEntities_PlantEntityId",
                table: "OrderEntities",
                column: "PlantEntityId",
                principalTable: "PlantEntities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderEntities_PlantEntities_PlantEntityId",
                table: "OrderEntities");

            migrationBuilder.DropTable(
                name: "OrderedPlantEntities");

            migrationBuilder.DropIndex(
                name: "IX_OrderEntities_PlantEntityId",
                table: "OrderEntities");

            migrationBuilder.DropColumn(
                name: "PlantEntityId",
                table: "OrderEntities");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "PlantEntities",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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
                name: "IX_OrderEntityPlantEntity_PlantsId",
                table: "OrderEntityPlantEntity",
                column: "PlantsId");
        }
    }
}
