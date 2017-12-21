using EntityCrud.ExampleImplementation.Entities.DataContracts;

namespace EntityCrud.ExampleImplementation.Entities
{
	public class ExampleEntityFactory : IExampleEntityFactory
	{
		private readonly IExampleEntityRepository _testEntityRepository;

		public ExampleEntityFactory(IExampleEntityRepository testEntityRepository)
		{
			_testEntityRepository = testEntityRepository;
		}


		#region Create

		/// <summary>
		/// 
		/// </summary>
		/// <param name="intProp"></param>
		/// <param name="stringProp"></param>
		/// <param name="boolProp"></param>
		/// <returns></returns>
		public virtual ExampleEntity Create(int intProp, string stringProp, bool boolProp)
		{
			var unpersistedEntity = new ExampleEntity { IntegerProperty = intProp, StringProperty = stringProp, BooleanProperty = boolProp };
			return _testEntityRepository.Create(unpersistedEntity);
		}

		#endregion

	}
}
