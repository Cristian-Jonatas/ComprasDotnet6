using ComprasDotnet6.Application.DTOs;
using FluentValidation;

namespace ComprasDotnet6.Application.ValidationDTOs
{
    public class PurchaseDTOValidator : AbstractValidator<PurchaseDTO>
    {
        public PurchaseDTOValidator()
        {
            RuleFor(x => x.CodErp).NotEmpty().NotNull().WithMessage("Código deve ser informado!");
            RuleFor(x => x.Document).NotEmpty().NotNull().WithMessage("Documento deve ser informado!");
        }
    }
}
