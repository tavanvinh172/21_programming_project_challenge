using ExpenseTrackerApi.Entities;
using ExpenseTrackerApi.Models.Accounts;
using ExpenseTrackerApi.ViewModels.Accounts;

namespace ExpenseTrackerApi.Interfaces
{
	public interface IUserService
	{
		Task<Payload<User>> Register(RegisterDto registerDto);
		Task<Payload<LoginResponse>> Login(LoginDto loginDto);
	}
}
