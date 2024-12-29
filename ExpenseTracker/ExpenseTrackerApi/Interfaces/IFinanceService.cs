using ExpenseTrackerApi.Entities;
using ExpenseTrackerApi.Models.Finances;
using ExpenseTrackerApi.ViewModels.Finances;

namespace ExpenseTrackerApi.Interfaces
{
	public interface IFinanceService
	{
		Task<Payload<ICollection<FinanceResponse>>> GetAll(int pageIndex, int pageSize, DateTime? startDate, DateTime? endDate);
		Task<Payload<FinanceResponse>> CreateFinance(FinanceDto financeDto);
		Task<Payload<FinanceResponse>> UpdateFinance(Guid id, FinanceDto financeDto);
	}
}
