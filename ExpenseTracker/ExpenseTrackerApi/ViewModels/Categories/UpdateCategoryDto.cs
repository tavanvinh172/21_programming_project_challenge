using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerApi.ViewModels.Categories
{
	public class UpdateCategoryDto
	{
		public string? Name { get; set; }
		public string? IconUrl { get; set; }
	}
}
