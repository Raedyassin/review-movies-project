using System.ComponentModel.DataAnnotations;
namespace movieSiteAgainAgain.Models
{
    public class RegisterModel
    {
        [Key]
        [EmailAddress]
        [Required(ErrorMessage = "Please enter a valid userEmail")]
        public string userEmail { get; set; }
        [Required(ErrorMessage = "Please enter a valid userAccountName")]
        public string userAccountName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("password",ErrorMessage ="not match")]
        public string ConfirmPassword { get; set; }
    }
}
