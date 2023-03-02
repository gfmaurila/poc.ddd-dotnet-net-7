using Auth.Domain.Entities.Users;
using FluentValidation;

namespace Auth.Domain.Validators;
public class UserRoleValidator : AbstractValidator<UserRole>
{
    public UserRoleValidator()
    {
        RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.")

                .NotNull()
                .WithMessage("A entidade não pode ser nula.");

        RuleFor(x => x.Discriminator)
            .NotNull()
            .WithMessage("O Discriminator não pode ser nulo.")

            .NotEmpty()
            .WithMessage("O Discriminator não pode ser vazio.")

            .MinimumLength(3)
            .WithMessage("O Discriminator deve ter no mínimo 3 caracteres.")

            .MaximumLength(80)
            .WithMessage("O Discriminator deve ter no máximo 80 caracteres.");

    }
}
