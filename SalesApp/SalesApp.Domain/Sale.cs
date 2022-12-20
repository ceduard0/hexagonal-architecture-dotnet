using System;
namespace SalesApp.Domain
{
	public class Sale
	{
		public Guid SaleId { get; set; }
		public long SaleNumber { get; set; }
		public DateTime CretateAt { get; set; }
		public string Concept { get; set; }
		public decimal SubTotal { get; set; }
		public decimal Tax { get; set; }
		public decimal Total { get; set; }
		public bool IsCanceled { get; set; } = false;

		public List<SaleDetail> SaleDetails { get; set; }
	}
}

