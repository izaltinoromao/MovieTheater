using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTheater.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class parking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParkingDetailEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfSpaces = table.Column<int>(type: "int", nullable: false),
                    IsCovered = table.Column<bool>(type: "bit", nullable: false),
                    HasEVChargingStations = table.Column<bool>(type: "bit", nullable: false),
                    MovieTheaterEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingDetailEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingDetailEntity_MovieTheaterEntity_MovieTheaterEntityId",
                        column: x => x.MovieTheaterEntityId,
                        principalTable: "MovieTheaterEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingDetailEntity_MovieTheaterEntityId",
                table: "ParkingDetailEntity",
                column: "MovieTheaterEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingDetailEntity");
        }
    }
}
