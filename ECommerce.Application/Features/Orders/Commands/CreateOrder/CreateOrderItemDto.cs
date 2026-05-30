namespace ECommerce.Application.Features.Orders.Commands.CreateOrder;

public record CreateOrderItemDto(
    Guid ProductId,
    int Quantity
);