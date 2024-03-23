using System.ComponentModel.DataAnnotations;
namespace movieSiteAgainAgain.Models
{
	public class Movie
	{
		[Key]
		public int movieId { get; set; }
		[Required]
		public string movieName { get; set; }
		[Required]
		public string date { get; set; }
		[Required]
		public string poster { get; set; }	
		[Required]
		public string description { get; set; }
		public string trailer { get; set; }
		[Required]	
		public double averageRating { get; set; }
		[Required]
		public string directors { get; set; }
		[Required]
		public string writers { get; set; }
		[Required]
		public string genre { get; set; }
		public string keyWord { get; set; }
        [Required]
        public string runTime { get; set; }
		[Required]
		public string movieMMPA { get; set; }
		public ICollection<ActorInMovie>? ActorInMovies { get; set;}
        public ICollection<UserFavoriteMovief>? UserFavoriteMoviefs { get; set; }
        public ICollection<UserReviewMovie>? UserReviewMovies { get; set; }
        public ICollection<UserRatedMovie>? UserRatedMovies { get; set; }
    }
}
