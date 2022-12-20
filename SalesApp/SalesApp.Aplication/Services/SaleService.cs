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

                var saleDetail = new SaleDetail();
                saleDetail.SaleId = sale.SaleId;
                saleDetail.ProductId = selectedProduct.ProductId;
                saleDetail.UnitCost = selectedProduct.Cost;
                saleDetail.UnitPrice = selectedProduct.Price;
                saleDetail.SoldQuantity = detail.SoldQuantity;
                saleDetail.SubTotal = detail.UnitPrice * detail.SoldQuantity;
                saleDetail.Tax = detail.SubTotal * DEFAULT_TAX / DEFAULT_DIV;
                saleDetail.Total = saleDetail.SubTotal + saleDetail.Tax;
                saleDetailRepository.Add(saleDetail);

                selectedProduct.Stock -= saleDetail.SoldQuantity;
                productRepository.Edit(selectedProduct);
                entity.SubTotal += saleDetail.SubTotal;
                entity.Tax += saleDetail.Tax;
                entity.Total += saleDetail.Total;
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

