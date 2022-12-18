using System;
namespace SalesApp.Domain
{
	public class Product
	{
		public Guid ProductId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Cost { get; set; }
		public decimal Price { get; set; }
		public decimal Stock { get; set; }

        public List<SaleDetail> SaleDetails { get; set; }

    }
}

