using MediatR;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Features.Orders.Queries.GetOrderById;

public record GetOrderByIdQuery(Guid OrderId) : IRequest<Order?>;