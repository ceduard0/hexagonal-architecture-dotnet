using System;
using SalesApp.Domain.Interfaces;

namespace SalesApp.Domain.Interfaces.Repositories
{
	public interface IMovementRepository<TEntity, TEntityId>: IAdd<TEntity>, IQuery<TEntity, TEntityId>, ITransaction
    {
		void Cancel(TEntityId entityId);
	}
}

