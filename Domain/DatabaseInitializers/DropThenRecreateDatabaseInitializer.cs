using System.Data.Entity;

namespace EntityCrud.Domain.DatabaseInitializers
{
	public class DropThenRecreateDatabaseInitializer : IDatabaseInitializer<EntityDbContext.EntityDbContext>
	{
		public void InitializeDatabase(EntityDbContext.EntityDbContext context)
		{
			context.Database.Delete();
			context.Database.Create();
		}
	}
}
