using ExpenseTrackerApi.Enums;
using System.Text.Json.Serialization;

namespace ExpenseTrackerApi.Entities
{
	public class Finance : BaseEntity
	{
        public float Amount { get; set; }
        public FinanceType FinanceType { get; set; }
        public string? Description { get; set; }
        [JsonIgnore]
        public User? Users { get; set; }
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
		[JsonIgnore]
		public Category? Category { get; set; }
    }
}
