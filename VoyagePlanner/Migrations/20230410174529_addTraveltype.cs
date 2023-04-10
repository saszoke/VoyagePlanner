using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoyagePlanner.Migrations
{
    /// <inheritdoc />
    public partial class addTraveltype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TravelTypeId",
                table: "Voyages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Voyages_TravelTypeId",
                table: "Voyages",
                column: "TravelTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Voyages_TravelTypes_TravelTypeId",
                table: "Voyages",
                column: "TravelTypeId",
                principalTable: "TravelTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voyages_TravelTypes_TravelTypeId",
                table: "Voyages");

            migrationBuilder.DropIndex(
                name: "IX_Voyages_TravelTypeId",
                table: "Voyages");

            migrationBuilder.DropColumn(
                name: "TravelTypeId",
                table: "Voyages");
        }
    }
}
