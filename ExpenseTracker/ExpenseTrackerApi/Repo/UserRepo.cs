using AutoMapper;

using ExpenseTrackerApi.Data;
using ExpenseTrackerApi.Entities;
using ExpenseTrackerApi.Interfaces;
using ExpenseTrackerApi.Models.Accounts;
using ExpenseTrackerApi.Utils;
using ExpenseTrackerApi.ViewModels.Accounts;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;

namespace ExpenseTrackerApi.Repo
{
	public class UserRepo : IUserService
	{
		private readonly AppDbContext _appDbContext;
		private readonly IConfiguration configuration;
		private readonly TokenService tokenService;
		private readonly IMapper mapper;
		public UserRepo(AppDbContext appDbContext, IConfiguration configuration, TokenService tokenService, IMapper mapper)
		{
			_appDbContext = appDbContext;
			this.configuration = configuration;
			this.tokenService = tokenService;
			this.mapper = mapper;
		}
		public async Task<Payload<LoginResponse>> Login(LoginDto loginDto)
		{
			if (loginDto == null) throw new ArgumentNullException(nameof(loginDto));
			var getUser = await findUserByEmail(loginDto.Email);
			if (getUser == null) {
				return Payload<LoginResponse>.RequestInvalid("User not found");
			}
			bool checkPassword = BCrypt.Net.BCrypt.Verify(loginDto.Password, getUser.PasswordHash);
			if (checkPassword)
			{
				var loginResponse = mapper.Map<LoginResponse>(getUser);
				var claims = GenerateClaims(getUser);
				loginResponse.AccessToken = tokenService.GenerateAccessToken(claims);
				var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims));
				var currentUser = GetCurrentUser(claimsPrincipal);
				loginResponse.RefreshToken = tokenService.GenerateRefreshToken();
				return Payload<LoginResponse>.Successfully(loginResponse, "Login Successfully");
			}
			return Payload<LoginResponse>.BadRequest("Password Not Match");
		}

		public async Task<Payload<User>> Register(RegisterDto registerDto)
		{
			if (registerDto == null) throw new ArgumentNullException(nameof(registerDto));

			var getUser = await findUserByEmail(registerDto.Email);
			if (getUser != null) return Payload<User>.RequestInvalid("User already exists");

			if (string.IsNullOrEmpty(registerDto.Email) || string.IsNullOrEmpty(registerDto.Password)) {
				return Payload<User>.RequestInvalid("Username and Password are required");
			}

			var user = mapper.Map<User>(registerDto);
			user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);
			_appDbContext.Users.Add(user);
			//RegisterResponse response = mapper.Map<RegisterResponse>(registerDto);
			var defaultCategories = Constants.DefaultCategories.Select(category => new Category
			{
				Name = category.Name,
				IconUrl = category.IconUrl,
				UserId = user.Id,
			});
			_appDbContext.Categories.AddRange(defaultCategories);
			await _appDbContext.SaveChangesAsync();
			return Payload<User>.Successfully(user, "OK");
		}

		private async Task<User?> findUserByEmail(string? email)
		{
			if (email == null || string.IsNullOrEmpty(email)) return null;
			return await _appDbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
		}

		private async Task<User?> findUserById(Guid? uid)
		{
			if (uid == null || uid == Guid.Empty) return null;
			return await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == uid);
		}

		private Claim[] GenerateClaims(User user)
		{
			var userClaims = new[] {
				new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
				new Claim(ClaimTypes.Name, user.FullName!),
				new Claim(ClaimTypes.Email, user.Email!)
			};
			return userClaims;
		}

		public User? GetCurrentUser(ClaimsPrincipal user)
		{
			var nameIdenitifer = user?.FindFirstValue(ClaimTypes.NameIdentifier);
			var name = user?.Identity?.Name;
			var email = user?.FindFirstValue(ClaimTypes.Email);
			if (nameIdenitifer != null && name != null && email != null) {
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
