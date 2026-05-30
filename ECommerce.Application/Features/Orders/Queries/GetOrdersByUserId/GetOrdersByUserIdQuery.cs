using MediatR;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Features.Orders.Queries.GetOrdersByUserId;

public record GetOrdersByUserIdQuery(Guid UserId) : IRequest<IEnumerable<Order>>;