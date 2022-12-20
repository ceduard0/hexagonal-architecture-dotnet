using System;
using SalesApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SalesApp.Infrastructure.Data.Configs
{
	public class ProductConfig:IEntityTypeConfiguration<Product>
	{
		public ProductConfig()
		{
		}

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("sal_product");
            builder.HasKey(c => c.ProductId);

            builder
                .HasMany(product => product.SaleDetails)
                .WithOne(saledetail => saledetail.Product);
        }
    }
}

