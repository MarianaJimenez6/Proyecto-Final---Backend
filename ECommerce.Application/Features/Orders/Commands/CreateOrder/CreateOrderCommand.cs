using MediatR;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Features.Orders.Commands.CreateOrder;

public record CreateOrderCommand(
    Guid UserId,
    List<CreateOrderItemDto> Items
) : IRequest<Order>;