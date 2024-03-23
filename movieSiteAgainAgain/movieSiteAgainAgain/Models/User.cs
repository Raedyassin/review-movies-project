using System.ComponentModel.DataAnnotations;
namespace movieSiteAgainAgain.Models
{
	public class User
	{
		[Key]
        [EmailAddress]
		[Required]
		public string userEmail { get; set; }

		[Required]
		public string userAccountName { get; set; }
		public string userAvatar { get; set; }
		[Required]
		[DataType(DataType.Password)]	
		public string password { get; set; }
		public ICollection<UserFavoriteMovief>? UserFavoriteMoviefs { get; set; }
        public ICollection<UserReviewMovie>? UserReviewMovies { get; set; }
        public ICollection<UserRatedMovie>? UserRatedMovies { get; set; }
    }
}
