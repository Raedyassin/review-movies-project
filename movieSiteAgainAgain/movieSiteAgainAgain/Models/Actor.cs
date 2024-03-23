using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movieSiteAgainAgain.Models
{
	public class Actor
	{
		[Key]
		public int actorId { get; set; }
		[Required]
		public string actorName { get; set; }
		[Required]
		public string actorDescription { get; set; }
		public string actorPicture { get; set; }

        public ICollection<ActorInMovie>? ActorInMovies { get; set; }
	}
}
