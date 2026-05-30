using MediatR;
using ECommerce.Domain.Entities;
using ECommerce.Application.Interfaces;

namespace ECommerce.Application.Features.Orders.Commands.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;   // Necesitamos verificar stock y precio

    public CreateOrderCommandHandler(
        IOrderRepository orderRepository,
        IProductRepository productRepository)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
    }

    public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        if (request.Items == null || request.Items.Count == 0)
            throw new ArgumentException("La orden debe tener al menos un producto.");

        var order = new Order(request.UserId);

        foreach (var itemDto in request.Items)
        {
            var product = await _productRepository.GetByIdAsync(itemDto.ProductId, cancellationToken);
            
            if (product == null)
                throw new KeyNotFoundException($"Producto con ID {itemDto.ProductId} no encontrado.");

            order.AddItem(product, itemDto.Quantity);   // Aquí se aplica la lógica de dominio
        }

        await _orderRepository.AddAsync(order, cancellationToken);

        return order;
    }
}