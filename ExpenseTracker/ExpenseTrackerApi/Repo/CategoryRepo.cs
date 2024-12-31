using AutoMapper;
using ExpenseTrackerApi.Data;
using ExpenseTrackerApi.Entities;
using ExpenseTrackerApi.Interfaces;
using ExpenseTrackerApi.Models.Categories;
using ExpenseTrackerApi.ViewModels.Categories;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ExpenseTrackerApi.Repo
{
	public class CategoryRepo : ICategoryService
	{
		private readonly AppDbContext _appDbContext;
		private readonly IConfiguration configuration;
		private readonly IMapper mapper;
		private readonly IHttpContextAccessor contextAccessor;
		public CategoryRepo(AppDbContext appDbContext, IConfiguration configuration, IMapper mapper, IHttpContextAccessor contextAccessor)
		{
			_appDbContext = appDbContext;
			this.configuration = configuration;
			this.mapper = mapper;
			this.contextAccessor = contextAccessor;
		}
		public async Task<Payload<CategoryResponse>> AddCategory(CategoryDto categoryDto)
		{
			if (categoryDto == null) return Payload<CategoryResponse>.BadRequest("Category is empty");

			var category = mapper.Map<Category>(categoryDto);

			_appDbContext.Categories.Add(category);
			await _appDbContext.SaveChangesAsync();
			var categoryResponse = mapper.Map<CategoryResponse>(category);
			return Payload<CategoryResponse>.Successfully(categoryResponse, "Create category successfully");
		}

		public async Task<Payload<ICollection<CategoryResponse>>> GetAllCategories(int pageIndex, int pageSize)
		{
			var userId = contextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

			if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var parsedUserId))
			{
				return Payload<ICollection<CategoryResponse>>.RequestInvalid("Invalid or missing user ID.");
			}

			var categories = await _appDbContext.Categories.Where(c => c.UserId == parsedUserId).OrderBy(c => c.CreatedAt).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
			var count = await _appDbContext.Categories.CountAsync();
			var totalPages = (int)Math.Ceiling(count / (double)pageSize); 

			var categoryResponses = mapper.Map<ICollection<CategoryResponse>>(categories);

			return Payload<ICollection<CategoryResponse>>.Successfully(categoryResponses, "Success");
		}

		public async Task<Payload<CategoryResponse>> UpdateCategory(Guid id, UpdateCategoryDto category)
		{
			var categoryData = await _appDbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);

			if (categoryData == null) return Payload<CategoryResponse>.BadRequest("Category Not Found");

			if(!string.IsNullOrEmpty(category.Name)) categoryData.Name = category.Name;
			if (!string.IsNullOrEmpty(category.IconUrl)) categoryData.IconUrl = category.IconUrl;

			_appDbContext.Entry(categoryData).State = EntityState.Modified;
			await _appDbContext.SaveChangesAsync();

			var categoryResponse = mapper.Map<CategoryResponse>(categoryData);

			return Payload<CategoryResponse>.Successfully(categoryResponse, "Update Successfully");
        }
	}
}
