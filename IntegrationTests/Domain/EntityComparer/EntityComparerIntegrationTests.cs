using NUnit.Framework;

namespace EntityCrud.IntegrationTests.Domain.EntityComparer
{
	[TestFixture]
	public class EntityComparerIntegrationTests : LocalTestBase
	{
		#region Compare

		[Test]
		public void Compare_WHERE_objectY_is_null_SHOULD_return_1()
		{
			//act
			var actual = EntityCrudObjectComparer.Compare(CreateExampleEntity(), null);

			//assert
			Assert.That(actual, Is.EqualTo(1));
		}

		[Test]
		public void Compare_WHERE_objectX_is_null_SHOULD_return_1()
		{
			//act
			var actual = EntityCrudObjectComparer.Compare(null, CreateExampleEntity());

			//assert
			Assert.That(actual, Is.EqualTo(1));
		}

		[Test]
		public void Compare_WHERE_objectX_has_a_different_id_to_objectY_SHOULD_return_1()
		{
			//act
			var actual = EntityCrudObjectComparer.Compare(CreateExampleEntity(), CreateExampleEntity());

			//assert
			Assert.That(actual, Is.EqualTo(1));
		}

		[Test]
		public void Compare_WHERE_objectX_has_the_same_id_as_objectY_SHOULD_return_0()
		{
			//arrange
			var testCrudObject = CreateExampleEntity();

			//act
			var actual = EntityCrudObjectComparer.Compare(testCrudObject, testCrudObject);

			//assert
			Assert.That(actual, Is.EqualTo(0));
		}

		#endregion

	}

}
