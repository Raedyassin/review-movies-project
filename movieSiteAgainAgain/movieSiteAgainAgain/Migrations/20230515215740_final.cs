using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace movieSiteAgainAgain.Migrations
{
    /// <inheritdoc />
    public partial class final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserReviewMovies",
                table: "UserReviewMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRatedMovies",
                table: "UserRatedMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFavoriteMoviefs",
                table: "UserFavoriteMoviefs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorInMovies",
                table: "ActorInMovies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserReviewMovies",
                table: "UserReviewMovies",
                columns: new[] { "userEmail", "movieId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRatedMovies",
                table: "UserRatedMovies",
                columns: new[] { "userEmail", "movieId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFavoriteMoviefs",
                table: "UserFavoriteMoviefs",
                columns: new[] { "userEmail", "movieId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorInMovies",
                table: "ActorInMovies",
                columns: new[] { "actorId", "movieId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserReviewMovies",
                table: "UserReviewMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRatedMovies",
                table: "UserRatedMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFavoriteMoviefs",
                table: "UserFavoriteMoviefs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorInMovies",
                table: "ActorInMovies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserReviewMovies",
                table: "UserReviewMovies",
                column: "userEmail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRatedMovies",
                table: "UserRatedMovies",
                column: "userEmail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFavoriteMoviefs",
                table: "UserFavoriteMoviefs",
                column: "userEmail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorInMovies",
                table: "ActorInMovies",
                column: "actorId");
        }
    }
}
