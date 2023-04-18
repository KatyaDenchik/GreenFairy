using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenFairy.Migrations
{
    /// <inheritdoc />
    public partial class SixthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderEntityOrderedPlantEntity");

            migrationBuilder.AddColumn<int>(
                name: "OrderEntityId",
                table: "OrderedPlantEntities",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderedPlantEntities_OrderEntityId",
                table: "OrderedPlantEntities",
                column: "OrderEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedPlantEntities_OrderEntities_OrderEntityId",
                table: "OrderedPlantEntities",
                column: "OrderEntityId",
                principalTable: "OrderEntities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderedPlantEntities_OrderEntities_OrderEntityId",
                table: "OrderedPlantEntities");

            migrationBuilder.DropIndex(
                name: "IX_OrderedPlantEntities_OrderEntityId",
                table: "OrderedPlantEntities");

            migrationBuilder.DropColumn(
                name: "OrderEntityId",
                table: "OrderedPlantEntities");

            migrationBuilder.CreateTable(
                name: "OrderEntityOrderedPlantEntity",
                columns: table => new
                {
                    OrderedPlantId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrdersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderEntityOrderedPlantEntity", x => new { x.OrderedPlantId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_OrderEntityOrderedPlantEntity_OrderEntities_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "OrderEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderEntityOrderedPlantEntity_OrderedPlantEntities_OrderedPlantId",
                        column: x => x.OrderedPlantId,
                        principalTable: "OrderedPlantEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderEntityOrderedPlantEntity_OrdersId",
                table: "OrderEntityOrderedPlantEntity",
                column: "OrdersId");
        }
    }
}
