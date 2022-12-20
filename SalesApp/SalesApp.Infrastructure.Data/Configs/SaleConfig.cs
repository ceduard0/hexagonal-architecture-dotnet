using System;
using SalesApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SalesApp.Infrastructure.Data.Configs
{
	public class SaleConfig: IEntityTypeConfiguration<Sale>
    {
		public SaleConfig()
		{
		}

        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("sal_sale");
            builder.HasKey(c => c.SaleId);
            builder
                .HasMany(sale => sale.SaleDetails)
                .WithOne(saledetail => saledetail.Sale);
        }
    }
}

