using ComprasDotnet6.Application.DTOs;
using FluentValidation;

namespace ComprasDotnet6.Application.ValidationDTOs
{
    public class UserDTOValidator : AbstractValidator<UserDTO>
    {
        public UserDTOValidator()
        {
            RuleFor(u => u.Email).NotEmpty().NotNull().WithMessage("Email deve ser informado!");
            RuleFor(u => u.Password).NotEmpty().NotNull().WithMessage("Senha deve ser informado!");
        }
    }
}
