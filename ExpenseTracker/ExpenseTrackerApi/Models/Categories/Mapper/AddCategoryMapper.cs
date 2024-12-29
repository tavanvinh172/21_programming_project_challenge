using AutoMapper;
using ExpenseTrackerApi.Entities;
using ExpenseTrackerApi.ViewModels.Categories;

namespace ExpenseTrackerApi.Models.Categories.Mapper
{
	public class AddCategoryMapper : Profile
	{
		public AddCategoryMapper() {
			CreateMap<CategoryDto, Category>();
			CreateMap<Category, CategoryResponse>();
		}
	}
}
