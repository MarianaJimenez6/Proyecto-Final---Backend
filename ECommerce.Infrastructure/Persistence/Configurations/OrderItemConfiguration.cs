//ECommerce.Infrastructure/Persistence/Configurations/OrderItemConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ECommerce.Domain.Entities;

namespace ECommerce.Infrastructure.Persistence.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("OrderItems");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.OrderId).IsRequired();
        builder.Property(i => i.ProductId).IsRequired();
        builder.Property(i => i.UnitPrice)
               .IsRequired()
               .HasColumnType("decimal(18,2)");

        builder.Property(i => i.Quantity).IsRequired();

        // Subtotal es calculado, no se guarda en BD
        builder.Ignore(i => i.Subtotal);
    }
}