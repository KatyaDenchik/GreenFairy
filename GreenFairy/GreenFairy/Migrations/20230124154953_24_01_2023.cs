using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenFairy.Migrations
{
    /// <inheritdoc />
    public partial class _24012023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantEntities_OrderEntities_OrderEntityId",
                table: "PlantEntities");

            migrationBuilder.DropIndex(
                name: "IX_PlantEntities_OrderEntityId",
                table: "PlantEntities");

            migrationBuilder.DropColumn(
                name: "OrderEntityId",
                table: "PlantEntities");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderEntityPlantEntity");

            migrationBuilder.AddColumn<int>(
                name: "OrderEntityId",
                table: "PlantEntities",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlantEntities_OrderEntityId",
                table: "PlantEntities",
                column: "OrderEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantEntities_OrderEntities_OrderEntityId",
                table: "PlantEntities",
                column: "OrderEntityId",
                principalTable: "OrderEntities",
                principalColumn: "Id");
        }
    }
}
