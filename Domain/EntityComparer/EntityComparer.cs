using System.Collections.Generic;
using EntityCrud.Domain.Entities.DataObjects;

namespace EntityCrud.Domain.EntityComparer
{
	public class EntityComparer : IComparer<IEntity>
	{
		/// <inheritdoc />
		/// <summary>
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public virtual int Compare(IEntity x, IEntity y)
		{
			if (x == null || y == null) return 1;

			return x.Id != y.Id ? 1 : 0;
		}
	}
}
