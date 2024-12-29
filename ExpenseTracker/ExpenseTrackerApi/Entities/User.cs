using System.Text.Json.Serialization;

namespace ExpenseTrackerApi.Entities
{
	public class User : BaseEntity
	{
		public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
		[JsonIgnore]
		public ICollection<Category>? Categories { get; set; }
		[JsonIgnore]
		public ICollection<Finance>? Finances { get; set; }
		[JsonIgnore]
		public ICollection<Budget>? Budgets { get; set; }
    }
}
