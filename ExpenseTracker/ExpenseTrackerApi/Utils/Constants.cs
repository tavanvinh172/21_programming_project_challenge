using ExpenseTrackerApi.Entities;
using System.Security.Claims;

namespace ExpenseTrackerApi.Utils
{
	public static class Constants
	{
		public static readonly List<Category> DefaultCategories = new List<Category>()
		{
			new Category { Name = "Food & Dining", IconUrl = "categories/food.svg" },
			new Category { Name = "Housing", IconUrl = "categories/home.svg" },
			new Category { Name = "Transportation", IconUrl = "categories/transportation.svg" },
			new Category { Name = "Health & Wellness", IconUrl = "categories/health.svg" }
		};

		public static Guid? GetUserId(IHttpContextAccessor contextAccessor)
		{
			// Extract the user ID from claims
			var userId = contextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

			// Validate and return the user ID as a Guid if valid
			if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var parsedUserId))
			{
				return null;
			}

			return parsedUserId;
		}
	}
}
