using ExpenseTrackerApi.Enums;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerApi.ViewModels.Finances
{
	public class FinanceDto
	{
		[Required]
        public float Amount { get; set; }
		[Required]
		public FinanceType FinanceType{ get; set; }
        public string? Description { get; set; }
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
