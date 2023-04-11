using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoyagePlanner.Migrations
{
    /// <inheritdoc />
    public partial class FixingAllowance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allowance");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Destinations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_CountryId",
                table: "Destinations",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_Country_CountryId",
                table: "Destinations",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Country_CountryId",
                table: "Destinations");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropIndex(
                name: "IX_Destinations_CountryId",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Destinations");

            migrationBuilder.CreateTable(
                name: "Allowance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: true),
                    ReductionPercentage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allowance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Allowance_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allowance_PersonId",
                table: "Allowance",
                column: "PersonId");
        }
    }
}
