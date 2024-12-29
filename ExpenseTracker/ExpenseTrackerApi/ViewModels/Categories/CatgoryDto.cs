using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerApi.ViewModels.Categories
{
	public class CategoryDto
	{
        [Required]
        public string? Name { get; set; }
		[Required]
		public string? IconUrl { get; set; }
        [Required]
		public Guid UserId { get; set; }
    }
}
