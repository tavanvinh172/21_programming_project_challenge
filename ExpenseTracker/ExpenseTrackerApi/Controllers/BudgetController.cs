using ExpenseTrackerApi.Entities;
using ExpenseTrackerApi.Interfaces;
using ExpenseTrackerApi.Models.Budgets;
using ExpenseTrackerApi.ViewModels.Budgets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BudgetController : ControllerBase
	{
		private readonly IBudgetService budgetService;
		public BudgetController(IBudgetService budgetService)
		{
			this.budgetService = budgetService;
		}

		[HttpPost(nameof(CreateBudget))]
		public async Task<Payload<BudgetResponse>> CreateBudget(BudgetDto budgetDto)
		{
			return await budgetService.CreateBudget(budgetDto);
		}

		[HttpGet(nameof(GetBudget))]
		public async Task<Payload<ICollection<BudgetResponse>>> GetBudget(DateTime? startDate, DateTime? endDate)
		{
			return await budgetService.GetBudgets(startDate, endDate);
		}

		[HttpDelete(nameof(DeleteBudget))]
		public async Task<Payload<string>> DeleteBudget(Guid budgetId)
		{
			return await budgetService.DeleteBudget(budgetId);
		}

		[HttpPut(nameof(UpdateBudget))]
		public async Task<Payload<BudgetResponse>> UpdateBudget(Guid budgetId, BudgetDto budgetDto){
			return await budgetService.UpdateBudget(budgetId, budgetDto);
		}
	}
}
