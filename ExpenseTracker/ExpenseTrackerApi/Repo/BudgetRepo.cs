using AutoMapper;
using ExpenseTrackerApi.Data;
using ExpenseTrackerApi.Entities;
using ExpenseTrackerApi.Interfaces;
using ExpenseTrackerApi.Models.Budgets;
using ExpenseTrackerApi.Models.Categories;
using ExpenseTrackerApi.Models.Finances;
using ExpenseTrackerApi.Utils;
using ExpenseTrackerApi.ViewModels.Budgets;
using ExpenseTrackerApi.ViewModels.Finances;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Claims;

namespace ExpenseTrackerApi.Repo
{
	public class BudgetRepo : IBudgetService
	{
		private readonly AppDbContext _appDbContext;
		private readonly IConfiguration configuration;
		private readonly IMapper mapper;
		private readonly IHttpContextAccessor contextAccessor;
		public BudgetRepo(AppDbContext appDbContext, IConfiguration configuration, IMapper mapper, IHttpContextAccessor contextAccessor)
		{
			_appDbContext = appDbContext;
			this.configuration = configuration;
			this.mapper = mapper;
			this.contextAccessor = contextAccessor;
		}
		public async Task<Payload<BudgetResponse>> CreateBudget(BudgetDto budgetDto)
		{

			var nowUtc = DateTime.UtcNow;

			if (budgetDto == null) return Payload<BudgetResponse>.RequestInvalid("Object is empty");

			var userId = contextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

			if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var parsedUserId))
			{
				return Payload<BudgetResponse>.RequestInvalid("Invalid or missing user ID.");
			}

			var filteredStartDate = budgetDto.StartDate ?? new DateTime(nowUtc.Year, nowUtc.Month, 1, 0, 0, 0, DateTimeKind.Utc);

			var filteredEndDate = budgetDto.EndDate ?? filteredStartDate.AddMonths(1).AddTicks(-1); // Last moment of the current month in UTC

			var budget = mapper.Map<Budget>(budgetDto);

			budget.UserId = parsedUserId;

			budget.Category = await _appDbContext.Categories.FirstOrDefaultAsync(c => c.Id == budgetDto.CategoryId);

			budget.StartDate = filteredStartDate;

			budget.EndDate = filteredEndDate;

			_appDbContext.Budgets.Add(budget);

			await _appDbContext.SaveChangesAsync();

			var budgetResponse = mapper.Map<BudgetResponse>(budget);

			return Payload<BudgetResponse>.Successfully(budgetResponse, "OK");
		}

		public async Task<Payload<string>> DeleteBudget(Guid budgetId)
		{
			var userId = Constants.GetUserId(contextAccessor);

			if (userId == null)
			{
				return Payload<string>.RequestInvalid("Invalid or missing user ID.");
			}

			if (budgetId == Guid.Empty) return Payload<string>.BadRequest("Id can't be empty");

			var budget = await _appDbContext.Budgets.FirstOrDefaultAsync(b => b.Id == budgetId && b.UserId == userId);

			if (budget == null) return Payload<string>.BadRequest("Budget Not Found");

			_appDbContext.Budgets.Remove(budget);

			await _appDbContext.SaveChangesAsync();

			return Payload<string>.Successfully("Delete Budget Successfully");
		}

		public async Task<Payload<ICollection<BudgetResponse>>> GetBudgets(DateTime? startDate, DateTime? endDate)
		{
			var nowUtc = DateTime.UtcNow;

			var userId = Constants.GetUserId(contextAccessor);

			if (userId == null)
			{
				return Payload<ICollection<BudgetResponse>>.RequestInvalid("Invalid or missing user ID.");
			}

			var filteredStartDate = startDate ?? new DateTime(nowUtc.Year, nowUtc.Month, 1, 0, 0, 0, DateTimeKind.Utc);

			var filteredEndDate = endDate ?? filteredStartDate.AddMonths(1).AddTicks(-1); // Last moment of the current month in UTC

			var budgets = await _appDbContext.Budgets.Where(b => b.UserId == userId && b.CreatedAt >= filteredStartDate && b.CreatedAt <= filteredEndDate).ToListAsync();
            foreach (var item in budgets)
            {
				item.Category = await _appDbContext.Categories.FirstOrDefaultAsync(c => c.Id == item.CategoryId);
            }
            var budgetResponse = mapper.Map<ICollection<BudgetResponse>>(budgets);
			return Payload<ICollection<BudgetResponse>>.Successfully(budgetResponse, "OK");
		}

		public async Task<Payload<BudgetResponse>> UpdateBudget(Guid budgetId, BudgetDto budgetDto)
		{
			var budgetData = await _appDbContext.Budgets.FirstOrDefaultAsync(b => b.Id == budgetId);

			if (budgetData == null) return Payload<BudgetResponse>.BadRequest("Finance Not Found");

			if (budgetDto.Amount != 0) budgetData.Amount = budgetDto.Amount;

			budgetData.CategoryId = budgetDto.CategoryId;

			_appDbContext.Entry(budgetData).State = EntityState.Modified;

			await _appDbContext.SaveChangesAsync();

			var budgetResponse = mapper.Map<BudgetResponse>(budgetData);

			return Payload<BudgetResponse>.Successfully(budgetResponse, "Update Successfully");
		}
	}
}
