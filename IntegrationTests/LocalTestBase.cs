using Castle.MicroKernel.Lifestyle;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using EntityCrud.Domain.DatabaseInitializers;
using EntityCrud.Domain.EntityComparer;
using EntityCrud.Domain.EntityDbContext.DataObjects;
using EntityCrud.Domain.GenericRepository;
using EntityCrud.Domain.GenericRepository.DataObjects;
using EntityCrud.ExampleImplementation.DbContext;
using EntityCrud.ExampleImplementation.Entities;
using EntityCrud.ExampleImplementation.Entities.DataContracts;
using NUnit.Framework;

namespace EntityCrud.IntegrationTests
{
	public class LocalTestBase
	{
		public virtual WindsorContainer WindsorContainer { get; set; }
		public virtual EntityComparer EntityCrudObjectComparer => new EntityComparer();

		[SetUp]
		public void Setup()
		{
			IntialiseDbContext();
			CreateAndRegisterWindsorContainer();
		}

		protected internal void IntialiseDbContext()
		{
			var dbContext = new ExampleDbContext();
			var dataBaseInitializer = new DropThenRecreateDatabaseInitializer();
			dataBaseInitializer.InitializeDatabase(dbContext);
		}

		protected internal void CreateAndRegisterWindsorContainer()
		{
			WindsorContainer = new WindsorContainer();

			WindsorContainer.Register(Component.For<IEntityDbContext>().ImplementedBy<ExampleDbContext>().LifestyleScoped());
			WindsorContainer.Register(Component.For(typeof(IGenericRepository<>)).ImplementedBy(typeof(GenericRepository<>)).LifestyleScoped());
			WindsorContainer.Register(Component.For<IExampleEntityRepository>().ImplementedBy<ExampleEntityEntityRepository>().LifestyleScoped());
			WindsorContainer.Register(Component.For<IExampleEntityFactory>().ImplementedBy<ExampleEntityFactory>().LifestyleScoped());
		}

		protected internal ExampleEntity CreateExampleEntity(int testInt = 4, string testString = "testtest", bool testBool = true)
		{
			using (WindsorContainer.BeginScope())
			{
				return WindsorContainer.Resolve<IExampleEntityFactory>().Create(testInt, testString, testBool);
			}
		}
	}
}
