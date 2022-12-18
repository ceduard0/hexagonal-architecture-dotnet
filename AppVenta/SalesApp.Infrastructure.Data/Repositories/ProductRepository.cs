using System;
using SalesApp.Domain;
using SalesApp.Domain.Interfaces.Repositories;
using SalesApp.Infrastructure.Data.Context;
namespace SalesApp.Infrastructure.Data.Repositories
{
	public class ProductRepository: IBaseRepository<Product, Guid>
	{
        private SaleContext db;
		public ProductRepository(SaleContext _db)
		{
            db = _db;
		}

        public Product Add(Product entity)
        {
            entity.ProductId = Guid.NewGuid();
            db.Products.Add(entity);
            return entity;
        }

        public void Delete(Guid entityId)
        {
            var selectedProduct = db.Products.Where(c => c.ProductId == entityId).FirstOrDefault();
            if (selectedProduct != null)
            {
                db.Products.Remove(selectedProduct);
            }
        }

        public void Edit(Product entity)
        {
            var selectedProduct = db.Products.Where(c => c.ProductId == entity.ProductId).FirstOrDefault();
            if (selectedProduct != null)
            {
                selectedProduct.Name = entity.Name;
                selectedProduct.Description = entity.Description;
                selectedProduct.Cost = entity.Cost;
                selectedProduct.Price = entity.Price;
                selectedProduct.Stock = entity.Stock;
                db.Entry(selectedProduct).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public List<Product> GetAll()
        {
            return db.Products.ToList();
        }

        public Product GetById(Guid entityId)
        {
            var selectedProduct = db.Products.Where(c => c.ProductId == entityId).FirstOrDefault();
            return selectedProduct;
        }

        public void SaveAll()
        {
            db.SaveChanges();
        }
    }
}

