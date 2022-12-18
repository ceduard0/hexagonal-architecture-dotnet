using System;
using SalesApp.Domain;
using SalesApp.Domain.Interfaces.Repositories;
using SalesApp.Infrastructure.Data.Context;

namespace SalesApp.Infrastructure.Data.Repositories
{
	public class SaleDetailRepository:ISaleDetailRepository<SaleDetail,Guid>
	{
        private SaleContext db;
        public SaleDetailRepository(SaleContext _db)
		{
            db = _db;
		}

        public SaleDetail Add(SaleDetail entity)
        {
            db.SaleDetails.Add(entity);
            return entity;
        }

        public void SaveAll()
        {
            db.SaveChanges();
        }
    }
}

