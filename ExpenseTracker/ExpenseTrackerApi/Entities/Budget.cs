using System.Text.Json.Serialization;

namespace ExpenseTrackerApi.Entities
{
	public class Budget : BaseEntity
	{
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
        public float Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
		[JsonIgnore]
		public User? Users { get; set; }
		[JsonIgnore]
		public Category? Category { get; set; }
    }
}
