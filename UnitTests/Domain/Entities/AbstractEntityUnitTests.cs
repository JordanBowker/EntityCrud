using EntityCrud.Domain.Entities;
using Moq;
using NUnit.Framework;

namespace EntityCrud.UnitTests.Domain.Entities
{
	[TestFixture]
	public class AbstractEntityUnitTests
	{
		private Mock<AbstractEntity> _instance;

		[SetUp]
		public void SetUp()
		{
			_instance = new Mock<AbstractEntity> { CallBase = true };
		}

		#region Properties and Fields

		#region IsPersisted

		[TestCase(4, true)]
		[TestCase(null, false)]
		public void IsPersisted(int? id, bool expected)
		{
			//arrange
			_instance.SetupGet(x => x.Id).Returns(id);

			//act
			var actual = _instance.Object.IsPersisted;

			//assert			
			Assert.That(actual, Is.EqualTo(expected));
		}

		#endregion

		#endregion

	}
}
