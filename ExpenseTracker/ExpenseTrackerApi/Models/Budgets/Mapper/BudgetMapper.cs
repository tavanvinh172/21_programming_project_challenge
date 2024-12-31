using AutoMapper;
using ExpenseTrackerApi.Entities;
using ExpenseTrackerApi.ViewModels.Budgets;

namespace ExpenseTrackerApi.Models.Budgets.Mapper
{
	public class BudgetMapper : Profile
	{
		public BudgetMapper() {
			CreateMap<BudgetDto, Budget>();
			CreateMap<Budget, BudgetResponse>();
		}
	}
}
