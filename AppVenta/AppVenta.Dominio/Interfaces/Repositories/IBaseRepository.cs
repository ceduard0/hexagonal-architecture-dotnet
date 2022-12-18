using System;
using SalesApp.Domain.Interfaces;

namespace SalesApp.Domain.Interfaces.Repositories
{
	public interface IBaseRepository<TEntity, TEntityId>: IAdd<TEntity>, IEdit<TEntity>, IDelete<TEntityId>, IQuery<TEntity, TEntityId>, ITransaction
    {
	}
}

