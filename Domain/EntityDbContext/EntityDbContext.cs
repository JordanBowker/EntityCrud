using EntityCrud.Domain.EntityDbContext.DataObjects;
using System.Data.Entity;
using EntityCrud.Domain.Entities.DataObjects;

namespace EntityCrud.Domain.EntityDbContext
{
	public class EntityDbContext : DbContext, IEntityDbContext
	{
		public new IDbSet<TEntity> Set<TEntity>() where TEntity : class, IEntity
		{
			return base.Set<TEntity>();
		}
	}
}