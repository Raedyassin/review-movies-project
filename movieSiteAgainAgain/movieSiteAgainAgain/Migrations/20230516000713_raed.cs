using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace movieSiteAgainAgain.Migrations
{
    /// <inheritdoc />
    public partial class raed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "actName",
                table: "ActorInMovies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "actName",
                table: "ActorInMovies");
        }
    }
}
