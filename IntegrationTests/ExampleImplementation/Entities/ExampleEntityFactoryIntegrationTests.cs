using NUnit.Framework;

namespace EntityCrud.IntegrationTests.ExampleImplementation.Entities
{
	[TestFixture]
	public class ExampleEntityFactoryIntegrationTests : LocalTestBase
	{
		#region Create

		[TestCase(5, "teststring", true)]
		[TestCase(25, "foo", false)]
		public void Create(int exampleInt, string exampleString, bool exampleBool)
		{
			//act
			var actual = CreateExampleEntity(exampleInt, exampleString, exampleBool);

			//assert
			Assert.That(actual.Id, Is.Not.Null);
			Assert.That(actual.IntegerProperty, Is.EqualTo(exampleInt));
			Assert.That(actual.StringProperty, Is.EqualTo(exampleString));
			Assert.That(actual.BooleanProperty, Is.EqualTo(exampleBool));
		}

		#endregion

	}
}
