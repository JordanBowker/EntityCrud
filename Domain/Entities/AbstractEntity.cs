using EntityCrud.Domain.Entities.DataObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityCrud.Domain.Entities
{
	public abstract class AbstractEntity : IEntity
	{
		#region Properties and Fields

		[Key]
		public virtual int? Id { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[NotMapped]
		public virtual bool IsPersisted => Id.HasValue;

		#endregion

	}
}
