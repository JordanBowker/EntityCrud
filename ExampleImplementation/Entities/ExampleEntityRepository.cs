using EntityCrud.Domain.EntityDbContext.DataObjects;
using EntityCrud.Domain.GenericRepository;
using EntityCrud.ExampleImplementation.Entities.DataContracts;
using System.Collections.Generic;
using System.Linq;

namespace EntityCrud.ExampleImplementation.Entities
{
	public class ExampleEntityEntityRepository : GenericRepository<ExampleEntity>, IExampleEntityRepository
	{
		public ExampleEntityEntityRepository(IEntityDbContext context) : base(context)
		{
		}

		#region RetrieveAllForTrue

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public virtual List<ExampleEntity> RetrieveAllForTrue()
		{
			return RetrieveAsQueryable().Where(x => x.BooleanProperty).ToList();
		}

		protected internal virtual IQueryable<ExampleEntity> RetrieveAsQueryable()
		{
			return DbSet.AsQueryable();
		}

		#endregion

	}
}
