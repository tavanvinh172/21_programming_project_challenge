using ExpenseTrackerApi.Entities;

namespace ExpenseTrackerApi.Models.Budgets
{
	public class BudgetResponse
	{
        public Guid Id { get; set; }
        public float Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Category? Category { get; set; }
    }
}
