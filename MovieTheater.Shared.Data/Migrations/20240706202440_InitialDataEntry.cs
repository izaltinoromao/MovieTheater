using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTheater.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("MovieTheaterEntity", new string[] { "Name", "Address" }, new object[] { "Cine A", "Pouso Alegre" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM MovieTheaterEntity");
        }
    }
}
