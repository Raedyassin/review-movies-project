using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace movieSiteAgainAgain.Models
{
    public class LoginModel
    {
        [Key]
        [EmailAddress]
        [Required(ErrorMessage = "Please enter a valid email address")]
        public string userEmail { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter a valid email address")]
        public string password { get; set; }
    }
}
