using EntityCrud.Domain.GenericRepository.DataObjects;
using System.Collections.Generic;

namespace EntityCrud.ExampleImplementation.Entities.DataContracts
{
	public interface IExampleEntityRepository : IGenericRepository<ExampleEntity>
	{
		List<ExampleEntity> RetrieveAllForTrue();
	}
}
