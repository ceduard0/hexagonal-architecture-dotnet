using System;
namespace SalesApp.Domain
{
	public class SaleDetail
	{
		public Guid ProductId { get; set; }
		public Guid SaleId { get; set; }
		public decimal UnitCost { get; set; }
		public decimal UnitPrice { get; set; }
		public decimal SoldQuantity { get; set; }
		public decimal SubTotal { get; set; }
		public decimal Tax { get; set; }
		public decimal Total { get; set; }

		public Product Product { get; set; }
		public Sale Sale { get; set; }
    }
}

