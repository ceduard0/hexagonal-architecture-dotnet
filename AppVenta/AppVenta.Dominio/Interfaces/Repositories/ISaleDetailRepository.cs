using System;
using SalesApp.Domain.Interfaces;

namespace SalesApp.Domain.Interfaces.Repositories
{
	public interface ISaleDetailRepository<TEntity, TMovementId>: IAdd<TEntity>, ITransaction
    {
	}
}

