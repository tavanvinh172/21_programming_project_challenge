namespace ExpenseTrackerApi.Models.Accounts
{
	public class LoginResponse
	{
		public Guid Id { get; set; }
		public string? FullName { get; set; }
		public string? Email { get; set; }
		public string? PasswordHash { get; set; }
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
	}
}
