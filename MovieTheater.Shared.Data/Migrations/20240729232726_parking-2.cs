using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTheater.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class parking2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingDetailEntity_MovieTheaterEntity_MovieTheaterEntityId",
                table: "ParkingDetailEntity");

            migrationBuilder.DropIndex(
                name: "IX_ParkingDetailEntity_MovieTheaterEntityId",
                table: "ParkingDetailEntity");

            migrationBuilder.DropColumn(
                name: "MovieTheaterEntityId",
                table: "ParkingDetailEntity");

            migrationBuilder.AddColumn<int>(
                name: "MovieTheaterId",
                table: "ParkingDetailEntity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ParkingDetailEntity_MovieTheaterId",
                table: "ParkingDetailEntity",
                column: "MovieTheaterId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingDetailEntity_MovieTheaterEntity_MovieTheaterId",
                table: "ParkingDetailEntity",
                column: "MovieTheaterId",
                principalTable: "MovieTheaterEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingDetailEntity_MovieTheaterEntity_MovieTheaterId",
                table: "ParkingDetailEntity");

            migrationBuilder.DropIndex(
                name: "IX_ParkingDetailEntity_MovieTheaterId",
                table: "ParkingDetailEntity");

            migrationBuilder.DropColumn(
                name: "MovieTheaterId",
                table: "ParkingDetailEntity");

            migrationBuilder.AddColumn<int>(
                name: "MovieTheaterEntityId",
                table: "ParkingDetailEntity",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParkingDetailEntity_MovieTheaterEntityId",
                table: "ParkingDetailEntity",
                column: "MovieTheaterEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingDetailEntity_MovieTheaterEntity_MovieTheaterEntityId",
                table: "ParkingDetailEntity",
                column: "MovieTheaterEntityId",
                principalTable: "MovieTheaterEntity",
                principalColumn: "Id");
        }
    }
}
