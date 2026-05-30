using ECommerce.Domain.Exceptions;

namespace ECommerce.Domain.Entities;

public enum OrderStatus
{
    Pending,
    Confirmed,
    Shipped,
    Delivered,
    Cancelled
}

public class Order : BaseEntity
{
    public Guid UserId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public OrderStatus Status { get; private set; }
    public decimal Total { get; private set; }

    private readonly List<OrderItem> _items = new();
    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

    private Order() { } // Constructor vacío para EF Core

    public Order(Guid userId)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException("El UserId es obligatorio");

        UserId = userId;
        CreatedAt = DateTime.UtcNow;
        Status = OrderStatus.Pending;
        Total = 0;
    }

    public void AddItem(Product product, int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("La cantidad debe ser mayor a cero");

        product.ReduceStock(quantity); // Regla de negocio

        var item = new OrderItem(Id, product.Id, product.Price, quantity);
        _items.Add(item);
        Total += item.Subtotal;
    }
}