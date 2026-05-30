//ECommerce.Infrastructure/Persistence/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using ECommerce.Domain.Entities;

namespace ECommerce.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    {
    }
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderItem> OrderItems { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

    // Seed de datos de ejemplo
    modelBuilder.Entity<Product>().HasData(
        new Product("Laptop Dell", "Laptop gaming i7", 1200.99m, 15, Guid.NewGuid()),
        new Product("Iphone 15", "Celular Apple", 899.99m, 8, Guid.NewGuid()),
        new Product("Casco Moto", "Casco integral", 85.50m, 25, Guid.NewGuid())
    );

    // Seed de usuario de prueba
    modelBuilder.Entity<User>().HasData(
        new User("Admin", "admin@ecommerce.com", "123456", "Admin")
    );

    base.OnModelCreating(modelBuilder);
    }
}