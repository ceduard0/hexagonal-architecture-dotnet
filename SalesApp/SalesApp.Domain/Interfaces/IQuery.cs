using System;
namespace SalesApp.Domain.Interfaces
{
	public interface IQuery<TEntity, TEntityId>
	{
		List<TEntity> GetAll();
		TEntity GetById(TEntityId entityId);
    }
}

