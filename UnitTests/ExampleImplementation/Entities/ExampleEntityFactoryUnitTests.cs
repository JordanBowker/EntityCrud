using EntityCrud.ExampleImplementation.Entities;
using EntityCrud.ExampleImplementation.Entities.DataContracts;
using Moq;
using NUnit.Framework;

namespace EntityCrud.UnitTests.ExampleImplementation.Entities
{
	[TestFixture]
	public class ExampleEntityFactoryUnitTests
	{
		private ExampleEntityFactory _instance;
		private Mock<IExampleEntityRepository> _exampleEntityRepository;

		[SetUp]
		public void SetUp()
		{
			_exampleEntityRepository = new Mock<IExampleEntityRepository>();
			_instance = new Mock<ExampleEntityFactory>(_exampleEntityRepository.Object) { CallBase = true }.Object;
		}

		#region Create

		[TestCase(4, "stringy", true)]
		[TestCase(3, "not stringy", false)]
		public void Create(int intProp, string stringProp, bool boolProp)
		{
			//arrange
			var expected = new Mock<ExampleEntity>().Object;
			_exampleEntityRepository.Setup(x => x.Create(It.Is<ExampleEntity>(y => y.IntegerProperty == intProp &&
																				   y.StringProperty == stringProp &&
																				   y.BooleanProperty == boolProp)))
													.Returns(expected);

			//act
			var actual = _instance.Create(intProp, stringProp, boolProp);

			//assert	
			Assert.That(actual, Is.EqualTo(expected));
		}

		#endregion

	}
}
