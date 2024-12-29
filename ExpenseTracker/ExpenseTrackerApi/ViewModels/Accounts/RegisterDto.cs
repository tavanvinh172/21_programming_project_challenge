using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerApi.ViewModels.Accounts
{
	public class RegisterDto
	{
        public string? Fullname { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string? Password { get; set; }
    }
}
