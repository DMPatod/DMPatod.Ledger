using Ledger.Domain.Bills;
using Ledger.Domain.Bills.ValueObjects;
using Ledger.Infrastructure.DataPersistence.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ledger.Infrastructure.DataPersistence.TypeConfigurators;

internal class BillTypeConfigurator : IEntityTypeConfiguration<Bill>
{
    public void Configure(EntityTypeBuilder<Bill> builder)
    {
        builder.ToTable("Bills");

        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => BillId.Create(value));

        builder.HasOne(t => t.Provider)
            .WithMany()
            .IsRequired();

        builder.Property(b => b.Date);

        builder.Property(b => b.DueDate);

        builder.Property(b => b.Value)
            .HasPrecision(18, 2);

        builder.Property(b => b.Currency)
            .HasConversion(EnumsConverters.CurrencyConverter);
    }
}
