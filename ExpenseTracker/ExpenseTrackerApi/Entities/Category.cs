using System.Text.Json.Serialization;

namespace ExpenseTrackerApi.Entities
{
	public class Category : BaseEntity
	{
        public string? Name { get; set; }
        public string? IconUrl { get; set; }
		[JsonIgnore]
		public User? User { get; set; }
        public Guid UserId { get; set; }
		[JsonIgnore]
		public ICollection<Finance>? Finances { get; set; }
		[JsonIgnore]
		public ICollection<Budget>? Budgets { get; set; }
    }
}
