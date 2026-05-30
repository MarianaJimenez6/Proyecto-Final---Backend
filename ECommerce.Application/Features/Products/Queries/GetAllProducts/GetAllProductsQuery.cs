using MediatR;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Features.Products.Queries.GetAllProducts;

public record GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>;

public record ProductDto(
    Guid Id,
    string Name,
    string Description,
    decimal Price,
    int Stock
);