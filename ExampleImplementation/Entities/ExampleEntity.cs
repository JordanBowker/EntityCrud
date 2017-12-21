using EntityCrud.Domain.Entities;

namespace EntityCrud.ExampleImplementation.Entities
{
	public class ExampleEntity : AbstractEntity
	{
		public virtual int IntegerProperty { get; set; }
		public virtual string StringProperty { get; set; }
		public virtual bool BooleanProperty { get; set; }
	}
}
