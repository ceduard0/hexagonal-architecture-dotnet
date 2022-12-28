using System;
using SalesApp.Domain;
using SalesApp.Domain.Interfaces.Repositories;
using SalesApp.Aplication.Interfaces;

namespace SalesApp.Aplication.Services
{
	public class ProductService: IBaseService<Product, Guid>
	{
        private readonly IBaseRepository<Product, Guid> productRepository;

		public ProductService(IBaseRepository<Product, Guid> _productRepository)
		{
            productRepository = _productRepository;
		}

        public Product Add(Product entity)
        {
            if (entity is null)
                throw new ArgumentNullException("The product is required");

            var result = productRepository.Add(entity);
            productRepository.SaveAll();
            return result;

        }

        public void Delete(Guid entityId)
        {
            if (entityId == null) 
                throw new ArgumentNullException("The product is required");

            productRepository.Delete(entityId);
            productRepository.SaveAll();
        }

        public void Edit(Product entity)
        {
            if (entity == null) 
                throw new ArgumentNullException("The product is required");

            productRepository.Edit(entity);
            productRepository.SaveAll();
        }

        public List<Product> GetAll()
        {
            return productRepository.GetAll();
        }

        public Product GetById(Guid entityId)
        {
            return productRepository.GetById(entityId);
        }
    }
}

