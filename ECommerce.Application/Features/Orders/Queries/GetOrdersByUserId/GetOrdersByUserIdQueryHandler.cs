using MediatR;
using ECommerce.Domain.Entities;
using ECommerce.Application.Interfaces;

namespace ECommerce.Application.Features.Orders.Queries.GetOrdersByUserId;

public class GetOrdersByUserIdQueryHandler : IRequestHandler<GetOrdersByUserIdQuery, IEnumerable<Order>>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrdersByUserIdQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<IEnumerable<Order>> Handle(GetOrdersByUserIdQuery request, CancellationToken cancellationToken)
    {
        return await _orderRepository.GetByUserIdAsync(
            request.UserId, 
            cancellationToken);
    }
}