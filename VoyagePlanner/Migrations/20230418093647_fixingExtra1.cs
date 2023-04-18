using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoyagePlanner.Migrations
{
    /// <inheritdoc />
    public partial class fixingExtra1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Extras_Voyages_VoyageId",
                table: "Extras");

            migrationBuilder.AlterColumn<int>(
                name: "VoyageId",
                table: "Extras",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Extras_Voyages_VoyageId",
                table: "Extras",
                column: "VoyageId",
                principalTable: "Voyages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Extras_Voyages_VoyageId",
                table: "Extras");

            migrationBuilder.AlterColumn<int>(
                name: "VoyageId",
                table: "Extras",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Extras_Voyages_VoyageId",
                table: "Extras",
                column: "VoyageId",
                principalTable: "Voyages",
                principalColumn: "Id");
        }
    }
}
