using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoyagePlanner.Migrations
{
    /// <inheritdoc />
    public partial class modifiedDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfVoyage",
                table: "Voyages",
                newName: "StartDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Voyages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Voyages");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Voyages",
                newName: "DateOfVoyage");
        }
    }
}
