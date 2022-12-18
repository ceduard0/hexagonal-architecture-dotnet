using System;
namespace SalesApp.Domain.Interfaces
{
	public interface IEdit<TEntity>
	{
        void Edit(TEntity entity);
    }
}

