using ExpenseTrackerApi.Entities;
using ExpenseTrackerApi.Models.Budgets;
using ExpenseTrackerApi.ViewModels.Budgets;

namespace ExpenseTrackerApi.Interfaces
{
	public interface IBudgetService
	{
		Task<Payload<ICollection<BudgetResponse>>> GetBudgets(DateTime? StartDate, DateTime? EndDate);
		Task<Payload<BudgetResponse>> CreateBudget(BudgetDto budgetDto);
		Task<Payload<string>> DeleteBudget(Guid budgetId);
		Task<Payload<BudgetResponse>> UpdateBudget(Guid budgetId, BudgetDto budgetDto); 
	}
}
