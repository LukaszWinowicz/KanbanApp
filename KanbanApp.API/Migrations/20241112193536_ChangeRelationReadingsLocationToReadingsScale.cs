using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KanbanApp.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelationReadingsLocationToReadingsScale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Readings_Locations_LocationId",
                table: "Readings");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Readings",
                newName: "ScaleId");

            migrationBuilder.RenameIndex(
                name: "IX_Readings_LocationId",
                table: "Readings",
                newName: "IX_Readings_ScaleId");

            migrationBuilder.AddColumn<decimal>(
                name: "Factor10Pcs",
                table: "Items",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_Readings_Scales_ScaleId",
                table: "Readings",
                column: "ScaleId",
                principalTable: "Scales",
                principalColumn: "ScaleId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Readings_Scales_ScaleId",
                table: "Readings");

            migrationBuilder.DropColumn(
                name: "Factor10Pcs",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "ScaleId",
                table: "Readings",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Readings_ScaleId",
                table: "Readings",
                newName: "IX_Readings_LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Readings_Locations_LocationId",
                table: "Readings",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
