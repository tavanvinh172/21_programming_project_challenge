using AutoMapper;
using ExpenseTrackerApi.Data;
using ExpenseTrackerApi.Entities;
using ExpenseTrackerApi.Interfaces;
using ExpenseTrackerApi.Models.Finances;
using ExpenseTrackerApi.ViewModels.Finances;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerApi.Repo
{
	public class FinanceRepo : IFinanceService
	{
		private readonly AppDbContext _appDbContext;
		private readonly IConfiguration configuration;
		private readonly IMapper mapper;
		public FinanceRepo(AppDbContext appDbContext, IConfiguration configuration, IMapper mapper)
		{
			_appDbContext = appDbContext;
			this.configuration = configuration;
			this.mapper = mapper;
		}
		public async Task<Payload<FinanceResponse>> CreateFinance(FinanceDto financeDto)
		{
			if (financeDto == null) throw new ArgumentNullException(nameof(financeDto));

			if (financeDto.Amount == 0) return Payload<FinanceResponse>.BadRequest("Amount cannot be 0");

			var finance = mapper.Map<Finance>(financeDto);

			_appDbContext.Finances.Add(finance);
			await _appDbContext.SaveChangesAsync();
			var financeResponse = mapper.Map<FinanceResponse>(finance);
			financeResponse.Category = await _appDbContext.Categories.FirstOrDefaultAsync(c => c.Id == financeDto.CategoryId);
			return Payload<FinanceResponse>.Successfully(financeResponse, "OK");
		}

		public async Task<Payload<ICollection<FinanceResponse>>> GetAll(int pageIndex, int pageSize, DateTime? startDate, DateTime? endDate)
		{
			var nowUtc = DateTime.UtcNow;
			var filteredStartDate = startDate ?? new DateTime(nowUtc.Year, nowUtc.Month, 1, 0, 0, 0, DateTimeKind.Utc);
			var filteredEndDate = endDate ?? filteredStartDate.AddMonths(1).AddTicks(-1); // Last moment of the current month in UTC
			Console.WriteLine($"StartDate {filteredStartDate}");
			Console.WriteLine($"EndDate {filteredEndDate}");
			var finances = await _appDbContext.Finances
				.Where(c => c.CreatedAt >= filteredStartDate && c.CreatedAt <= filteredEndDate)
				.OrderBy(c => c.CreatedAt)
				.Skip((pageIndex - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync();

			foreach (var item in finances)
			{
				//Console.WriteLine($"Id {item.Category.Id}");
				item.Category = await _appDbContext.Categories.FirstOrDefaultAsync(c => c.Id == item.CategoryId);
			}

			var count = await _appDbContext.Finances.CountAsync();
			var totalPages = (int)Math.Ceiling(count / (double)pageSize);
			var financeResponse = mapper.Map<ICollection<FinanceResponse>>(finances);
			return Payload<ICollection<FinanceResponse>>.Successfully(financeResponse, "OK");
		}

		public Task<Payload<FinanceResponse>> UpdateFinance(Guid id, FinanceDto financeDto)
		{
			throw new NotImplementedException();
		}
	}
}
