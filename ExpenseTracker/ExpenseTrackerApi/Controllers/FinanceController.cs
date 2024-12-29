using ExpenseTrackerApi.Entities;
using ExpenseTrackerApi.Interfaces;
using ExpenseTrackerApi.Models.Finances;
using ExpenseTrackerApi.ViewModels.Finances;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class FinanceController : ControllerBase
	{
		private readonly IFinanceService financeService;
        public FinanceController(IFinanceService financeService)
        {
            this.financeService = financeService;
        }

		[HttpPost(nameof(CreateFinance))]
		public async Task<Payload<FinanceResponse>> CreateFinance(FinanceDto financeDto)
		{
			return await financeService.CreateFinance(financeDto);
		}

		[HttpGet(nameof(GetAll))]
		public async Task<Payload<ICollection<FinanceResponse>>> GetAll(int pageIndex, int pageSize, DateTime? startDate, DateTime? endDate)
		{
			var accessToken = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
			Console.WriteLine(accessToken);
			return await financeService.GetAll(pageIndex, pageSize, startDate, endDate);
		}
	}
}
