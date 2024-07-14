using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTheater.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddManyToManyRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "MovieEntityMovieTheaterEntity",
                columns: table => new
                {
                    MovieTheatersId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieEntityMovieTheaterEntity", x => new { x.MovieTheatersId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_MovieEntityMovieTheaterEntity_MovieEntity_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "MovieEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieEntityMovieTheaterEntity_MovieTheaterEntity_MovieTheatersId",
                        column: x => x.MovieTheatersId,
                        principalTable: "MovieTheaterEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieEntityMovieTheaterEntity_MoviesId",
                table: "MovieEntityMovieTheaterEntity",
                column: "MoviesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieEntityMovieTheaterEntity");

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
    }
}
