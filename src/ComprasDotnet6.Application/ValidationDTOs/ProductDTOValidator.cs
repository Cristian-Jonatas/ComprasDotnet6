using ComprasDotnet6.Application.DTOs;
using FluentValidation;

namespace ComprasDotnet6.Application.ValidationDTOs
{
    public class ProductDTOValidator : AbstractValidator<ProductDTO>
    {
        public ProductDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Nome deve ser informado!");
            RuleFor(x => x.CodErp).NotEmpty().NotNull().WithMessage("Código deve ser informado!");
            RuleFor(x => x.Price).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Preço deve ser informado e não negativo");
        }

    }
}
