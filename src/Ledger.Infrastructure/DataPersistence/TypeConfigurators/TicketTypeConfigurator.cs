using Ledger.Domain.Tickets;
using Ledger.Domain.Tickets.ValueObjects;
using Ledger.Infrastructure.DataPersistence.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ledger.Infrastructure.DataPersistence.TypeConfigurators
{
    internal class TicketTypeConfigurator : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable("Tickets");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => TicketId.Create(value));

            builder.HasOne(t => t.Provider)
                .WithMany()
                .IsRequired();

            builder.Property(t => t.Date);

            builder.HasMany(t => t.Orders)
                .WithOne()
                .IsRequired();

            builder.Property(t => t.Installments);

            builder.Property(t => t.Currency)
                .HasConversion(EnumsConverters.CurrencyConverter);

            builder.Property(t => t.Direction)
                .HasConversion(EnumsConverters.DirectionConverter);
        }
    }
}
