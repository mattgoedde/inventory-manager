using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TenantUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemEntity_Locations_LocationId",
                table: "ItemEntity");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemEntity_Locations_LocationId",
                table: "ItemEntity",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemEntity_Locations_LocationId",
                table: "ItemEntity");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemEntity_Locations_LocationId",
                table: "ItemEntity",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");
        }
    }
}
