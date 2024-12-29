using ExpenseTrackerApi.Entities;
using System.Security.Claims;

namespace ExpenseTrackerApi.Utils
{
	public static class ClaimsPrincipalExtensions
	{
		public static User? GetCurrentUser(this ClaimsPrincipal user)
		{
			var nameIdenitifer = user?.FindFirstValue(ClaimTypes.NameIdentifier);
			var name = user?.Identity?.Name;
			var email = user?.FindFirstValue(ClaimTypes.Email);
			if (nameIdenitifer != null && name != null && email != null)
			{
				return new User
				{
					Id = new Guid(nameIdenitifer.ToString()),
					FullName = name,
					Email = email
				};
			}
			return null;
		}
	}
}
