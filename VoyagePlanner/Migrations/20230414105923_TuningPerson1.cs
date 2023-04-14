using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoyagePlanner.Migrations
{
    /// <inheritdoc />
    public partial class TuningPerson1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Allowances_AllowanceId",
                table: "Persons");

            migrationBuilder.AlterColumn<int>(
                name: "AllowanceId",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Allowances_AllowanceId",
                table: "Persons",
                column: "AllowanceId",
                principalTable: "Allowances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Allowances_AllowanceId",
                table: "Persons");

            migrationBuilder.AlterColumn<int>(
                name: "AllowanceId",
                table: "Persons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Allowances_AllowanceId",
                table: "Persons",
                column: "AllowanceId",
                principalTable: "Allowances",
                principalColumn: "Id");
        }
    }
}
