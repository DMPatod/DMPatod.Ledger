using Ledger.Domain.Products;
using Ledger.Domain.Products.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ledger.Infrastructure.DataPersistence.TypeConfigurators
{
    internal class ProductTypeConfigurator : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => ProductId.Create(value));

            builder.Property(p => p.Name);

            builder.Property(p => p.MesureUnit);
        }
    }
}
