using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTheater.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class RelateMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieTheaterEntityId",
                table: "MovieEntity",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovieEntity_MovieTheaterEntityId",
                table: "MovieEntity",
                column: "MovieTheaterEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieEntity_MovieTheaterEntity_MovieTheaterEntityId",
                table: "MovieEntity",
                column: "MovieTheaterEntityId",
                principalTable: "MovieTheaterEntity",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieEntity_MovieTheaterEntity_MovieTheaterEntityId",
                table: "MovieEntity");

            migrationBuilder.DropIndex(
                name: "IX_MovieEntity_MovieTheaterEntityId",
                table: "MovieEntity");

            migrationBuilder.DropColumn(
                name: "MovieTheaterEntityId",
                table: "MovieEntity");
        }
    }
}
