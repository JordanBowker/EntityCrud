using Castle.MicroKernel.Lifestyle;
using EntityCrud.ExampleImplementation.Entities;
using EntityCrud.ExampleImplementation.Entities.DataContracts;
using NUnit.Framework;

namespace EntityCrud.IntegrationTests.ExampleImplementation.Entities
{
	[TestFixture]
	public class ExampleEntityRepositoryIntegrationTests : LocalTestBase
	{
		#region IGenericRepository Implementation 

		#region Create

		[Test]
		public void Create()
		{
			//act
			using (WindsorContainer.BeginScope())
			{
				var repository = WindsorContainer.Resolve<IExampleEntityRepository>();
				var actual = repository.Create(new ExampleEntity());

				//assert
				Assert.That(actual.Id, Is.Not.Null);
			}
		}

		#endregion

		#region RetrieveAll

		[Test]
		public void RetrieveAll()
		{
			//arrange
			var entity1 = CreateExampleEntity();
			var entity2 = CreateExampleEntity();
			var entity3 = CreateExampleEntity();

			//act
			using (WindsorContainer.BeginScope())
			{
				var repository = WindsorContainer.Resolve<IExampleEntityRepository>();
				var actual = repository.RetrieveAll();

				//assert
				Assert.That(actual, Has.Count.EqualTo(3));
				Assert.That(actual, Has.Some.EqualTo(entity1).Using(EntityCrudObjectComparer));
				Assert.That(actual, Has.Some.EqualTo(entity2).Using(EntityCrudObjectComparer));
				Assert.That(actual, Has.Some.EqualTo(entity3).Using(EntityCrudObjectComparer));
			}
		}

		#endregion

		#region RetrieveById

		[Test]
		public void RetrieveById()
		{
			//arrange
			var entity = CreateExampleEntity();

			//act
			using (WindsorContainer.BeginScope())
			{
				var repository = WindsorContainer.Resolve<IExampleEntityRepository>();
				var actual = repository.RetrieveById(entity.Id.Value);

				//assert
				Assert.That(actual, Is.EqualTo(entity).Using(EntityCrudObjectComparer));
			}
		}

		#endregion

		#region Save

		[Test]
		public void Save()
		{
			//arrange
			var entity = CreateExampleEntity();

			const int newInt = 66;
			const string newString = "new String";
			const bool newBool = false;

			//act
			using (WindsorContainer.BeginScope())
			{
				var repository = WindsorContainer.Resolve<IExampleEntityRepository>();
				entity = repository.RetrieveById(entity.Id.Value);

				entity.IntegerProperty = newInt;
				entity.StringProperty = newString;
				entity.BooleanProperty = newBool;

				repository.Save();
			}

			//assert
			using (WindsorContainer.BeginScope())
			{
				var repository = WindsorContainer.Resolve<IExampleEntityRepository>();
				var entityFromDb = repository.RetrieveById(entity.Id.Value);

				Assert.That(entityFromDb.IntegerProperty, Is.EqualTo(newInt));
				Assert.That(entityFromDb.BooleanProperty, Is.EqualTo(newBool));
				Assert.That(entityFromDb.StringProperty, Is.EqualTo(newString));
			}
		}

		#endregion

		#region Delete

		[Test]
		public void Delete()
		{
			//arrange
			var entity = CreateExampleEntity();

			//act
			using (WindsorContainer.BeginScope())
			{
				var repository = WindsorContainer.Resolve<IExampleEntityRepository>();
				repository.Delete(entity);
			}

			//assert
			using (WindsorContainer.BeginScope())
			{
				var repository = WindsorContainer.Resolve<IExampleEntityRepository>();
				var entitiesFromDb = repository.RetrieveAll();

				Assert.That(entitiesFromDb, Has.Count.EqualTo(0));
			}
		}

		#endregion

		#endregion

		#region RetrieveAllForTrue

		[Test]
		public void RetrieveAllForTrue()
		{
			//arrange
			CreateExampleEntity(testBool: false);
			var entityWithTrue1 = CreateExampleEntity();
			CreateExampleEntity(testBool: false);
			var entityWithTrue2 = CreateExampleEntity();

			//act
			using (WindsorContainer.BeginScope())
			{
				var repository = WindsorContainer.Resolve<IExampleEntityRepository>();
				var actual = repository.RetrieveAllForTrue();

				//assert
				Assert.That(actual, Has.Count.EqualTo(2));
				Assert.That(actual, Has.Some.EqualTo(entityWithTrue1).Using(EntityCrudObjectComparer));
				Assert.That(actual, Has.Some.EqualTo(entityWithTrue2).Using(EntityCrudObjectComparer));
			}
		}

		#endregion

	}
}
