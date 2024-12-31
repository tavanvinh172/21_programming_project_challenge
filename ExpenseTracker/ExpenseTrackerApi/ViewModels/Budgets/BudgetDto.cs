using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerApi.ViewModels.Budgets
{
	public class BudgetDto
	{
        [Required]
        public Guid CategoryId { get; set; }
        [Required]
        public float Amount { get; set; }
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }
	}
}
