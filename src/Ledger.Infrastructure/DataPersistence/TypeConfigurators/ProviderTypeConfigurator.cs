using Ledger.Domain.Providers;
using Ledger.Domain.Providers.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ledger.Infrastructure.DataPersistence.TypeConfigurators
{
    internal class ProviderTypeConfigurator : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.ToTable("Providers");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => ProviderId.Create(value));

            builder.Property(p => p.Name);
        }
    }
}
