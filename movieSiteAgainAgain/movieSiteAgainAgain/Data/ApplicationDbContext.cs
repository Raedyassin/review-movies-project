using Microsoft.EntityFrameworkCore;
using movieSiteAgainAgain.Models;
namespace movieSiteAgainAgain.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { } 
        public DbSet<Actor> Actors { get; set; }
        public  DbSet<ActorInMovie> ActorInMovies { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserFavoriteMovief> UserFavoriteMoviefs { get; set; }  
        public DbSet<UserRatedMovie> UserRatedMovies { get; set; }
        public  DbSet<UserReviewMovie> UserReviewMovies { get; set; }



    }
}
