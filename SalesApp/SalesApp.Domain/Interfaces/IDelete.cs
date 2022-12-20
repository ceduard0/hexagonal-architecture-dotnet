using System;
namespace SalesApp.Domain.Interfaces
{
	public interface IDelete<TEntityId>
	{
		void Delete(TEntityId entityId);
	}
}

