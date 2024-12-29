using ExpenseTrackerApi.Entities;
using ExpenseTrackerApi.Models.Categories;
using ExpenseTrackerApi.ViewModels.Categories;

namespace ExpenseTrackerApi.Interfaces
{
	public interface ICategoryService
	{
		Task<Payload<ICollection<CategoryResponse>>> GetAllCategories(int pageIndex, int pageSize);
		Task<Payload<CategoryResponse>> AddCategory(CategoryDto categoryDto);
		Task<Payload<CategoryResponse>> UpdateCategory(Guid id, UpdateCategoryDto category);
	}
}
