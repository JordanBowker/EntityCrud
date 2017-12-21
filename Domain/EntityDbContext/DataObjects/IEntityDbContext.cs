using System.Data.Entity;
using EntityCrud.Domain.Entities.DataObjects;

namespace EntityCrud.Domain.EntityDbContext.DataObjects
{
	public interface IEntityDbContext
	{
		IDbSet<TEntity> Set<TEntity>() where TEntity : class, IEntity;
		int SaveChanges();
		void Dispose();
	}
}
