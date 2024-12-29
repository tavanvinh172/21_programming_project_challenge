using AutoMapper;
using ExpenseTrackerApi.Entities;
using ExpenseTrackerApi.ViewModels.Accounts;

namespace ExpenseTrackerApi.Models.Accounts.Mapper
{
	public class AccountMapperProfile : Profile
	{
		public AccountMapperProfile() {
			CreateMap<RegisterDto, User>();
			CreateMap<User, LoginResponse>();
		}
	}
}
