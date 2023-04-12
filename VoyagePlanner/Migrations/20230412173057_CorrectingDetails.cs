using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoyagePlanner.Migrations
{
    /// <inheritdoc />
    public partial class CorrectingDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Extras");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Extras");

            migrationBuilder.AddColumn<int>(
                name: "ExtraDetailId",
                table: "Extras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Extras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ExtraDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraDetail", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Extras_ExtraDetailId",
                table: "Extras",
                column: "ExtraDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Extras_ExtraDetail_ExtraDetailId",
                table: "Extras",
                column: "ExtraDetailId",
                principalTable: "ExtraDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Extras_ExtraDetail_ExtraDetailId",
                table: "Extras");

            migrationBuilder.DropTable(
                name: "ExtraDetail");

            migrationBuilder.DropIndex(
                name: "IX_Extras_ExtraDetailId",
                table: "Extras");

            migrationBuilder.DropColumn(
                name: "ExtraDetailId",
                table: "Extras");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Extras");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Extras",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Extras",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
