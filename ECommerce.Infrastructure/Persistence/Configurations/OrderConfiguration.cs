//ECommerce.Infrastructure/Persistence/Configurations/OrderConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ECommerce.Domain.Entities;

namespace ECommerce.Infrastructure.Persistence.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");

        builder.HasKey(o => o.Id);

        builder.Property(o => o.UserId).IsRequired();
        builder.Property(o => o.CreatedAt).IsRequired();
        builder.Property(o => o.Total)
               .IsRequired()
               .HasColumnType("decimal(18,2)");

        builder.Property(o => o.Status)
               .HasConversion<string>()           // Guarda el enum como texto
               .HasMaxLength(20);

        // Relación 1:N con OrderItems
        builder.HasMany(o => o.Items)
               .WithOne()
               .HasForeignKey(i => i.OrderId)
               .OnDelete(DeleteBehavior.Cascade); // Si borro la orden, borro sus items
    }
}