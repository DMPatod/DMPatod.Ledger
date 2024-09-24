using Ledger.Domain.Tickets.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ledger.Infrastructure.DataPersistence.TypeConfigurators
{
    internal class OrderTypeConfigurator : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(o => new { o.ProductId, o.TicketId, o.Value, o.Amount });

            builder.HasOne(o => o.Product)
                .WithMany()
                .IsRequired();
        }
    }
}
