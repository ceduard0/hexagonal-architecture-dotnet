using System;
using Microsoft.EntityFrameworkCore;
using SalesApp.Domain;
using SalesApp.Infrastructure.Data.Configs;
namespace SalesApp.Infrastructure.Data.Context
{
	public class SaleContext: DbContext
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<Sale> Sales { get; set; }
		public DbSet<SaleDetail> SaleDetails { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseSqlServer("Server=tcp:localhost,1433;Initial Catalog=SALESDB;Persist Security Info=False;User ID=SA;Password=XXXXXXXX;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30;");
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.ApplyConfiguration(new ProductConfig());
            builder.ApplyConfiguration(new SaleConfig());
            builder.ApplyConfiguration(new SaleDetailConfig());
        }

	}
}

