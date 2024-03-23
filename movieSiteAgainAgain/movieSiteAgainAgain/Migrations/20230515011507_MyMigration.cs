using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace movieSiteAgainAgain.Migrations
{
    /// <inheritdoc />
    public partial class MyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    actorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    actorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    actorDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    actorPicture = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.actorId);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    movieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    movieName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    poster = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    trailer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    averageRating = table.Column<double>(type: "float", nullable: false),
                    directors = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    writers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    keyWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    runTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    movieMMPA = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.movieId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userEmail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    userFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userAccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userSecondName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userAvatar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userEmail);
                });

            migrationBuilder.CreateTable(
                name: "ActorInMovies",
                columns: table => new
                {
                    actorId = table.Column<int>(type: "int", nullable: false),
                    movieId = table.Column<int>(type: "int", nullable: false),
                    roleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorInMovies", x => x.actorId);
                    table.ForeignKey(
                        name: "FK_ActorInMovies_Actors_actorId",
                        column: x => x.actorId,
                        principalTable: "Actors",
                        principalColumn: "actorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorInMovies_Movies_movieId",
                        column: x => x.movieId,
                        principalTable: "Movies",
                        principalColumn: "movieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFavoriteMoviefs",
                columns: table => new
                {
                    userEmail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    movieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavoriteMoviefs", x => x.userEmail);
                    table.ForeignKey(
                        name: "FK_UserFavoriteMoviefs_Movies_movieId",
                        column: x => x.movieId,
                        principalTable: "Movies",
                        principalColumn: "movieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFavoriteMoviefs_Users_userEmail",
                        column: x => x.userEmail,
                        principalTable: "Users",
                        principalColumn: "userEmail",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRatedMovies",
                columns: table => new
                {
                    userEmail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    movieId = table.Column<int>(type: "int", nullable: false),
                    rate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRatedMovies", x => x.userEmail);
                    table.ForeignKey(
                        name: "FK_UserRatedMovies_Movies_movieId",
                        column: x => x.movieId,
                        principalTable: "Movies",
                        principalColumn: "movieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRatedMovies_Users_userEmail",
                        column: x => x.userEmail,
                        principalTable: "Users",
                        principalColumn: "userEmail",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserReviewMovies",
                columns: table => new
                {
                    userEmail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    movieId = table.Column<int>(type: "int", nullable: false),
                    movieReview = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    headReview = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    reviewDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReviewMovies", x => x.userEmail);
                    table.ForeignKey(
                        name: "FK_UserReviewMovies_Movies_movieId",
                        column: x => x.movieId,
                        principalTable: "Movies",
                        principalColumn: "movieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserReviewMovies_Users_userEmail",
                        column: x => x.userEmail,
                        principalTable: "Users",
                        principalColumn: "userEmail",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorInMovies_movieId",
                table: "ActorInMovies",
                column: "movieId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoriteMoviefs_movieId",
                table: "UserFavoriteMoviefs",
                column: "movieId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRatedMovies_movieId",
                table: "UserRatedMovies",
                column: "movieId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReviewMovies_movieId",
                table: "UserReviewMovies",
                column: "movieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorInMovies");

            migrationBuilder.DropTable(
                name: "UserFavoriteMoviefs");

            migrationBuilder.DropTable(
                name: "UserRatedMovies");

            migrationBuilder.DropTable(
                name: "UserReviewMovies");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
