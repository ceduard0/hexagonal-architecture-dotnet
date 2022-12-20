using System;
using SalesApp.Domain;
using SalesApp.Domain.Interfaces.Repositories;
using SalesApp.Infrastructure.Data.Context;
namespace SalesApp.Infrastructure.Data.Repositories
{
	public class SaleRepository:IMovementRepository<Sale, Guid>
	{

        private SaleContext db;
		public SaleRepository(SaleContext _db)
		{
            db = _db;
		}

        public Sale Add(Sale entity)
        {
            entity.SaleId = Guid.NewGuid();
            db.Sales.Add(entity);
            return entity;
        }

        public void Cancel(Guid entityId)
        {
            var selectedSale = db.Sales.Where(c => c.SaleId == entityId).FirstOrDefault();
            selectedSale.IsCanceled = true;
            db.Entry(selectedSale).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(Guid entityId)
        {
            var selectedSale = db.Sales.Where(c => c.SaleId == entityId).FirstOrDefault();
            db.Remove(selectedSale);
        }


        public List<Sale> GetAll()
        {
            return db.Sales.ToList();
        }

        public Sale GetById(Guid entityId)
        {
            var selectedSale = db.Sales.Where(c => c.SaleId == entityId).FirstOrDefault();
            return selectedSale;
        }

        public void SaveAll()
        {
            db.SaveChanges();
        }
    }
}

