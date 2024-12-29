using ExpenseTrackerApi.Data;
using ExpenseTrackerApi.Interfaces;
using ExpenseTrackerApi.Models.Accounts.Mapper;
using ExpenseTrackerApi.Repo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

namespace ExpenseTrackerApi.DI
{
	public static class ServiceContainer
	{
		public static IServiceCollection InfrastructureServices(this IServiceCollection services, IConfiguration configuration) {
			services.AddDbContext<AppDbContext>(options => options.UseMySql(
				configuration.GetConnectionString("Default"),
				new MySqlServerVersion(new Version(8, 0, 32)),
				mysqlOptions => mysqlOptions.EnableRetryOnFailure()
			));

			services.AddAuthentication(options => { 
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options =>
			{
				var jwtIssuer = configuration["Jwt:Issuer"];
				var jwtAudience = configuration["Jwt:Audience"];
				var jwtKey = configuration["Jwt:Key"];

                if (string.IsNullOrEmpty(jwtIssuer) || string.IsNullOrEmpty(jwtAudience) || string.IsNullOrEmpty(jwtKey))
                {
					throw new InvalidOperationException("JWT configuration is missing in appsettings.");
                }

				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateIssuerSigningKey = true,
					ValidateLifetime = true,
					ValidIssuer = jwtIssuer,
					ValidAudience = jwtAudience,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
				};
            });

			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			//services.AddAutoMapper(typeof(AccountMapperProfile));
			services.AddScoped<IUserService, UserRepo>();
			services.AddScoped<ICategoryService, CategoryRepo>();
			services.AddScoped<IFinanceService, FinanceRepo>();
			services.AddScoped<TokenService>();
			return services;
		}
	}
}
