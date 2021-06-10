using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoRental.Migrations
{
    public partial class rental2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Rental_movieId",
                table: "Rental",
                column: "movieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rental_Movie_movieId",
                table: "Rental",
                column: "movieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rental_Movie_movieId",
                table: "Rental");

            migrationBuilder.DropIndex(
                name: "IX_Rental_movieId",
                table: "Rental");
        }
    }
}
