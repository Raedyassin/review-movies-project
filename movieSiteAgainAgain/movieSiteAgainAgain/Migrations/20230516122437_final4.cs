using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace movieSiteAgainAgain.Migrations
{
    /// <inheritdoc />
    public partial class final4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConfirmPassword",
                table: "Users",
                newName: "userAvatar");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userAvatar",
                table: "Users",
                newName: "ConfirmPassword");
        }
    }
}
