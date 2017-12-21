using EntityCrud.ExampleImplementation.Entities;
using NUnit.Framework;

namespace EntityCrud.IntegrationTests.Domain.Entities
{
	[TestFixture]
	public class AbstractEntityIntegrationTests : LocalTestBase
	{
		#region IsPersisted

		[Test]
		public void IsPersisted_WHERE_entity_is_not_persisted_SHOULD_return_false()
		{
			//act
			var actual = new ExampleEntity();

			//assert
			Assert.That(actual.IsPersisted, Is.False);
		}

		[Test]
		public void IsPersisted_WHERE_entity_is_persisted_SHOULD_return_true()
		{
			//act
			var actual = CreateExampleEntity();

			//assert
			Assert.That(actual.IsPersisted);
		}

		#endregion

	}
}
