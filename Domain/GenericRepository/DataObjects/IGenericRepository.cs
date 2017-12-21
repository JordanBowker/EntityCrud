using EntityCrud.Domain.Entities.DataObjects;
using System;
using System.Collections.Generic;

namespace EntityCrud.Domain.GenericRepository.DataObjects
{
	public interface IGenericRepository<TEntity> : IDisposable where TEntity : IEntity
	{
		TEntity Create(TEntity entity);
		List<TEntity> RetrieveAll();
		TEntity RetrieveById(int id);
		void Save();
		void Delete(TEntity entity);
	}
}
