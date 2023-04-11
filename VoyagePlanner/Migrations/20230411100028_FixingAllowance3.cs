using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoyagePlanner.Migrations
{
    /// <inheritdoc />
    public partial class FixingAllowance3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AllowanceId",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Allowances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReductionPercentage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allowances", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_AllowanceId",
                table: "Persons",
                column: "AllowanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Allowances_AllowanceId",
                table: "Persons",
                column: "AllowanceId",
                principalTable: "Allowances",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Allowances_AllowanceId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "Allowances");

            migrationBuilder.DropIndex(
                name: "IX_Persons_AllowanceId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "AllowanceId",
                table: "Persons");
        }
    }
}
