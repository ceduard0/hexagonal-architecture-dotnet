using System;
using SalesApp.Domain.Interfaces;
namespace SalesApp.Aplication.Interfaces
{
	public interface ISaleServices<TEntity, TEntityId>:IAdd<TEntity>, IQuery<TEntity, TEntityId>
	{
		void Cancel(TEntityId entityId);
	}
}

