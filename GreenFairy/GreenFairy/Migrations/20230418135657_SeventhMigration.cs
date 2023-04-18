using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenFairy.Migrations
{
    /// <inheritdoc />
    public partial class SeventhMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OrderedPlantEntities",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderedPlantEntities_OrderId",
                table: "OrderedPlantEntities",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedPlantEntities_OrderEntities_OrderId",
                table: "OrderedPlantEntities",
                column: "OrderId",
                principalTable: "OrderEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderedPlantEntities_OrderEntities_OrderId",
                table: "OrderedPlantEntities");

            migrationBuilder.DropIndex(
                name: "IX_OrderedPlantEntities_OrderId",
                table: "OrderedPlantEntities");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderedPlantEntities");

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
    }
}
