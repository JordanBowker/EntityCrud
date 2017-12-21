using EntityCrud.Domain.Entities.DataObjects;
using EntityCrud.Domain.EntityDbContext.DataObjects;
using EntityCrud.Domain.GenericRepository.DataObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EntityCrud.Domain.GenericRepository
{
	public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
	{
		protected internal virtual IEntityDbContext Context { get; set; }

		public GenericRepository(IEntityDbContext context)
		{
			Context = context;
		}

		protected internal virtual IDbSet<TEntity> DbSet => Context.Set<TEntity>();

		public virtual TEntity Create(TEntity entity)
		{
			DbSet.Add(entity);
			Save();
			return entity;
		}

		public virtual List<TEntity> RetrieveAll()
		{
			return DbSet.AsQueryable().ToList();
		}

		public virtual TEntity RetrieveById(int id)
		{
			return DbSet.Find(id);
		}

		public virtual void Delete(TEntity entity)
		{
			var entityToRemove = RetrieveById(entity.Id.Value);
			DbSet.Remove(entityToRemove);
			Save();
		}

		public virtual void Save()
		{
			Context.SaveChanges();
		}

		public virtual void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing && Context != null)
			{
				Context.Dispose();
				Context = null;
			}
		}

	}
}
