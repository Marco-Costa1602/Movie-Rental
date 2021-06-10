using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoRental.Migrations
{
    public partial class lastDayColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "lastDay",
                table: "Rental",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "lastDay",
                table: "Rental");
        }
    }
}
