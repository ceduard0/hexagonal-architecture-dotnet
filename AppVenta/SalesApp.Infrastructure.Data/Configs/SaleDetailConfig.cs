using System;
using SalesApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SalesApp.Infrastructure.Data.Configs
{
	public class SaleDetailConfig: IEntityTypeConfiguration<SaleDetail>
    {
		public SaleDetailConfig()
		{
		}

        public void Configure(EntityTypeBuilder<SaleDetail> builder)
        {
            builder.ToTable("sal_sale_detail");
            builder.HasKey(c => new { c.SaleId, c.ProductId });
            builder
                .HasOne(detail => detail.Product)
                .WithMany(product => product.SaleDetails);

            builder
                .HasOne(detail => detail.Sale)
                .WithMany(sale => sale.SaleDetails);
        }
    }
}

