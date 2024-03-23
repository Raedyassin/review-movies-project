using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movieSiteAgainAgain.Models
{
    [PrimaryKey(nameof(actorId),nameof(movieId))]
	public class ActorInMovie
	{
        [Key]
		public int actorId { get; set; }
        [ForeignKey("actorId")]
        public Actor? Actor { get; set; }
		public int movieId { get; set; }
        [ForeignKey("movieId")]
        public Movie? Movie { get; set; }
        public  string actName { get; set; }
        public string movName { get; set; }
        public string movYear { get; set; }
		[Required]
		public string roleName { get; set; }
    }
}
