using MediatR;
using ECommerce.Application.Interfaces;

namespace ECommerce.Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IProductRepository _repository;

    public DeleteProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(command.Id, cancellationToken);
        if (product == null)
            return false;

        await _repository.DeleteAsync(command.Id, cancellationToken);
        return true;
    }
}