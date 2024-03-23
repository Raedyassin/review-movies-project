using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movieSiteAgainAgain.Models
{
    [PrimaryKey(nameof(userEmail), nameof(movieId))]
    public class UserReviewMovie
	{
		[Key]
		[Required]
		public string userEmail { get; set; }
		[Required]
		public int movieId { get; set; }
		[Required]
		public string movieReview { get; set; }
		[Required]
		public string headReview { get; set;}
		[Required]
		public string reviewDate{ get; set;}
        [ForeignKey("userEmail")]
        public User? User { get; set; }

        [ForeignKey("movieId")]
        public Movie? Movie { get; set; }
    }
}
