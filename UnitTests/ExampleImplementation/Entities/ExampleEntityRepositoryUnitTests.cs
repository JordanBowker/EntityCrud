using EntityCrud.Domain.EntityDbContext.DataObjects;
using EntityCrud.ExampleImplementation.Entities;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace EntityCrud.UnitTests.ExampleImplementation.Entities
{
	[TestFixture]
	public class ExampleEntityRepositoryUnitTests
	{
		private Mock<ExampleEntityEntityRepository> _instance;

		[SetUp]
		public void SetUp()
		{
			var dbContext = new Mock<IEntityDbContext>();
			_instance = new Mock<ExampleEntityEntityRepository>(dbContext.Object) { CallBase = true };
		}

		#region RetrieveAllForTrue

		[Test]
		public void RetrieveAllForTrue()
		{
			//arrange
			var trueEntity1 = new Mock<ExampleEntity>();
			var falseEntity = new Mock<ExampleEntity>();
			var trueEntity2 = new Mock<ExampleEntity>();
			var exampleEntities = new List<ExampleEntity> { trueEntity1.Object, falseEntity.Object, trueEntity2.Object };

			_instance.Setup(x => x.RetrieveAsQueryable()).Returns(exampleEntities.AsQueryable);

			trueEntity1.Setup(x => x.BooleanProperty).Returns(true);
			falseEntity.Setup(x => x.BooleanProperty).Returns(false);
			trueEntity2.Setup(x => x.BooleanProperty).Returns(true);

			//act
			var actual = _instance.Object.RetrieveAllForTrue();

			//assert	
			Assert.That(actual, Has.Count.EqualTo(2));
			Assert.That(actual, Has.Some.EqualTo(trueEntity1.Object));
			Assert.That(actual, Has.Some.EqualTo(trueEntity2.Object));
		}

		#endregion

	}

}


