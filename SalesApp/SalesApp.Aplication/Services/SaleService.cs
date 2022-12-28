using System;
using SalesApp.Domain;
using SalesApp.Domain.Interfaces;
using SalesApp.Domain.Interfaces.Repositories;
using SalesApp.Aplication.Interfaces;

namespace SalesApp.Aplication.Services
{
	public class SaleService: ISaleServices<Sale, Guid>
	{
        private const decimal DEFAULT_TAX = 15;
        private const decimal DEFAULT_DIV = 100;
        private readonly IMovementRepository<Sale, Guid> saleRepository;
        private readonly ISaleDetailRepository<SaleDetail, Guid> saleDetailRepository;
        private readonly IBaseRepository<Product, Guid> productRepository;

        public SaleService(IMovementRepository<Sale, Guid> _saleRepository
                          ,IBaseRepository<Product, Guid> _productRepository
                          ,ISaleDetailRepository<SaleDetail, Guid> _saleDetailRepository)
		{
            saleRepository = _saleRepository;
            productRepository = _productRepository;
            saleDetailRepository = _saleDetailRepository;
		}

        public Sale Add(Sale entity)
        {
            if (entity == null) 
                throw new ArgumentNullException("The sale is required");

            var sale = saleRepository.Add(entity);
            entity.SaleDetails.ForEach(detail =>
            {
                var selectedProduct = productRepository.GetById(detail.ProductId);
                if (selectedProduct == null)
                    throw new ArgumentNullException("The product is required");


                detail.SaleId = sale.SaleId;
                detail.ProductId = selectedProduct.ProductId;
                detail.UnitCost = selectedProduct.Cost;
                detail.UnitPrice = selectedProduct.Price;
                detail.SoldQuantity = detail.SoldQuantity;
                detail.SubTotal = detail.UnitPrice * detail.SoldQuantity;
                detail.Tax = detail.SubTotal * DEFAULT_TAX / DEFAULT_DIV;
                detail.Total = detail.SubTotal + detail.Tax;
                saleDetailRepository.Add(detail);

                selectedProduct.Stock -= detail.SoldQuantity;
                productRepository.Edit(selectedProduct);
                entity.SubTotal += detail.SubTotal;
                entity.Tax += detail.Tax;
                entity.Total += detail.Total;
            });

            saleRepository.SaveAll();
            return entity;
        }

        public void Cancel(Guid entityId)
        {
            saleRepository.Cancel(entityId);
            saleRepository.SaveAll();
        }

        public List<Sale> GetAll()
        {
            return saleRepository.GetAll();
        }

        public Sale GetById(Guid entityId)
        {
                return saleRepository.GetById(entityId);
        }
    }
}

