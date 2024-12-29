using ExpenseTrackerApi.Entities;
using ExpenseTrackerApi.Interfaces;
using ExpenseTrackerApi.Models.Categories;
using ExpenseTrackerApi.ViewModels.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

		[HttpGet(nameof(GetAllCategories))]
		public async Task<Payload<ICollection<CategoryResponse>>> GetAllCategories(int pageIndex, int pageSize)
		{
			return await categoryService.GetAllCategories(pageIndex, pageSize);
		}

		[HttpPost(nameof(AddCategory))]
		public async Task<Payload<CategoryResponse>> AddCategory(CategoryDto categoryDto)
		{
			return await categoryService.AddCategory(categoryDto);
		}

		[HttpPost(nameof(UpdateCategory))]
		public async Task<Payload<CategoryResponse>> UpdateCategory(Guid id, UpdateCategoryDto category)
		{
			return await categoryService.UpdateCategory(id, category);
		}
	}
}
