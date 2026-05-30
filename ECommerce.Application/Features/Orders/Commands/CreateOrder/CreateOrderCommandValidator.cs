using FluentValidation;
using ECommerce.Application.Features.Orders.Commands.CreateOrder;

namespace ECommerce.Application.Features.Orders.Commands.CreateOrder;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("El UserId es obligatorio.");

        RuleFor(x => x.Items)
            .NotEmpty().WithMessage("La orden debe contener al menos un producto.");

        RuleForEach(x => x.Items).ChildRules(item =>
        {
            item.RuleFor(i => i.ProductId)
                .NotEmpty().WithMessage("El ProductId es obligatorio.");

            item.RuleFor(i => i.Quantity)
                .GreaterThan(0).WithMessage("La cantidad debe ser mayor a 0.");
        });
    }
}