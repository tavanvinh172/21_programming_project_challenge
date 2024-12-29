using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerApi.Base
{
	public interface IDatabaseContext : IInfrastructure<IServiceProvider>, /*IDbContextDependencies, IDbSetCache, IDbContextPoolable,*/ IResettableService, IDisposable, IAsyncDisposable
	{
		int SaveChanges();
		DbSet<T> Set<T>() where T : class;
		EntityEntry<T> Update<T>(T item) where T : class;
	}
}
