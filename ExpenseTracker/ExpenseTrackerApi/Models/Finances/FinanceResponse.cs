using ExpenseTrackerApi.Entities;
using ExpenseTrackerApi.Enums;

namespace ExpenseTrackerApi.Models.Finances
{
	public class FinanceResponse
	{
        public Guid Id { get; set; }
        public FinanceType FinanceType { get; set; }
        public float Amount { get; set; }
        public string? Description { get; set; }
        public Category? Category { get; set; }
    }
}
