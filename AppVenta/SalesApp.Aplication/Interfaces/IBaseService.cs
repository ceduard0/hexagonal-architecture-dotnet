using System;
using SalesApp.Domain.Interfaces;
namespace SalesApp.Aplication.Interfaces
{
	public interface IBaseService<TEntity, TEntityId> : IAdd<TEntity>, IEdit<TEntity>, IDelete<TEntityId>, IQuery<TEntity, TEntityId>
    {
	}
}

