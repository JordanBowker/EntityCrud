namespace EntityCrud.ExampleImplementation.Entities.DataContracts
{
	public interface IExampleEntityFactory
	{
		ExampleEntity Create(int intProp, string stringProp, bool boolProp);
	}
}
