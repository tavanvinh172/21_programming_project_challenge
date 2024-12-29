using AutoMapper;
using ExpenseTrackerApi.Entities;
using ExpenseTrackerApi.ViewModels.Finances;

namespace ExpenseTrackerApi.Models.Finances.Mapper
{
	public class AddFinanceMapper : Profile
	{
		public AddFinanceMapper() {
			CreateMap<FinanceDto, Finance>();
			CreateMap<Finance, FinanceResponse>();
		}
	}
}
