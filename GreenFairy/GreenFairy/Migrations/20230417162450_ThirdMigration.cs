using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenFairy.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "ClientEntities");

            migrationBuilder.AddColumn<string>(
                name: "AddressOfDelivery",
                table: "OrderEntities",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressOfDelivery",
                table: "OrderEntities");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "ClientEntities",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
