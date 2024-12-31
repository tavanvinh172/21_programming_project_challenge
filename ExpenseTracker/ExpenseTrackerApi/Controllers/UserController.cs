using ExpenseTrackerApi.Entities;
using ExpenseTrackerApi.Interfaces;
using ExpenseTrackerApi.Models.Accounts;
using ExpenseTrackerApi.ViewModels.Accounts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ExpenseTrackerApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserService user;

		public UserController(IUserService user)
		{
			this.user = user;
		}

		[HttpPost(nameof(RegisterUser))]
		public async Task<Payload<User>> RegisterUser(RegisterDto registerDto)
		{
			return await user.Register(registerDto);
		}

		[HttpPost(nameof(LoginUser))]
		public async Task<Payload<LoginResponse>> LoginUser(LoginDto loginDto)
		{
			return await user.Login(loginDto);
		}

		[HttpGet]
		public IActionResult GetCurrentUser()
		{
			var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; // Extract 'sub' claim
			var username = User.Identity?.Name;       // Extract username if present

			return Ok(new { UserId = userId, Username = username });
		}
	}
}
