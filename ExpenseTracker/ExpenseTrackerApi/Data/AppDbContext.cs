using ExpenseTrackerApi.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ExpenseTrackerApi.Data
{
	public class AppDbContext : DbContext
	{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Finance> Finances { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Category>()
                .HasOne(c => c.User)
                .WithMany(u => u.Categories)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Finance>()
                .HasOne(f => f.Users)
                .WithMany(u => u.Finances)
                .HasForeignKey(f => f.UserId);

            modelBuilder.Entity<Finance>()
                .HasOne(f => f.Category)
                .WithMany(c => c.Finances)
                .HasForeignKey(f => f.CategoryId);

            modelBuilder.Entity<Budget>()
                .HasOne(b => b.Users)
                .WithMany(u => u.Budgets)
                .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<Budget>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Budgets)
                .HasForeignKey(b => b.CategoryId)
                .IsRequired(false);

            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = Guid.Parse("8d2003ec-b650-4609-b987-8a8da342f1fa"),
                Email = "tavanvinh172@gmail.com",
                FullName = "Vinh",
                PasswordHash = "$2a$11$CaL.cJ7iJzDDW05Y6z8kf.j5RX2M6PrXoh2la.8n4SL2LxeBxob26"
			});

            modelBuilder.Entity<Category>().HasData(new List<Category>()
                {
                    new Category { Name = "Food & Dining", UserId = Guid.Parse("8d2003ec-b650-4609-b987-8a8da342f1fa")},
                    new Category { Name = "Housing", UserId = Guid.Parse("8d2003ec-b650-4609-b987-8a8da342f1fa")},
					new Category { Name = "Transportation", UserId = Guid.Parse("8d2003ec-b650-4609-b987-8a8da342f1fa")},
					new Category { Name = "Health & Wellness", UserId = Guid.Parse("8d2003ec-b650-4609-b987-8a8da342f1fa")}
				}
			);

			base.OnModelCreating(modelBuilder);
		}
	}
}
