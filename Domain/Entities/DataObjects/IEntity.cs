namespace EntityCrud.Domain.Entities.DataObjects
{
	public interface IEntity
	{
		int? Id { get; set; }
		bool IsPersisted { get; }
	}
}
