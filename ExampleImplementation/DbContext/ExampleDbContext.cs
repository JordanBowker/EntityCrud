using EntityCrud.Domain.EntityDbContext;
using EntityCrud.ExampleImplementation.Entities;
using System.Data.Entity;

namespace EntityCrud.ExampleImplementation.DbContext
{
	public class ExampleDbContext : EntityDbContext
	{
		public DbSet<ExampleEntity> TestObjects { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<ExampleEntity>()
						.ToTable("TableName")
						.Property(x => x.StringProperty).HasMaxLength(33);
		}
	}
}
