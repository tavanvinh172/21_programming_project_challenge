﻿namespace ExpenseTrackerApi.Models.Accounts
{
	public class RegisterResponse
	{
        public Guid Id { get; set; }
        public string? FullName { get; set; }
		public string? Email { get; set; }
		public string? PasswordHash { get; set; }
	}
}
