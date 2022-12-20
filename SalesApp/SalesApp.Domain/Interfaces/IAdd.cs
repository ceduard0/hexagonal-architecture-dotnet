using System;
namespace SalesApp.Domain.Interfaces
{
	public interface IAdd<TEntity>
	{
        TEntity Add(TEntity entity);
    }
}

