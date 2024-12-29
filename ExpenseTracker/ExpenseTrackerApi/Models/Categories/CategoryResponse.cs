namespace ExpenseTrackerApi.Models.Categories
{
	public class CategoryResponse
	{
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? IconUrl { get; set; }
    }
}
