using Ledger.Domain.Tickets.Entity;
using Ledger.Domain.Tickets.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ledger.Infrastructure.DataPersistence.TypeConfigurators
{
    internal class OrderTypeConfigurator : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => OrderId.Create(value));

            builder.HasOne(o => o.Product)
                .WithMany(p => p.Orders)
                .IsRequired();

            builder.Property(o => o.Value);

            builder.Property(o => o.Amount);

            builder.HasOne(o => o.Ticket)
                .WithMany(o => o.Orders)
                .IsRequired();
        }
    }
}
