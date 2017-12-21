using EntityCrud.Domain.Entities.DataObjects;
using Moq;
using NUnit.Framework;

namespace EntityCrud.UnitTests.Domain.EntityComparer
{
	[TestFixture]
	public class EntityComparerUnitTests
	{
		private EntityCrud.Domain.EntityComparer.EntityComparer _instance;

		[SetUp]
		public void SetUp()
		{
			_instance = new Mock<EntityCrud.Domain.EntityComparer.EntityComparer> { CallBase = true }.Object;
		}

		#region Compare

		[Test]
		public void Compare_WHERE_objectX_is_null_SHOULD_return_1()
		{
			//arrange
			var objectY = new Mock<IEntity>().Object;

			//act
			var actual = _instance.Compare(null, objectY);

			//assert
			Assert.That(actual, Is.EqualTo(1));
		}

		[Test]
		public void Compare_WHERE_objectY_is_null_SHOULD_return_1()
		{
			//arrange
			var objectX = new Mock<IEntity>().Object;

			//act
			var actual = _instance.Compare(objectX, null);

			//assert
			Assert.That(actual, Is.EqualTo(1));
		}

		[Test]
		public void Compare_WHERE_objectX_has_a_different_id_to_objectY_SHOULD_return_1()
		{
			//arrange
			var objectX = new Mock<IEntity>();
			var objectY = new Mock<IEntity>();

			objectX.Setup(x => x.Id).Returns(4);
			objectY.Setup(x => x.Id).Returns(466);

			//act
			var actual = _instance.Compare(objectX.Object, objectY.Object);

			//assert
			Assert.That(actual, Is.EqualTo(1));
		}

		[Test]
		public void Compare_WHERE_objectX_has_the_same_id_as_objectY_SHOULD_return_0()
		{
			//arrange
			var objectX = new Mock<IEntity>();
			var objectY = new Mock<IEntity>();

			const int id = 5;
			objectX.Setup(x => x.Id).Returns(id);
			objectY.Setup(x => x.Id).Returns(id);

			//act
			var actual = _instance.Compare(objectX.Object, objectY.Object);

			//assert
			Assert.That(actual, Is.EqualTo(0));
		}

		#endregion

	}
}
