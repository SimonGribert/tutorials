using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorTestApp.Migrations
{
    /// <inheritdoc />
    public partial class AddRatingFieldToMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Rating",
                table: "Movie",
                type: "TEXT",
                maxLength: 5,
                nullable: false,
                defaultValue: "R");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Movie");
        }
    }
}
